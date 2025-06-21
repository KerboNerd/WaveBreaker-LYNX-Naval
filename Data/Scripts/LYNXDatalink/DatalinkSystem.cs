using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Game.Entity;
using VRage.Utils;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI.Interfaces.Terminal;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using Sandbox.Common.ObjectBuilders;
using Draygo.API;
using CoreSystems.Api;

namespace LYNX_Aeronautics
{ 
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_ConveyorSorter), false, "LXN_DatalinkPod_01")]
    public class DatalinkPodComponent : MyGameLogicComponent
    {
        private IMyConveyorSorter conveyorSorter;
        private IMyTerminalBlock terminalBlock;
        private IMyFunctionalBlock functionalBlock;
        
        // Datalink properties
        private float _frequency = 121.5f;
        private float _range = 50000f;
        public float Frequency 
        { 
            get { return _frequency; } 
            set 
            { 
                if (Math.Abs(_frequency - value) > 0.01f)
                {
                    _frequency = value;
                    // Clear signatures when frequency changes
                    Signatures.Clear();
                    // Force immediate signature update
                    MyAPIGateway.Parallel.Start(() =>
                    {
                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                        {
                            if (!Entity.MarkedForClose)
                            {
                                UpdateSignatures();
                            }
                        });
                    });
                }
            }
        }
        public float Range 
        { 
            get { return _range; } 
            set 
            { 
                if (Math.Abs(_range - value) > 0.01f)
                {
                    _range = value;
                    // Clear signatures when range changes
                    Signatures.Clear();
                    // Force immediate signature update
                    MyAPIGateway.Parallel.Start(() =>
                    {
                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                        {
                            if (!Entity.MarkedForClose)
                            {
                                UpdateSignatures();
                            }
                        });
                    });
                }
            }
        }
        public List<DatalinkSignature> Signatures { get; private set; } = new List<DatalinkSignature>();
        
        // Static management
        private static List<DatalinkPodComponent> allDatalinks = new List<DatalinkPodComponent>();
        private static bool controlsSetup = false;
        private static bool staticSystemInitialized = false;
        private static int updateCounter = 0;
        private static bool hudEnabled = true;
        private static HudAPIv2 hudAPI = null;
        private static HudAPIv2.HUDMessage contactDisplay = null;
        private static float? overrideFrequency = null; // Override frequency for display
        private static WcApi wcAPI = null;
        
        // Strategic marking system
        private static List<StrategicMark> allStrategicMarks = new List<StrategicMark>();
        private static bool markKeyPressed = false;
        private static DateTime lastMarkTime = DateTime.MinValue;
        
        // WeaponCore-style pointer system
        private static Vector2 _pointerPosition = Vector2.Zero;
        private static Vector2 _3RdPersonPos = Vector2.Zero;
        private static Vector3D _pointerOffset = Vector3D.Zero;
        private static bool _cachedPointerPos = false;
        
        // Drawing materials
        private static MyStringId missileOutline = MyStringId.GetOrCompute("MissileOutline");
        private static MyStringId line = MyStringId.GetOrCompute("particle_laser");
        private static MyStringId crosshair = MyStringId.GetOrCompute("Crosshair_1");
        private static MyStringId warning = MyStringId.GetOrCompute("Warning_1");
        
        // Symbol sizing
        private static float symbolWidth = 0.015f; // Smaller markers
        private static float symbolHeight = 0f; // Calculated based on aspect ratio
        private static float aspectRatio = 0f;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            conveyorSorter = Entity as IMyConveyorSorter;
            terminalBlock = Entity as IMyTerminalBlock;
            functionalBlock = Entity as IMyFunctionalBlock;

            if (terminalBlock != null)
            {
                terminalBlock.AppendingCustomInfo += AppendCustomInfo;
                SetupTerminalControls();
            }

            // Add to global list
            allDatalinks.Add(this);
            
            NeedsUpdate |= MyEntityUpdateEnum.EACH_FRAME;
            
            // Initialization complete
            
            // Setup static system once
            if (!staticSystemInitialized)
            {
                staticSystemInitialized = true;
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
                InitializeHudAPI();
            }
            
            // Force immediate signature update for this datalink (helps with game load)
            MyAPIGateway.Parallel.Start(() =>
            {
                MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                {
                    if (!Entity.MarkedForClose)
                    {
                        UpdateSignatures();
                    }
                });
            });
        }

        public override void UpdateAfterSimulation()
        {
            // Calculate aspect ratio and symbol height if not set
            if (symbolHeight == 0 && MyAPIGateway.Session?.Camera != null)
            {
                aspectRatio = MyAPIGateway.Session.Camera.ViewportSize.X / MyAPIGateway.Session.Camera.ViewportSize.Y;
                symbolHeight = symbolWidth * aspectRatio;
            }
            
            updateCounter++;
            
            // Handle strategic marking input (only for the first datalink on each grid to avoid duplicates)
            if (IsFirstDatalinkOnGrid())
            {
                HandleStrategicMarkingInput();
            }
            
            // Update signatures every second
            if (updateCounter >= 60)
            {
                updateCounter = 0;
                UpdateSignatures();
                CleanupExpiredMarks();
            }
            
            // Ensure signature updates for newly loaded datalinks
            if (updateCounter <= 600 && updateCounter % 60 == 30)
            {
                UpdateSignatures();
            }
            
            // Draw every frame like WC Radar does
            if (hudEnabled)
            {
                DrawDatalinks();
            }
        }

        private void UpdateSignatures()
        {
            if (!IsActive) return;
            
            Signatures.Clear();
            
            foreach (var otherDatalink in allDatalinks)
            {
                if (otherDatalink == this || !otherDatalink.IsActive) continue;
                
                // Strict frequency matching (0.05f tolerance instead of 0.1f)
                if (Math.Abs(otherDatalink.Frequency - this.Frequency) > 0.05f) continue;
                
                double distance = Vector3D.Distance(GetPosition(), otherDatalink.GetPosition());
                if (distance <= Range)
                {
                    // Add regular datalink contact
                    Signatures.Add(new DatalinkSignature
                    {
                        Position = otherDatalink.GetPosition(),
                        GridName = otherDatalink.GetGridName(),
                        Distance = distance,
                        SignalStrength = (float)(1.0 - (distance / Range)),
                        IsDatalink = true,
                        SourceGrid = otherDatalink.GetGridName()
                    });
                    
                    // Check if the other grid has a WeaponCore focus target to share
                    if (wcAPI != null && wcAPI.IsReady)
                    {
                        try
                        {
                            var otherGrid = otherDatalink.conveyorSorter?.CubeGrid;
                            if (otherGrid != null)
                            {
                                var focusTarget = wcAPI.GetAiFocus((MyEntity)otherGrid);
                                if (focusTarget != null)
                                {
                                    var focusDistance = Vector3D.Distance(GetPosition(), focusTarget.PositionComp.WorldAABB.Center);
                                    if (focusDistance <= Range * 2) // Extended range for focus targets
                                    {
                                        Signatures.Add(new DatalinkSignature
                                        {
                                            Position = focusTarget.PositionComp.WorldAABB.Center,
                                            GridName = $"[FOCUS] {focusTarget.DisplayName ?? "Unknown"}",
                                            Distance = focusDistance,
                                            SignalStrength = (float)(1.0 - (distance / Range)), // Signal strength based on datalink distance, not target distance
                                            IsDatalink = false,
                                            SourceGrid = otherDatalink.GetGridName(),
                                            TargetName = focusTarget.DisplayName ?? "Unknown Target"
                                        });
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Silent fail for focus target detection - don't break regular datalinks
                        }
                    }
                }
            }
            
            // Add strategic marks from all grids on the same frequency (including our own for visibility)
            var relevantMarks = allStrategicMarks.Where(m => 
                !m.IsExpired && 
                Math.Abs(m.Frequency - this.Frequency) <= 0.05f)
                .ToList();
            

            
            foreach (var mark in relevantMarks)
            {
                double distance = Vector3D.Distance(GetPosition(), mark.Position);
                if (distance <= Range * 1.5) // Slightly extended range for strategic marks
                {
                    var ageInSeconds = (DateTime.UtcNow - mark.TimeStamp).TotalSeconds;
                    var ageText = ageInSeconds < 60 ? $"{ageInSeconds:F0}s" : $"{ageInSeconds / 60:F0}m";
                    
                    Signatures.Add(new DatalinkSignature
                    {
                        Position = mark.Position,
                        GridName = $"[MARK] {mark.Label}",
                        Distance = distance,
                        SignalStrength = Math.Max(0.1f, 1.0f - (float)(ageInSeconds / 300.0f)), // Fades over 5 minutes
                        IsDatalink = false,
                        SourceGrid = mark.MarkedBy,
                        TargetName = $"{mark.Label} ({ageText} ago)"
                    });
                }
            }
            
            if (terminalBlock != null)
                terminalBlock.RefreshCustomInfo();
        }

        private bool IsFirstDatalinkOnGrid()
        {
            if (conveyorSorter?.CubeGrid == null) return false;
            
            // Check if this is the first active datalink on this grid
            var gridDatalinks = allDatalinks.Where(d => d.conveyorSorter?.CubeGrid == conveyorSorter.CubeGrid && d.IsActive).ToList();
            return gridDatalinks.FirstOrDefault() == this;
        }

        private void HandleStrategicMarkingInput()
        {
            if (!IsActive) return;
            
            try
            {
                // Check for key combinations
                var input = MyAPIGateway.Input;
                bool mKeyPressed = input.IsKeyPress(VRage.Input.MyKeys.M);
                bool ctrlPressed = input.IsKeyPress(VRage.Input.MyKeys.LeftControl) || input.IsKeyPress(VRage.Input.MyKeys.RightControl);
                bool shiftPressed = input.IsKeyPress(VRage.Input.MyKeys.LeftShift) || input.IsKeyPress(VRage.Input.MyKeys.RightShift);
                
                if (mKeyPressed && !markKeyPressed)
                {
                    // Key just pressed
                    markKeyPressed = true;
                    
                    // Rate limit to once per 2 seconds
                    if ((DateTime.UtcNow - lastMarkTime).TotalSeconds < 2.0)
                    {
                        MyAPIGateway.Utilities.ShowNotification("Strategic marking on cool down...", 1000, MyFontEnum.Red);
                        return;
                    }
                    
                    if (ctrlPressed)
                    {
                        // CTRL+M: Remove strategic mark you're pointing at
                        RemovePointedStrategicMark();
                    }
                    else if (shiftPressed)
                    {
                        // SHIFT+M: Remove all marks placed by your grid
                        RemoveOwnStrategicMarks();
                    }
                    else
                    {
                        // M: Place strategic mark
                        PlaceStrategicMark();
                    }
                    
                    lastMarkTime = DateTime.UtcNow;
                }
                else if (!mKeyPressed && markKeyPressed)
                {
                    // Key released
                    markKeyPressed = false;
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }

        private static void InitPointerOffset(double distanceOffset)
        {
            var camera = MyAPIGateway.Session?.Camera;
            if (camera == null) return;
            
            var cameraMatrix = camera.WorldMatrix;
            var screenPos = Vector3D.Zero;
            
            // Apply pointer position offset (for third person adjustments)
            screenPos.X = _pointerPosition.X;
            screenPos.Y = _pointerPosition.Y;
            screenPos.Z = -distanceOffset; // Distance in front of camera
            
            _pointerOffset = new Vector3D(screenPos.X, screenPos.Y, screenPos.Z);
            _cachedPointerPos = true;
        }

        private void PlaceStrategicMark()
        {
            try
            {
                // Get player's camera position and direction
                var camera = MyAPIGateway.Session?.Camera;
                if (camera == null) 
                {
                    return;
                }
                
                var playerGrid = conveyorSorter?.CubeGrid;
                if (playerGrid == null) 
                {
                    return;
                }
                
                // WeaponCore-style pointer calculation
                if (!_cachedPointerPos) InitPointerOffset(0.05);
                
                var cameraMatrix = camera.WorldMatrix;
                var cameraPos = cameraMatrix.Translation;
                
                // Check if player is in a ship controller (cockpit/seat)
                var shipController = MyAPIGateway.Session.Player?.Controller?.ControlledEntity as IMyShipController;
                var character = MyAPIGateway.Session.Player?.Character;
                
                Vector3D aimPosition;
                Vector3D rayDirection;
                Vector3D rayStart;
                
                if (shipController != null)
                {
                    // WeaponCore-style view mode detection and pointer handling
                    var input = MyAPIGateway.Input;
                    var wheelDelta = input.DeltaMouseScrollWheelValue();
                    var currentCtrl = input.IsKeyPress(VRage.Input.MyKeys.LeftControl) || input.IsKeyPress(VRage.Input.MyKeys.RightControl);
                    
                    // Detect view modes like WeaponCore does
                    var cameraBlockView = shipController == MyAPIGateway.Session.CameraController;
                    var firstPersonView = MyAPIGateway.Session.CameraController is IMyCharacter;
                    var turretBlockView = MyAPIGateway.Session.CameraController is IMyLargeTurretBase;
                    
                    if (cameraBlockView)
                    {
                        // Camera block view - reset Y position
                        _pointerPosition.Y = 0f;
                        InitPointerOffset(0.05);
                    }
                    else if (firstPersonView || turretBlockView)
                    {
                        // First person or turret view - center the pointer
                        if (Math.Abs(_pointerPosition.Y) > 0.001f)
                        {
                            _pointerPosition.Y = 0f;
                            InitPointerOffset(0.05);
                        }
                    }
                    else if (currentCtrl)
                    {
                        // Third person with CTRL pressed - allow wheel adjustment (matching WeaponCore logic)
                        if (wheelDelta != 0)
                        {
                            var currentPos = _pointerPosition.Y;
                            if (wheelDelta > 0) currentPos += 0.05f;
                            else currentPos -= 0.05f;
                            var clampPos = MathHelper.Clamp(currentPos, -1.25f, 1.25f);
                            _3RdPersonPos.Y = clampPos;
                            InitPointerOffset(0.05);
                        }
                        
                        if (Vector2.DistanceSquared(_pointerPosition, _3RdPersonPos) > 0.001f)
                        {
                            _pointerPosition = _3RdPersonPos;
                            InitPointerOffset(0.05);
                        }
                    }
                    else if (Vector2.DistanceSquared(_pointerPosition, _3RdPersonPos) > 0.001f)
                    {
                        // Third person without CTRL - use saved position
                        _pointerPosition = _3RdPersonPos;
                        InitPointerOffset(0.05);
                    }
                    
                    // Calculate aim position using exact WeaponCore method
                    var offsetPosition = Vector3D.Transform(_pointerOffset, cameraMatrix);
                    aimPosition = offsetPosition;
                    rayDirection = Vector3D.Normalize(aimPosition - cameraPos);
                    rayStart = cameraPos;
                }
                else if (character != null)
                {
                    // Player is on foot - use character's head matrix for accurate aiming
                    var headMatrix = character.GetHeadMatrix(true, true, false); // Get head matrix with aim offset
                    rayDirection = headMatrix.Forward;
                    rayStart = headMatrix.Translation;
                    aimPosition = rayStart + rayDirection * 100; // 100m ahead
                }
                else
                {
                    // Fallback to camera direction if nothing else available
                    rayDirection = cameraMatrix.Forward;
                    rayStart = cameraPos;
                    aimPosition = rayStart + rayDirection * 100; // 100m ahead
                }
                
                var rayEnd = rayStart + rayDirection * 50000; // 50km max range
                
                // Get grid center for distance calculations
                var gridCenter = playerGrid.PositionComp.GetPosition();
                
                // Add small offset to ray start to avoid starting inside geometry
                var offsetRayStart = rayStart + rayDirection * 0.1; // 10cm offset
                
                // Perform multiple raycasts with different collision layers for better terrain detection
                var hits = new List<IHitInfo>();
                
                // First try with default collision layer (15)
                MyAPIGateway.Physics.CastRay(offsetRayStart, rayEnd, hits, 15);
                
                // If no hits, try with character collision layer (better for terrain)
                if (hits.Count == 0)
                {
                    MyAPIGateway.Physics.CastRay(offsetRayStart, rayEnd, hits, 9); // Character collision layer
                }
                
                // If still no hits, try with a more inclusive layer
                if (hits.Count == 0)
                {
                    MyAPIGateway.Physics.CastRay(offsetRayStart, rayEnd, hits); // All layers
                }
                
                // Filter out hits on our own grid to avoid self-targeting
                var validHits = hits.Where(h => h.HitEntity != playerGrid).ToList();
                
                Vector3D markPosition;
                string targetInfo = "Point in Space";
                
                if (validHits.Count > 0)
                {
                    // Sort hits by distance to get the closest one
                    var sortedHits = validHits.OrderBy(h => Vector3D.DistanceSquared(rayStart, h.Position)).ToList();
                    var hit = sortedHits.First();
                    markPosition = hit.Position;
                    
                    // Add small offset from hit surface to avoid placing marker inside terrain
                    var hitNormal = hit.Normal;
                    if (hitNormal.LengthSquared() > 0.5) // Valid normal
                    {
                        markPosition += hitNormal * 0.5; // 50cm offset from surface
                    }
                    
                    // Try to get information about what we hit
                    var hitEntity = hit.HitEntity;
                    if (hitEntity != null)
                    {
                        if (hitEntity is IMyCubeGrid)
                        {
                            var grid = hitEntity as IMyCubeGrid;
                            targetInfo = $"Grid: {grid.DisplayName}";
                        }
                        else if (hitEntity is IMyVoxelBase)
                        {
                            var voxel = hitEntity as IMyVoxelBase;
                            // Determine voxel type
                            string voxelType = "Terrain";
                            if (voxel.StorageName != null)
                            {
                                if (voxel.StorageName.Contains("Planet"))
                                    voxelType = "Planet";
                                else if (voxel.StorageName.Contains("Moon"))
                                    voxelType = "Moon";
                                else if (voxel.StorageName.Contains("Asteroid"))
                                    voxelType = "Asteroid";
                            }
                            targetInfo = $"{voxelType}: {voxel.StorageName ?? "Surface"}";
                        }
                        else if (hitEntity is IMyCharacter)
                        {
                            var character = hitEntity as IMyCharacter;
                            targetInfo = $"Character: {character.DisplayName}";
                        }
                        else
                        {
                            targetInfo = $"Object: {hitEntity.DisplayName ?? hitEntity.GetType().Name}";
                        }
                    }
                    else
                    {
                        // Hit something but no entity info
                        targetInfo = "Unknown Surface";
                    }
                }
                else
                {
                    // No valid hits - try a shorter ray for nearby terrain
                    hits.Clear();
                    var shortRayEnd = rayStart + rayDirection * 1000; // 1km range
                    MyAPIGateway.Physics.CastRay(offsetRayStart, shortRayEnd, hits);
                    validHits = hits.Where(h => h.HitEntity != playerGrid).ToList();
                    
                    if (validHits.Count > 0)
                    {
                        var hit = validHits.OrderBy(h => Vector3D.DistanceSquared(rayStart, h.Position)).First();
                        markPosition = hit.Position;
                        
                        // Add offset from surface
                        var hitNormal = hit.Normal;
                        if (hitNormal.LengthSquared() > 0.5)
                        {
                            markPosition += hitNormal * 0.5;
                        }
                        
                        targetInfo = "Nearby Surface";
                    }
                    else
                    {
                        // Still no hits - place mark at default range in the direction we're looking
                        markPosition = rayStart + rayDirection * 10000; // 10km default
                        targetInfo = "Point in Space (10km ahead)";
                    }
                }
                
                // Create the strategic mark
                var mark = new StrategicMark
                {
                    Position = markPosition,
                    MarkedBy = GetGridName(),
                    TimeStamp = DateTime.UtcNow,
                    Frequency = this.Frequency,
                    Label = targetInfo
                };
                
                // Add to global list
                allStrategicMarks.Add(mark);
                
                // Calculate distance for feedback
                var distanceFromGrid = Vector3D.Distance(gridCenter, markPosition);
                var gridDistanceText = distanceFromGrid > 1000 ? $"{distanceFromGrid / 1000:F1}km" : $"{distanceFromGrid:F0}m";
                
                // Enhanced feedback for terrain marking
                if (targetInfo.Contains("Terrain") || targetInfo.Contains("Planet") || targetInfo.Contains("Moon") || targetInfo.Contains("Asteroid") || targetInfo.Contains("Surface"))
                {
                    MyAPIGateway.Utilities.ShowNotification($"Strategic mark placed on {targetInfo} at {gridDistanceText}", 4000, MyFontEnum.Green);
                }
                else
                {
                    MyAPIGateway.Utilities.ShowNotification($"Strategic mark placed: {targetInfo} at {gridDistanceText}", 3000, MyFontEnum.Green);
                }
                
                // Force immediate signature update to share the mark
                MyAPIGateway.Parallel.Start(() =>
                {
                    MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                    {
                        foreach (var datalink in allDatalinks)
                        {
                            if (datalink.IsActive && !datalink.Entity.MarkedForClose)
                            {
                                datalink.UpdateSignatures();
                            }
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                MyAPIGateway.Utilities.ShowNotification("Strategic marking failed", 2000, MyFontEnum.Red);
            }
        }

        private void RemovePointedStrategicMark()
        {
            try
            {
                var camera = MyAPIGateway.Session?.Camera;
                if (camera == null) return;
                
                var playerGrid = conveyorSorter?.CubeGrid;
                if (playerGrid == null) return;
                
                // Use same WeaponCore-style pointer calculation as placement
                if (!_cachedPointerPos) InitPointerOffset(0.05);
                
                var cameraMatrix = camera.WorldMatrix;
                var cameraPos = cameraMatrix.Translation;
                
                Vector3D aimPosition;
                Vector3D rayDirection;
                
                // Calculate aim position using WeaponCore method
                var offsetPosition = Vector3D.Transform(_pointerOffset, cameraMatrix);
                aimPosition = offsetPosition;
                rayDirection = Vector3D.Normalize(aimPosition - cameraPos);
                
                // Find the closest strategic mark to the aim line
                StrategicMark closestMark = null;
                double closestDistance = double.MaxValue;
                const double maxRemovalRange = 1000.0; // 1km max range to select marks for removal
                
                foreach (var mark in allStrategicMarks.Where(m => !m.IsExpired).ToList())
                {
                    // Calculate distance from aim line to mark position
                    var toMark = mark.Position - cameraPos;
                    var projectionLength = Vector3D.Dot(toMark, rayDirection);
                    
                    if (projectionLength > 0) // Mark is in front of camera
                    {
                        var closestPointOnLine = cameraPos + rayDirection * projectionLength;
                        var distanceToLine = Vector3D.Distance(mark.Position, closestPointOnLine);
                        
                        // Check if mark is close to aim line and within range
                        if (distanceToLine < 200 && projectionLength < maxRemovalRange) // 200m tolerance, 1km max range
                        {
                            if (projectionLength < closestDistance)
                            {
                                closestDistance = projectionLength;
                                closestMark = mark;
                            }
                        }
                    }
                }
                
                if (closestMark != null)
                {
                    allStrategicMarks.Remove(closestMark);
                    MyAPIGateway.Utilities.ShowNotification($"Removed strategic mark: {closestMark.Label}", 3000, MyFontEnum.Green);
                    
                    // Force signature refresh
                    RefreshAllSignatures();
                }
                else
                {
                    MyAPIGateway.Utilities.ShowNotification("No strategic mark found in crosshair", 2000, MyFontEnum.Red);
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }
        
        private void RemoveOwnStrategicMarks()
        {
            try
            {
                var gridName = GetGridName();
                var ownMarks = allStrategicMarks.Where(m => m.MarkedBy == gridName).ToList();
                
                if (ownMarks.Count > 0)
                {
                    foreach (var mark in ownMarks)
                    {
                        allStrategicMarks.Remove(mark);
                    }
                    
                    MyAPIGateway.Utilities.ShowNotification($"Removed {ownMarks.Count} strategic mark(s) placed by {gridName}", 3000, MyFontEnum.Green);
                    
                    // Force signature refresh
                    RefreshAllSignatures();
                }
                else
                {
                    MyAPIGateway.Utilities.ShowNotification("No strategic marks placed by this grid", 2000, MyFontEnum.Red);
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }

        private static void CleanupExpiredMarks()
        {
            try
            {
                var expiredMarks = allStrategicMarks.Where(m => m.IsExpired).ToList();
                foreach (var mark in expiredMarks)
                {
                    allStrategicMarks.Remove(mark);
                }
                
                if (expiredMarks.Count > 0)
                {
                    // Force signature update when marks expire
                    foreach (var datalink in allDatalinks)
                    {
                        if (datalink.IsActive && !datalink.Entity.MarkedForClose)
                        {
                            datalink.Signatures.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }

        private void AppendCustomInfo(IMyTerminalBlock block, StringBuilder info)
        {
            info.AppendLine($"Datalink Status: {(IsActive ? "ACTIVE" : "OFFLINE")}");
            info.AppendLine($"Frequency: {Frequency:F1} MHz");
            info.AppendLine($"Range: {Range / 1000f:F1} km");
            info.AppendLine($"Total Signatures: {Signatures.Count}");
            info.AppendLine();
            
            var datalinkContacts = Signatures.Where(s => s.IsDatalink).OrderBy(s => s.Distance).ToList();
            var sharedTargets = Signatures.Where(s => !s.IsDatalink && !s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).ToList();
            var strategicMarks = Signatures.Where(s => !s.IsDatalink && s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).ToList();
            
            if (datalinkContacts.Count > 0)
            {
                info.AppendLine("Datalink Contacts:");
                foreach (var sig in datalinkContacts)
                {
                    info.AppendLine($"• {sig.GridName}: {sig.Distance / 1000f:F1}km ({sig.SignalStrength:P0})");
                }
                info.AppendLine();
            }
            
            if (strategicMarks.Count > 0)
            {
                info.AppendLine("Strategic Marks:");
                foreach (var mark in strategicMarks)
                {
                    info.AppendLine($"⭐ {mark.TargetName}: {mark.Distance / 1000f:F1}km");
                    info.AppendLine($"  ↳ Marked by {mark.SourceGrid}");
                }
                info.AppendLine();
            }
            
            if (sharedTargets.Count > 0)
            {
                info.AppendLine("Shared Focus Targets:");
                foreach (var target in sharedTargets)
                {
                    info.AppendLine($"◆ {target.TargetName}: {target.Distance / 1000f:F1}km");
                    info.AppendLine($"  ↳ Focused by {target.SourceGrid}");
                }
            }
        }

        private static void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            if (messageText.ToLower().StartsWith("/datalink"))
            {
                sendToOthers = false;
                var args = messageText.Split(' ');
                
                if (args.Length == 1)
                {
                    ShowDatalinkStatus();
                }
                else if (args.Length == 2 && args[1].ToLower() == "hud")
                {
                    hudEnabled = !hudEnabled;
                    MyAPIGateway.Utilities.ShowMessage("Datalink", $"HUD Display: {(hudEnabled ? "ENABLED" : "DISABLED")}");
                }

                else if (args.Length == 2 && args[1].ToLower() == "clearmarks")
                {
                    var clearedCount = allStrategicMarks.Count;
                    allStrategicMarks.Clear();
                    RefreshAllSignatures();
                    MyAPIGateway.Utilities.ShowMessage("Datalink", $"Cleared {clearedCount} strategic marks");
                }
                else if (args.Length == 2 && args[1].ToLower() == "marks")
                {
                    ShowAllStrategicMarks();
                }
                else if (args.Length == 2 && args[1].ToLower() == "resetpointer")
                {
                    _pointerPosition = Vector2.Zero;
                    _3RdPersonPos = Vector2.Zero;
                    _cachedPointerPos = false;
                    MyAPIGateway.Utilities.ShowMessage("Datalink", "Strategic marking pointer reset to center");
                }
                else if (args.Length == 2 && args[1].ToLower() == "remove")
                {
                    // Find the first active datalink and use it to remove pointed mark
                    var activeDatalink = allDatalinks.FirstOrDefault(d => d.IsActive);
                    if (activeDatalink != null)
                    {
                        activeDatalink.RemovePointedStrategicMark();
                    }
                    else
                    {
                        MyAPIGateway.Utilities.ShowMessage("Datalink", "No active datalink pods found");
                    }
                }
                else if (args.Length == 2 && args[1].ToLower() == "freq")
                {
                    ShowAvailableFrequencies();
                }
                else if (args.Length == 3 && args[1].ToLower() == "freq")
                {
                    float freq;
                    if (float.TryParse(args[2], out freq))
                    {
                        overrideFrequency = freq;
                        MyAPIGateway.Utilities.ShowMessage("Datalink", $"Display frequency set to {freq:F1} MHz");
                        
                        // Force immediate refresh of all signatures to ensure proper filtering
                        RefreshAllSignatures();
                    }
                    else if (args[2].ToLower() == "auto")
                    {
                        overrideFrequency = null;
                        MyAPIGateway.Utilities.ShowMessage("Datalink", "Display frequency set to auto");
                        
                        // Force immediate refresh of all signatures
                        RefreshAllSignatures();
                    }
                    else
                    {
                        MyAPIGateway.Utilities.ShowMessage("Datalink", "Invalid frequency. Use: /datalink freq <number> or /datalink freq auto");
                    }
                }
            }
        }

        private static void ShowDatalinkStatus()
        {
            var activeCount = allDatalinks.Count(d => d.IsActive);
            var sb = new StringBuilder();
            sb.AppendLine("=== DATALINK STATUS ===");
            sb.AppendLine($"Total Pods: {allDatalinks.Count}");
            sb.AppendLine($"Active Pods: {activeCount}");
            sb.AppendLine($"HUD Display: {(hudEnabled ? "ENABLED" : "DISABLED")}");
            sb.AppendLine();
            
            var frequencies = allDatalinks.Where(d => d.IsActive).GroupBy(d => d.Frequency);
            foreach (var freq in frequencies)
            {
                sb.AppendLine($"Frequency {freq.Key:F1} MHz: {freq.Count()} pods");
            }
            
            sb.AppendLine();
            sb.AppendLine("Commands:");
            sb.AppendLine("/datalink - Show status");
            sb.AppendLine("/datalink hud - Toggle HUD display");
            sb.AppendLine("/datalink freq - Show available frequencies");
            sb.AppendLine("/datalink freq <MHz> - Set display frequency");
            sb.AppendLine("/datalink freq auto - Auto-select frequency");
            sb.AppendLine("/datalink marks - Show all strategic marks");
            sb.AppendLine("/datalink remove - Remove strategic mark you're pointing at");
            sb.AppendLine("/datalink clearmarks - Clear all strategic marks");
            sb.AppendLine("/datalink resetpointer - Reset strategic marking pointer to center");
            sb.AppendLine();
            sb.AppendLine("Strategic Marking:");
            sb.AppendLine("• M key - Place strategic marks where you're pointing");
            sb.AppendLine("• CTRL+M - Remove strategic mark you're pointing at");
            sb.AppendLine("• SHIFT+M - Remove all marks placed by your grid");
            sb.AppendLine("• CTRL + Mouse Wheel to adjust pointer in third person mode");
            sb.AppendLine("• Marks are shared with all grids on the same frequency");
            sb.AppendLine("• Marks expire after 5 minutes automatically");
            sb.AppendLine("• Rate limited to one action every 2 seconds");
            sb.AppendLine();
            sb.AppendLine("Features:");
            sb.AppendLine("• Hold ALT key to show marker labels");
            sb.AppendLine("• Tactical information sharing across datalink network");
            sb.AppendLine("• Strategic coordination via point-and-mark system");
            sb.AppendLine();
            sb.AppendLine("Marker Types:");
            sb.AppendLine("• Green diamonds = Datalink contacts");
            sb.AppendLine("• Orange crosshair = Your WeaponCore focus target");  
            sb.AppendLine("• Pink crosshairs = Allied focus targets (shared via datalink)");
            sb.AppendLine("• Yellow warning signs = Strategic marks (can be removed)");
            sb.AppendLine();
            sb.AppendLine("Coordination: Mark and unmark strategic locations for your fleet!");
            sb.AppendLine("Perfect for coordinating attacks, waypoints, and objectives.");
            sb.AppendLine("Remove marks when objectives are complete or outdated.");
            
            MyAPIGateway.Utilities.ShowMessage("Datalink", sb.ToString());
        }

        private static void ShowAvailableFrequencies()
        {
            var shipController = MyAPIGateway.Session.Player?.Controller?.ControlledEntity as IMyShipController;
            IMyCubeGrid playerGrid = null;
            
            if (shipController != null)
            {
                playerGrid = shipController.CubeGrid;
            }
            else
            {
                playerGrid = MyAPIGateway.Session.Player?.Character?.Parent as IMyCubeGrid;
            }
            
            if (playerGrid == null)
            {
                MyAPIGateway.Utilities.ShowMessage("Datalink", "No controlled grid found");
                return;
            }
            
            var playerDatalinks = allDatalinks.Where(d => d.conveyorSorter?.CubeGrid == playerGrid && d.IsActive).ToList();
            var frequencyGroups = playerDatalinks.GroupBy(d => (float)Math.Round(d.Frequency, 1)).ToList();
            
            var sb = new StringBuilder();
            sb.AppendLine("=== AVAILABLE FREQUENCIES ===");
            
            if (overrideFrequency.HasValue)
            {
                sb.AppendLine($"Display Mode: {overrideFrequency.Value:F1} MHz (manual)");
            }
            else
            {
                sb.AppendLine("Display Mode: Auto");
            }
            sb.AppendLine();
            
            if (frequencyGroups.Count == 0)
            {
                sb.AppendLine("No active datalink pods found on this grid");
            }
            else
            {
                foreach (var group in frequencyGroups.OrderBy(g => g.Key))
                {
                    var freq = group.Key;
                    var count = group.Count();
                    var signatures = group.Sum(d => d.Signatures.Count);
                    var isActive = overrideFrequency.HasValue ? Math.Abs(freq - overrideFrequency.Value) < 0.1f : false;
                    var marker = isActive ? "► " : "  ";
                    
                    sb.AppendLine($"{marker}{freq:F1} MHz: {count} pod(s), {signatures} contact(s)");
                }
            }
            
            sb.AppendLine();
            sb.AppendLine("Use '/datalink freq <MHz>' to switch frequency");
            sb.AppendLine("Use '/datalink freq auto' for automatic selection");
            
            MyAPIGateway.Utilities.ShowMessage("Datalink", sb.ToString());
        }

        private static void DrawWeaponCoreFocus(IMyCubeGrid playerGrid)
        {
            if (wcAPI == null || !wcAPI.IsReady || playerGrid == null) return;
            
            try
            {
                // Get the current AI focus target for the player's grid
                var focusTarget = wcAPI.GetAiFocus((MyEntity)playerGrid);
                if (focusTarget == null) return;
                
                var playerPos = playerGrid.PositionComp.WorldAABB.Center;
                var targetPos = focusTarget.PositionComp.WorldAABB.Center;
                var distance = Vector3D.Distance(playerPos, targetPos);
                
                // Draw connection line (red/orange for focus target)
                DrawFocusLine(targetPos, playerPos);
                
                // Get screen coordinates for marker
                var viewProjectionMat = MyAPIGateway.Session.Camera.ViewMatrix * MyAPIGateway.Session.Camera.ProjectionMatrix;
                var screenCoords = Vector3D.Transform(targetPos, viewProjectionMat);
                var offscreen = screenCoords.X > 1 || screenCoords.X < -1 || screenCoords.Y > 1 || screenCoords.Y < -1 || screenCoords.Z > 1;
                
                // Focus target uses orange/red color
                var focusColor = Color.OrangeRed;
                
                if (offscreen)
                {
                    // Draw off-screen indicator
                    DrawScreenEdge(screenCoords, focusColor.ToVector4(), false);
                }
                else
                {
                    // On-screen: draw focus marker (larger and different shape)
                    var markerScreen = new Vector2D(screenCoords.X, screenCoords.Y);
                    
                    // Draw crosshair marker for focus target
                    var focusMarker = new HudAPIv2.BillBoardHUDMessage(crosshair, markerScreen, focusColor.ToVector4(), Width: symbolWidth * 1.5f, Height: symbolHeight * 1.5f, TimeToLive: 2, Rotation: 0, HideHud: true, Shadowing: true);
                    
                    // Draw label when ALT key is held
                    if (hudAPI != null && hudAPI.Heartbeat && MyAPIGateway.Input.IsKeyPress(VRage.Input.MyKeys.Alt))
                    {
                        var labelPos = new Vector2D(screenCoords.X + 0.02, screenCoords.Y + 0.02);
                        DrawFocusLabel(focusTarget, targetPos, playerPos, labelPos, focusColor);
                    }
                }
            }
            catch (Exception ex)
            {
                // Silent fail for WeaponCore integration - don't spam errors
            }
        }

        private static void DrawFocusLine(Vector3D targetPos, Vector3D playerPos)
        {
            var distToTarg = Vector3D.Distance(playerPos, targetPos);
            var lineLength = Math.Min(distToTarg * 0.9f, 2000f); // Longer line for focus target
            var lineOffset = Math.Min(distToTarg * 0.05f, 25f); // Start closer to player
            
            if (lineLength <= lineOffset || distToTarg < 10)
                return;
                
            var dirToTarg = Vector3D.Normalize(targetPos - playerPos);
            var offsetStart = playerPos + dirToTarg * lineOffset;
            var offsetEnd = offsetStart + dirToTarg * lineLength;
            var color = Color.OrangeRed.ToVector4();
            
            // Thicker line for focus target
            MySimpleObjectDraw.DrawLine(offsetStart, offsetEnd, line, ref color, 1.2f, VRageRender.MyBillboard.BlendTypeEnum.AdditiveTop);
        }
        
        private static void DrawFocusLabel(MyEntity focusTarget, Vector3D position, Vector3D playerPos, Vector2D labelPosition, Color color)
        {
            var distance = Vector3D.Distance(position, playerPos);
            var info = new StringBuilder($"<color={color.R}, {color.G}, {color.B}>");
            info.AppendLine($"  [WC FOCUS]");
            info.AppendLine($"  {focusTarget.DisplayName ?? "Unknown Target"}");
            info.AppendLine($"  {(distance > 1000 ? (distance / 1000).ToString("0.0") + " km" : (int)distance + " m")}");
            
            var label = new HudAPIv2.HUDMessage(info, labelPosition, null, 2, 1, true, true);
            label.Visible = true;
        }

        private static void RefreshAllSignatures()
        {
            // Force all datalinks to refresh their signatures immediately
            foreach (var datalink in allDatalinks)
            {
                if (datalink.IsActive)
                {
                    datalink.Signatures.Clear();
                    MyAPIGateway.Parallel.Start(() =>
                    {
                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                        {
                            if (!datalink.Entity.MarkedForClose)
                            {
                                datalink.UpdateSignatures();
                            }
                        });
                    });
                }
            }
        }

        /*
        // Debug method - commented out for optimization but kept for potential future debugging
        private static void ShowDebugInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== DATALINK DEBUG INFO ===");
            
            // Basic system status
            sb.AppendLine($"Update Counter: {updateCounter}");
            sb.AppendLine($"HUD Enabled: {hudEnabled}");
            sb.AppendLine($"Controls Setup: {controlsSetup}");
            sb.AppendLine();
            
            // HUD API status
            sb.AppendLine("=== HUD API STATUS ===");
            if (hudAPI == null)
            {
                sb.AppendLine("HUD API: NULL (not initialized)");
            }
            else
            {
                sb.AppendLine($"HUD API: Initialized");
                sb.AppendLine($"HUD API Heartbeat: {hudAPI.Heartbeat}");
            }
            
            if (contactDisplay == null)
            {
                sb.AppendLine("Contact Display: NULL");
            }
            else
            {
                sb.AppendLine($"Contact Display: Initialized, Visible: {contactDisplay.Visible}");
            }
            
            // WeaponCore API status
            if (wcAPI == null)
            {
                sb.AppendLine("WeaponCore API: NULL (not initialized)");
            }
            else
            {
                sb.AppendLine($"WeaponCore API: Initialized, Ready: {wcAPI.IsReady}");
            }
            sb.AppendLine();
            
            // Player and camera status
            sb.AppendLine("=== PLAYER/CAMERA STATUS ===");
            var session = MyAPIGateway.Session;
            if (session?.Player == null)
            {
                sb.AppendLine("Player: NULL");
            }
            else
            {
                sb.AppendLine("Player: Valid");
                var controller = session.Player.Controller?.ControlledEntity;
                if (controller == null)
                {
                    sb.AppendLine("Controlled Entity: NULL");
                }
                else
                {
                    sb.AppendLine($"Controlled Entity: {controller.GetType().Name}");
                    var shipController = controller as IMyShipController;
                    if (shipController != null)
                    {
                        sb.AppendLine($"Ship Controller Grid: {shipController.CubeGrid?.DisplayName ?? "NULL"}");
                    }
                }
            }
            
            if (session?.Camera == null)
            {
                sb.AppendLine("Camera: NULL");
            }
            else
            {
                sb.AppendLine($"Camera: Valid");
                sb.AppendLine($"Aspect Ratio: {aspectRatio:F3}");
                sb.AppendLine($"Symbol Width: {symbolWidth:F3}");
                sb.AppendLine($"Symbol Height: {symbolHeight:F3}");
            }
            sb.AppendLine();
            
            // Datalink pod status
            sb.AppendLine("=== DATALINK PODS ===");
            sb.AppendLine($"Total Pods: {allDatalinks.Count}");
            var activeCount = allDatalinks.Count(d => d.IsActive);
            sb.AppendLine($"Active Pods: {activeCount}");
            
            // Get player's grid
            var shipController2 = session?.Player?.Controller?.ControlledEntity as IMyShipController;
            IMyCubeGrid playerGrid = null;
            if (shipController2 != null)
            {
                playerGrid = shipController2.CubeGrid;
            }
            
            if (playerGrid == null)
            {
                sb.AppendLine("Player Grid: NULL");
            }
            else
            {
                sb.AppendLine($"Player Grid: {playerGrid.DisplayName}");
                var playerDatalinks = allDatalinks.Where(d => d.conveyorSorter?.CubeGrid == playerGrid).ToList();
                sb.AppendLine($"Player Grid Datalinks: {playerDatalinks.Count}");
                var activePlayerDatalinks = playerDatalinks.Where(d => d.IsActive).ToList();
                sb.AppendLine($"Active Player Datalinks: {activePlayerDatalinks.Count}");
                
                if (activePlayerDatalinks.Count > 0)
                {
                    sb.AppendLine("Player Datalink Details:");
                    foreach (var dl in activePlayerDatalinks)
                    {
                        sb.AppendLine($"  - Freq: {dl.Frequency:F1} MHz, Range: {dl.Range/1000:F1}km, Sigs: {dl.Signatures.Count}");
                    }
                }
            }
            sb.AppendLine();
            
            // Signatures summary
            sb.AppendLine("=== SIGNATURES ===");
            
            if (overrideFrequency.HasValue)
            {
                sb.AppendLine($"Display Frequency Override: {overrideFrequency.Value:F1} MHz");
            }
            else
            {
                sb.AppendLine("Display Frequency: Auto");
            }
            
            var allSignatures = new List<DatalinkSignature>();
            float displayFreq = 0f;
            if (playerGrid != null)
            {
                var playerDatalinks = allDatalinks.Where(d => d.conveyorSorter?.CubeGrid == playerGrid && d.IsActive).ToList();
                var frequencyGroups = playerDatalinks.GroupBy(d => (float)Math.Round(d.Frequency, 1)).ToList();
                
                if (frequencyGroups.Count > 0)
                {
                    // Use same logic as DrawDatalinks to determine active frequency
                    IGrouping<float, DatalinkPodComponent> primaryFrequencyGroup;
                    if (overrideFrequency.HasValue)
                    {
                        primaryFrequencyGroup = frequencyGroups.FirstOrDefault(g => Math.Abs(g.Key - overrideFrequency.Value) < 0.1f);
                        if (primaryFrequencyGroup == null)
                        {
                            primaryFrequencyGroup = frequencyGroups.OrderByDescending(g => g.Count()).First();
                        }
                    }
                    else
                    {
                        primaryFrequencyGroup = frequencyGroups.OrderByDescending(g => g.Count()).First();
                    }
                    
                    displayFreq = primaryFrequencyGroup.Key;
                    foreach (var datalink in primaryFrequencyGroup)
                    {
                        allSignatures.AddRange(datalink.Signatures);
                    }
                }
            }
            
            sb.AppendLine($"Active Display Frequency: {displayFreq:F1} MHz");
            sb.AppendLine($"Total Signatures on Active Frequency: {allSignatures.Count}");
            if (allSignatures.Count > 0)
            {
                sb.AppendLine("Signature Details:");
                foreach (var sig in allSignatures.OrderBy(s => s.Distance).Take(5))
                {
                    sb.AppendLine($"  - {sig.GridName}: {sig.Distance/1000:F1}km ({sig.SignalStrength:P0})");
                }
                if (allSignatures.Count > 5)
                {
                    sb.AppendLine($"  ... and {allSignatures.Count - 5} more");
                }
            }
            sb.AppendLine();
            
            // WeaponCore Focus Status
            sb.AppendLine("=== WEAPONCORE FOCUS ===");
            if (wcAPI != null && wcAPI.IsReady && playerGrid != null)
            {
                try
                {
                    var focusTarget = wcAPI.GetAiFocus((MyEntity)playerGrid);
                    if (focusTarget != null)
                    {
                        var distance = Vector3D.Distance(playerGrid.PositionComp.WorldAABB.Center, focusTarget.PositionComp.WorldAABB.Center);
                        sb.AppendLine($"Current Focus: {focusTarget.DisplayName ?? "Unknown"}");
                        sb.AppendLine($"Focus Distance: {distance / 1000:F1} km");
                    }
                    else
                    {
                        sb.AppendLine("Current Focus: None");
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"Focus Error: {ex.Message}");
                }
            }
            else
            {
                sb.AppendLine("WeaponCore not available for focus detection");
            }
            sb.AppendLine();
            
            // Strategic marks status
            sb.AppendLine("=== STRATEGIC MARKS ===");
            sb.AppendLine($"Total Strategic Marks: {allStrategicMarks.Count}");
            var activeMark = allStrategicMarks.Where(m => !m.IsExpired).ToList();
            sb.AppendLine($"Active Strategic Marks: {activeMark.Count}");
            if (activeMark.Count > 0)
            {
                sb.AppendLine("Recent Marks:");
                foreach (var mark in activeMark.OrderByDescending(m => m.TimeStamp).Take(3))
                {
                    var age = (DateTime.UtcNow - mark.TimeStamp).TotalSeconds;
                    var ageText = age < 60 ? $"{age:F0}s" : $"{age / 60:F0}m";
                    sb.AppendLine($"  - {mark.Label} by {mark.MarkedBy} ({ageText} ago, freq {mark.Frequency:F1})");
                }
            }
            sb.AppendLine();
            
            // Material status
            sb.AppendLine("=== MATERIALS ===");
            sb.AppendLine($"Missile Outline ID: {missileOutline}");
            sb.AppendLine($"Line ID: {line}");
            sb.AppendLine($"Crosshair ID: {crosshair}");
            sb.AppendLine($"Warning ID: {warning}");
            
            MyAPIGateway.Utilities.ShowMessage("Datalink Debug", sb.ToString());
        }
        */

        private static void ShowAllStrategicMarks()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== ALL STRATEGIC MARKS ===");
            sb.AppendLine($"Total marks: {allStrategicMarks.Count}");
            sb.AppendLine();
            
            if (allStrategicMarks.Count == 0)
            {
                sb.AppendLine("No strategic marks found.");
            }
            else
            {
                var activeMarks = allStrategicMarks.Where(m => !m.IsExpired).OrderByDescending(m => m.TimeStamp).ToList();
                var expiredMarks = allStrategicMarks.Where(m => m.IsExpired).ToList();
                
                sb.AppendLine($"Active marks: {activeMarks.Count}");
                sb.AppendLine($"Expired marks: {expiredMarks.Count}");
                sb.AppendLine();
                
                if (activeMarks.Count > 0)
                {
                    sb.AppendLine("ACTIVE MARKS:");
                    foreach (var mark in activeMarks)
                    {
                        var age = (DateTime.UtcNow - mark.TimeStamp).TotalSeconds;
                        var ageText = age < 60 ? $"{age:F0}s" : $"{age / 60:F0}m";
                        sb.AppendLine($"• {mark.Label}");
                        sb.AppendLine($"  └ By: {mark.MarkedBy}");
                        sb.AppendLine($"  └ Freq: {mark.Frequency:F1} MHz");
                        sb.AppendLine($"  └ Age: {ageText}");
                        sb.AppendLine($"  └ Pos: {mark.Position.X:F0}, {mark.Position.Y:F0}, {mark.Position.Z:F0}");
                        sb.AppendLine();
                    }
                }
                
                if (expiredMarks.Count > 0)
                {
                    sb.AppendLine($"EXPIRED MARKS: {expiredMarks.Count} (will be cleaned up)");
                }
            }
            
            MyAPIGateway.Utilities.ShowMessage("Strategic Marks", sb.ToString());
        }

        private static void InitializeHudAPI()
        {
            try
            {
                hudAPI = new HudAPIv2(() =>
                {
                    // HUD API is now ready
                });
            }
            catch (Exception ex)
            {
                // Fall back to notification system
                hudAPI = null;
            }
            
            // Initialize WeaponCore API
            try
            {
                wcAPI = new WcApi();
                wcAPI.Load(() =>
                {
                    // WeaponCore API is now ready
                });
            }
            catch (Exception ex)
            {
                wcAPI = null;
            }
        }

        private static void DrawDatalinks()
        {
            // Get player's controlled grid
            var shipController = MyAPIGateway.Session.Player?.Controller?.ControlledEntity as IMyShipController;
            IMyCubeGrid playerGrid = null;
            
            if (shipController != null)
            {
                playerGrid = shipController.CubeGrid;
            }
            else
            {
                // Fallback for character on foot
                playerGrid = MyAPIGateway.Session.Player?.Character?.Parent as IMyCubeGrid;
            }
            
            if (playerGrid == null)
            {
                if (contactDisplay != null) contactDisplay.Visible = false;
                return;
            }
            
            var playerDatalinks = allDatalinks.Where(d => d.conveyorSorter?.CubeGrid == playerGrid && d.IsActive).ToList();

            // Group datalinks by frequency and get signatures for the primary frequency
            var frequencyGroups = playerDatalinks.GroupBy(d => (float)Math.Round(d.Frequency, 1)).ToList();
            
            if (frequencyGroups.Count == 0)
            {
                if (contactDisplay != null) contactDisplay.Visible = false;
                return;
            }
            
            // Use override frequency if set, otherwise use the frequency with the most datalinks
            IGrouping<float, DatalinkPodComponent> primaryFrequencyGroup;
            float primaryFrequency;
            
            if (overrideFrequency.HasValue)
            {
                primaryFrequencyGroup = frequencyGroups.FirstOrDefault(g => Math.Abs(g.Key - overrideFrequency.Value) < 0.1f);
                if (primaryFrequencyGroup == null)
                {
                    // Override frequency not found, reset it and use default
                    overrideFrequency = null;
                    primaryFrequencyGroup = frequencyGroups.OrderByDescending(g => g.Count()).First();
                }
                primaryFrequency = primaryFrequencyGroup.Key;
            }
            else
            {
                primaryFrequencyGroup = frequencyGroups.OrderByDescending(g => g.Count()).First();
                primaryFrequency = primaryFrequencyGroup.Key;
            }
            
            // Collect signatures only from datalinks on the primary frequency
            var allSignatures = new List<DatalinkSignature>();
            foreach (var datalink in primaryFrequencyGroup)
            {
                allSignatures.AddRange(datalink.Signatures);
            }
            
            // Update HUD text display less frequently
            if (updateCounter % 60 == 0)
            {
                UpdateHUDTextDisplay(allSignatures, primaryFrequency, frequencyGroups.Count);
            }
            
            // Draw 3D markers every frame
            if (allSignatures.Count > 0 && MyAPIGateway.Session?.Camera != null)
            {
                DrawDatalinkMarkers(allSignatures, playerGrid, primaryFrequency);
            }
            
            // Draw WeaponCore focus target
            if (MyAPIGateway.Session?.Camera != null)
            {
                DrawWeaponCoreFocus(playerGrid);
            }
        }
        
        private static void UpdateHUDTextDisplay(List<DatalinkSignature> allSignatures, float primaryFrequency, int totalFrequencyGroups)
        {
            // Use HUD API if available for text display
            if (hudAPI != null && hudAPI.Heartbeat)
            {
                UpdateAdvancedHUD(allSignatures, primaryFrequency, totalFrequencyGroups);
            }
            else
            {
                UpdateBasicNotifications(allSignatures, primaryFrequency, totalFrequencyGroups);
            }
        }
        
        private static void DrawDatalinkMarkers(List<DatalinkSignature> allSignatures, IMyCubeGrid playerGrid, float primaryFrequency)
        {
            try
            {
                // Remove duplicate signatures by position (same physical grid detected by multiple datalink pods)
                var uniqueSignatures = allSignatures.GroupBy(s => new { 
                        X = Math.Round(s.Position.X, 1), 
                        Y = Math.Round(s.Position.Y, 1), 
                        Z = Math.Round(s.Position.Z, 1) 
                    })
                    .Select(g => g.OrderBy(s => s.Distance).First()) // Keep the closest one for each position
                    .ToList();
                

                
                var viewProjectionMat = MyAPIGateway.Session.Camera.ViewMatrix * MyAPIGateway.Session.Camera.ProjectionMatrix;
                var camMat = MyAPIGateway.Session.Camera.WorldMatrix;
                
                foreach (var signature in uniqueSignatures.OrderBy(s => s.Distance).Take(8))
                {
                    DrawDatalinkMarker(signature, viewProjectionMat, camMat, playerGrid);
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }
        
        private static void UpdateAdvancedHUD(List<DatalinkSignature> allSignatures, float primaryFrequency, int totalFrequencyGroups)
        {
            if (allSignatures.Count > 0 && hudEnabled)
            {
                var sb = new StringBuilder();
                sb.AppendLine("═══ TACTICAL DATALINK ═══");
                sb.AppendLine($"Frequency: {primaryFrequency:F1} MHz");
                if (totalFrequencyGroups > 1)
                {
                    sb.AppendLine($"({totalFrequencyGroups} frequencies active)");
                }
                sb.AppendLine();
                
                // Separate different types of signatures
                var datalinkContacts = allSignatures.Where(s => s.IsDatalink).OrderBy(s => s.Distance).Take(3).ToList();
                var strategicMarks = allSignatures.Where(s => !s.IsDatalink && s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).Take(3).ToList();
                var sharedFocusTargets = allSignatures.Where(s => !s.IsDatalink && !s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).Take(3).ToList();
                
                // Display datalink contacts
                if (datalinkContacts.Count > 0)
                {
                    sb.AppendLine("Datalink Contacts:");
                    foreach (var signature in datalinkContacts)
                    {
                        var dispRange = signature.Distance > 1000 ? 
                            (signature.Distance / 1000).ToString("0.#") + "km" : 
                            signature.Distance.ToString("0.#") + "m";
                        
                        var strengthIcon = signature.SignalStrength > 0.7f ? "●" : signature.SignalStrength > 0.4f ? "◐" : "○";
                        sb.AppendLine($"{strengthIcon} {signature.GridName}: {dispRange}");
                    }
                    sb.AppendLine();
                }
                
                // Display strategic marks
                if (strategicMarks.Count > 0)
                {
                    sb.AppendLine("Strategic Marks:");
                    foreach (var mark in strategicMarks)
                    {
                        var dispRange = mark.Distance > 1000 ? 
                            (mark.Distance / 1000).ToString("0.#") + "km" : 
                            mark.Distance.ToString("0.#") + "m";
                        
                        sb.AppendLine($"⭐ {mark.TargetName}: {dispRange}");
                        sb.AppendLine($"  ↳ by {mark.SourceGrid}");
                    }
                    sb.AppendLine();
                }
                
                // Display shared focus targets
                if (sharedFocusTargets.Count > 0)
                {
                    sb.AppendLine("Shared Targets:");
                    foreach (var signature in sharedFocusTargets)
                    {
                        var dispRange = signature.Distance > 1000 ? 
                            (signature.Distance / 1000).ToString("0.#") + "km" : 
                            signature.Distance.ToString("0.#") + "m";
                        
                        sb.AppendLine($"◆ {signature.TargetName}: {dispRange}");
                        sb.AppendLine($"  ↳ by {signature.SourceGrid}");
                    }
                }
                
                // Create or update HUD message
                if (contactDisplay == null)
                {
                    contactDisplay = new HudAPIv2.HUDMessage(
                        sb,
                        new Vector2D(-0.95, 0.7), // Top-left position
                        null,
                        -1, // Persistent display
                        1.2, // Scale
                        true, // Hide with HUD
                        true, // Shadowing
                        Color.Black // Shadow color
                    );
                    contactDisplay.InitialColor = Color.Cyan;
                    contactDisplay.Visible = true;
                }
                else
                {
                    contactDisplay.Message = sb;
                    contactDisplay.Visible = true;
                }
            }
            else
            {
                // Hide display when no contacts
                if (contactDisplay != null)
                {
                    contactDisplay.Visible = false;
                }
            }
        }
        
        private static void DrawDatalinkMarker(DatalinkSignature signature, MatrixD viewProjectionMat, MatrixD camMat, IMyCubeGrid playerGrid)
        {
            try
            {
                var position = signature.Position;
                var playerPos = playerGrid.PositionComp.WorldAABB.Center;
                var screenCoords = Vector3D.Transform(position, viewProjectionMat);
                var offscreen = screenCoords.X > 1 || screenCoords.X < -1 || screenCoords.Y > 1 || screenCoords.Y < -1 || screenCoords.Z > 1;
                

                
                Color markerColor;
                float markerSize = symbolWidth;
                float lineThickness = 0.8f;
                bool isStrategicMark = signature.GridName.StartsWith("[MARK]");
                
                if (signature.IsDatalink)
                {
                    // Regular datalink contact - green based on signal strength
                    if (signature.SignalStrength > 0.7f)
                        markerColor = Color.LimeGreen;
                    else if (signature.SignalStrength > 0.4f)
                        markerColor = Color.Yellow;
                    else
                        markerColor = Color.Red;
                    markerSize = symbolWidth * 0.7f; // Smaller for datalink contacts
                    lineThickness = 0.6f; // Thinner line
                }
                else if (isStrategicMark)
                {
                    // Strategic mark - yellow/gold with fading based on age
                    var intensity = Math.Max(0.3f, signature.SignalStrength); // Don't fade too much
                    markerColor = Color.FromNonPremultiplied(
                        (int)(255 * intensity), 
                        (int)(215 * intensity), 
                        0, 
                        255);
                    markerSize = symbolWidth * 2.0f; // Much larger for strategic marks
                    lineThickness = 1.2f; // Thicker line
                }
                else
                {
                    // Shared focus target from allied grid - pink/magenta
                    markerColor = Color.HotPink;
                    markerSize = symbolWidth * 1.2f; // Slightly larger for focus targets
                    lineThickness = 1.0f; // Slightly thicker line
                }
                
                // Draw connection line
                DrawSharedLine(position, playerPos, markerColor.ToVector4(), lineThickness, isStrategicMark);
                
                if (offscreen)
                {
                    // Draw off-screen indicator
                    DrawScreenEdge(screenCoords, markerColor.ToVector4(), isStrategicMark);
                }
                else
                {
                    // On-screen marker
                    var markerScreen = new Vector2D(screenCoords.X, screenCoords.Y);
                    
                    if (signature.IsDatalink)
                    {
                        // Regular datalink contact - small diamond marker
                        var marker = new HudAPIv2.BillBoardHUDMessage(missileOutline, markerScreen, markerColor.ToVector4(), Width: markerSize, Height: markerSize * aspectRatio, TimeToLive: 2, Rotation: 0.785398f, HideHud: true, Shadowing: true);
                    }
                    else if (isStrategicMark)
                    {
                        // Strategic mark - warning symbol with enhanced pulsing
                        // Create a multi-layered pulsing effect
                        float basePulse = (float)Math.Sin(updateCounter * 0.1f);
                        float fastPulse = (float)Math.Sin(updateCounter * 0.3f);
                        
                        // Main marker with size pulsing
                        var mainPulseSize = markerSize * (1.0f + 0.15f * basePulse);
                        var warningMarker = new HudAPIv2.BillBoardHUDMessage(warning, markerScreen, markerColor.ToVector4(), Width: mainPulseSize, Height: mainPulseSize * aspectRatio, TimeToLive: 2, Rotation: 0f, HideHud: true, Shadowing: true);
                        
                        // Inner glow layer with faster pulsing
                        var innerGlowSize = markerSize * (0.8f + 0.3f * fastPulse);
                        var innerGlowColor = Color.FromNonPremultiplied(
                            (int)(markerColor.R * 1.2f), 
                            (int)(markerColor.G * 1.2f), 
                            (int)(markerColor.B * 0.8f), 
                            (int)(128 + 64 * basePulse));
                        var innerGlow = new HudAPIv2.BillBoardHUDMessage(warning, markerScreen, innerGlowColor.ToVector4(), Width: innerGlowSize, Height: innerGlowSize * aspectRatio, TimeToLive: 2, Rotation: 0, HideHud: true, Shadowing: false);
                        
                        // Outer halo effect with opposite phase pulsing
                        var outerPulseSize = markerSize * (1.5f + 0.5f * -basePulse);
                        var outerHaloColor = Color.FromNonPremultiplied(markerColor.R, markerColor.G, markerColor.B, (int)(32 + 32 * Math.Abs(basePulse)));
                        var outerHalo = new HudAPIv2.BillBoardHUDMessage(warning, markerScreen, outerHaloColor.ToVector4(), Width: outerPulseSize, Height: outerPulseSize * aspectRatio, TimeToLive: 2, Rotation: 0, HideHud: true, Shadowing: false);
                        
                        // Add rotation to the outer halo for additional dynamism
                        var rotatingHaloSize = markerSize * 2.0f;
                        var rotationAngle = updateCounter * 0.02f; // Slow rotation
                        var rotatingHalo = new HudAPIv2.BillBoardHUDMessage(warning, markerScreen, Color.FromNonPremultiplied(markerColor.R, markerColor.G, markerColor.B, 16).ToVector4(), Width: rotatingHaloSize, Height: rotatingHaloSize * aspectRatio, TimeToLive: 2, Rotation: rotationAngle, HideHud: true, Shadowing: false);
                    }
                    else
                    {
                        // Shared focus target - crosshair marker
                        var focusMarker = new HudAPIv2.BillBoardHUDMessage(crosshair, markerScreen, markerColor.ToVector4(), Width: markerSize, Height: markerSize * aspectRatio, TimeToLive: 2, Rotation: 0, HideHud: true, Shadowing: true);
                    }
                    
                    // Draw label right next to the marker (small offset) - only when ALT key is held
                    if (hudAPI != null && hudAPI.Heartbeat && MyAPIGateway.Input.IsKeyPress(VRage.Input.MyKeys.Alt))
                    {
                        var labelPos = new Vector2D(screenCoords.X + 0.02, screenCoords.Y + 0.02);
                        DrawLabel(signature, position, playerPos, labelPos, markerColor);
                    }
                }
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }
        

        
        private static void DrawScreenEdge(Vector3D screenCoords, Vector4 color, bool isStrategicMark = false)
        {
            if (screenCoords.Z > 1) // Camera is between player and target
                screenCoords *= -1;
                
            var screenEdgeX = 0f;
            var screenEdgeY = 0f;
            
            if (Math.Abs(screenCoords.X) > Math.Abs(screenCoords.Y))
            {
                if (screenCoords.X < 0) // left edge
                {
                    screenEdgeX = -1;
                    screenEdgeY = (float)(screenCoords.Y / -screenCoords.X);
                }
                else // right edge
                {
                    screenEdgeX = 1;
                    screenEdgeY = (float)(screenCoords.Y / screenCoords.X);
                }
            }
            else
            {
                if (screenCoords.Y < 0) // bottom edge
                {
                    screenEdgeY = -1;
                    screenEdgeX = (float)(screenCoords.X / -screenCoords.Y);
                }
                else // top edge
                {
                    screenEdgeY = 1;
                    screenEdgeX = (float)(screenCoords.X / screenCoords.Y);
                }
            }
            
            var rotation = (float)Math.Atan2(screenEdgeX, screenEdgeY);
            
            if (isStrategicMark)
            {
                // Enhanced off-screen indicator for strategic marks
                float pulse = (float)Math.Sin(updateCounter * 0.15f);
                float sizePulse = 1.0f + 0.3f * Math.Abs(pulse);
                
                // Make the indicator blink by varying the color intensity
                var blinkColor = new Vector4(
                    Math.Min(1.0f, color.X * (1.5f + 0.5f * pulse)),
                    Math.Min(1.0f, color.Y * (1.5f + 0.5f * pulse)),
                    Math.Min(1.0f, color.Z * (1.0f + 0.3f * pulse)),
                    0.8f + 0.2f * Math.Abs(pulse)
                );
                
                // Draw a larger, pulsing indicator
                var symbolObj = new HudAPIv2.BillBoardHUDMessage(line, new Vector2D(screenEdgeX, screenEdgeY), blinkColor, Width: 0.015f * sizePulse, Height: 0.075f * sizePulse, TimeToLive: 2, Rotation: rotation);
                
                // Add a secondary indicator for extra visibility
                var glowColor = new Vector4(blinkColor.X * 0.7f, blinkColor.Y * 0.7f, blinkColor.Z * 0.5f, blinkColor.W * 0.5f);
                var glowObj = new HudAPIv2.BillBoardHUDMessage(line, new Vector2D(screenEdgeX, screenEdgeY), glowColor, Width: 0.02f * sizePulse, Height: 0.1f * sizePulse, TimeToLive: 2, Rotation: rotation);
            }
            else
            {
                // Standard off-screen indicator
                var symbolObj = new HudAPIv2.BillBoardHUDMessage(line, new Vector2D(screenEdgeX, screenEdgeY), color, Width: 0.01f, Height: 0.05f, TimeToLive: 2, Rotation: rotation);
            }
        }
        
        private static void DrawLine(Vector3D targetPos, Vector3D playerPos)
        {
            var distToTarg = Vector3D.Distance(playerPos, targetPos);
            var lineLength = Math.Min(distToTarg * 0.8f, 1000f); // Use 80% of distance, max 1km
            var lineOffset = Math.Min(distToTarg * 0.1f, 50f); // Start 10% away from player
            
            if (lineLength <= lineOffset || distToTarg < 10) // Don't draw if too close
                return;
                
            var dirToTarg = Vector3D.Normalize(targetPos - playerPos);
            var offsetStart = playerPos + dirToTarg * lineOffset;
            var offsetEnd = offsetStart + dirToTarg * lineLength;
            var color = Color.LimeGreen.ToVector4();
            
            // Draw thin connection line
            MySimpleObjectDraw.DrawLine(offsetStart, offsetEnd, line, ref color, 0.8f, VRageRender.MyBillboard.BlendTypeEnum.AdditiveTop);
        }
        
        private static void DrawSharedLine(Vector3D targetPos, Vector3D playerPos, Vector4 color, float thickness, bool isStrategicMark = false)
        {
            var distToTarg = Vector3D.Distance(playerPos, targetPos);
            var lineLength = Math.Min(distToTarg * 0.8f, 1000f); // Use 80% of distance, max 1km
            var lineOffset = Math.Min(distToTarg * 0.1f, 50f); // Start 10% away from player
            
            if (lineLength <= lineOffset || distToTarg < 10) // Don't draw if too close
                return;
                
            var dirToTarg = Vector3D.Normalize(targetPos - playerPos);
            var offsetStart = playerPos + dirToTarg * lineOffset;
            var offsetEnd = offsetStart + dirToTarg * lineLength;
            
            // For strategic marks, make the line blink and be brighter
            if (isStrategicMark)
            {
                // Create a blinking effect using sine wave
                float blinkIntensity = 0.5f + 0.5f * (float)Math.Sin(updateCounter * 0.15f); // Faster blinking
                
                // Make the line brighter by increasing the color values
                color = new Vector4(
                    Math.Min(1.0f, color.X * 1.5f * blinkIntensity),
                    Math.Min(1.0f, color.Y * 1.5f * blinkIntensity),
                    Math.Min(1.0f, color.Z * 1.2f * blinkIntensity),
                    blinkIntensity // Vary the alpha for additional blinking effect
                );
                
                // Draw multiple lines for a thicker, more prominent effect
                MySimpleObjectDraw.DrawLine(offsetStart, offsetEnd, line, ref color, thickness * 1.5f, VRageRender.MyBillboard.BlendTypeEnum.AdditiveTop);
                
                // Add a second, slightly offset line for glow effect
                var glowColor = new Vector4(color.X * 0.7f, color.Y * 0.7f, color.Z * 0.5f, color.W * 0.5f);
                MySimpleObjectDraw.DrawLine(offsetStart, offsetEnd, line, ref glowColor, thickness * 2.5f, VRageRender.MyBillboard.BlendTypeEnum.AdditiveTop);
            }
            else
            {
                // Draw connection line with specified color and thickness (original behavior)
                MySimpleObjectDraw.DrawLine(offsetStart, offsetEnd, line, ref color, thickness, VRageRender.MyBillboard.BlendTypeEnum.AdditiveTop);
            }
        }
        
        private static void DrawLabel(DatalinkSignature signature, Vector3D position, Vector3D playerPos, Vector2D labelPosition, Color color)
        {
            var distance = Vector3D.Distance(position, playerPos);
            var info = new StringBuilder($"<color={color.R}, {color.G}, {color.B}>");
            
            if (signature.IsDatalink)
            {
                // Regular datalink contact
                info.AppendLine($"  {signature.GridName}");
                info.AppendLine($"  {(distance > 1000 ? (distance / 1000).ToString("0.0") + " km" : (int)distance + " m")}");
                info.AppendLine($"  Signal: {signature.SignalStrength:P0}");
            }
            else
            {
                // Shared focus target from allied grid
                info.AppendLine($"  [SHARED TARGET]");
                info.AppendLine($"  {signature.TargetName}");
                info.AppendLine($"  Focused by: {signature.SourceGrid}");
                info.AppendLine($"  {(distance > 1000 ? (distance / 1000).ToString("0.0") + " km" : (int)distance + " m")}");
            }
            
            var label = new HudAPIv2.HUDMessage(info, labelPosition, null, 2, 1, true, true);
            label.Visible = true;
        }
        
        private static void UpdateBasicNotifications(List<DatalinkSignature> allSignatures, float primaryFrequency, int totalFrequencyGroups)
        {
            if (allSignatures.Count > 0 && hudEnabled && updateCounter % 300 == 0) // Every 5 seconds
            {
                var sb = new StringBuilder($"Tactical Datalink ({primaryFrequency:F1} MHz):\n");
                if (totalFrequencyGroups > 1)
                {
                    sb.AppendLine($"({totalFrequencyGroups} frequencies active)");
                }
                
                var datalinkContacts = allSignatures.Where(s => s.IsDatalink).OrderBy(s => s.Distance).Take(2).ToList();
                var strategicMarks = allSignatures.Where(s => !s.IsDatalink && s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).Take(2).ToList();
                var sharedTargets = allSignatures.Where(s => !s.IsDatalink && !s.GridName.StartsWith("[MARK]")).OrderBy(s => s.Distance).Take(2).ToList();
                
                foreach (var signature in datalinkContacts)
                {
                    var dispRange = signature.Distance > 1000 ? 
                        (signature.Distance / 1000).ToString("0.#") + "km" : 
                        signature.Distance.ToString("0.#") + "m";
                    
                    var strengthIcon = signature.SignalStrength > 0.7f ? "●" : signature.SignalStrength > 0.4f ? "◐" : "○";
                    sb.AppendLine($"{strengthIcon} {signature.GridName}: {dispRange}");
                }
                
                foreach (var mark in strategicMarks)
                {
                    var dispRange = mark.Distance > 1000 ? 
                        (mark.Distance / 1000).ToString("0.#") + "km" : 
                        mark.Distance.ToString("0.#") + "m";
                    
                    sb.AppendLine($"⭐ [MARK] {mark.TargetName}: {dispRange}");
                }
                
                foreach (var target in sharedTargets)
                {
                    var dispRange = target.Distance > 1000 ? 
                        (target.Distance / 1000).ToString("0.#") + "km" : 
                        target.Distance.ToString("0.#") + "m";
                    
                    sb.AppendLine($"◆ [SHARED] {target.TargetName}: {dispRange}");
                }
                
                // Removed notification spam - HUD API should be used instead
            }
        }



        private void SetupTerminalControls()
        {
            if (controlsSetup) return;
            controlsSetup = true;

            // Frequency slider
            var frequencySlider = MyAPIGateway.TerminalControls.CreateControl<IMyTerminalControlSlider, IMyConveyorSorter>("LXN_DatalinkFrequency");
            frequencySlider.Title = MyStringId.GetOrCompute("Datalink Frequency");
            frequencySlider.Tooltip = MyStringId.GetOrCompute("Set the datalink communication frequency (MHz)");
            frequencySlider.SetLimits(118.0f, 136.0f);
            frequencySlider.Visible = (block) => block.BlockDefinition.SubtypeId == "LXN_DatalinkPod_01";
            frequencySlider.Getter = (block) => GetDatalinkComponent(block)?.Frequency ?? 121.5f;
            frequencySlider.Setter = (block, value) => { var comp = GetDatalinkComponent(block); if (comp != null) comp.Frequency = value; };
            frequencySlider.Writer = (block, result) =>
            {
                var freq = GetDatalinkComponent(block)?.Frequency ?? 121.5f;
                result.Append($"{freq:F1} MHz");
            };
            MyAPIGateway.TerminalControls.AddControl<IMyConveyorSorter>(frequencySlider);

            // Range slider
            var rangeSlider = MyAPIGateway.TerminalControls.CreateControl<IMyTerminalControlSlider, IMyConveyorSorter>("LXN_DatalinkRange");
            rangeSlider.Title = MyStringId.GetOrCompute("Datalink Range");
            rangeSlider.Tooltip = MyStringId.GetOrCompute("Set the maximum datalink communication range");
            rangeSlider.SetLimits(1000f, 100000f);
            rangeSlider.Visible = (block) => block.BlockDefinition.SubtypeId == "LXN_DatalinkPod_01";
            rangeSlider.Getter = (block) => GetDatalinkComponent(block)?.Range ?? 50000f;
            rangeSlider.Setter = (block, value) => { var comp = GetDatalinkComponent(block); if (comp != null) comp.Range = value; };
            rangeSlider.Writer = (block, result) =>
            {
                var range = GetDatalinkComponent(block)?.Range ?? 50000f;
                result.Append($"{range / 1000f:F1} km");
            };
            MyAPIGateway.TerminalControls.AddControl<IMyConveyorSorter>(rangeSlider);
        }

        private static DatalinkPodComponent GetDatalinkComponent(IMyTerminalBlock block)
        {
            return allDatalinks.FirstOrDefault(d => d.terminalBlock == block);
        }

        public Vector3D GetPosition() => Entity.PositionComp.GetPosition();
        public string GetGridName() => conveyorSorter?.CubeGrid?.DisplayName ?? "Unknown";
        public bool IsActive => functionalBlock?.IsWorking == true && functionalBlock?.IsFunctional == true;

        public override void Close()
        {
            if (terminalBlock != null)
            {
                terminalBlock.AppendingCustomInfo -= AppendCustomInfo;
            }
            
            allDatalinks.Remove(this);
            
            // Remove chat handler and cleanup HUD if this was the last datalink
            if (allDatalinks.Count == 0)
            {
                staticSystemInitialized = false;
                MyAPIGateway.Utilities.MessageEntered -= OnMessageEntered;
                CleanupHudAPI();
            }
            
            base.Close();
        }

        private static void CleanupHudAPI()
        {
            try
            {
                if (contactDisplay != null)
                {
                    contactDisplay.DeleteMessage();
                    contactDisplay = null;
                }
                
                if (hudAPI != null)
                {
                    hudAPI.Close();
                    hudAPI = null;
                }
                
                if (wcAPI != null)
                {
                    wcAPI.Unload();
                    wcAPI = null;
                }
                
                // Reset frequency override and clear strategic marks
                overrideFrequency = null;
                allStrategicMarks.Clear();
            }
            catch (Exception ex)
            {
                // Silent fail
            }
        }
    }

    public class DatalinkSignature
    {
        public Vector3D Position { get; set; }
        public string GridName { get; set; }
        public double Distance { get; set; }
        public float SignalStrength { get; set; }
        public bool IsDatalink { get; set; } = true; // True for datalink contacts, false for focus targets
        public string SourceGrid { get; set; } // Which grid is reporting this (for focus targets)
        public string TargetName { get; set; } // Name of the focused target
    }

    public class StrategicMark
    {
        public Vector3D Position { get; set; }
        public string MarkedBy { get; set; } // Grid name that placed the mark
        public DateTime TimeStamp { get; set; }
        public float Frequency { get; set; } // Frequency this mark was placed on
        public string Label { get; set; } // Optional label for the mark
        public bool IsExpired => (DateTime.UtcNow - TimeStamp).TotalSeconds > 300; // 5 minute expiration
    }
}