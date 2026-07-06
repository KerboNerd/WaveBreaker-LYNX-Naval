using System.Collections.Generic;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AnimationDef;
using static Scripts.Structure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove;
namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AnimationDef MK112_Animation => new AnimationDef
        {


            AnimationSets = new[]
            {
				#region Muzzles Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher1"),
                    BarrelId = "muzzle_missile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch1"),
                    BarrelId = "muzzle_missile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch1"),
                    BarrelId = "muzzle_missile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                
                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher2"),
                    BarrelId = "muzzle_missile_2", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch2"),
                    BarrelId = "muzzle_missile_2", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch2"),
                    BarrelId = "muzzle_missile_2", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher1"),
                    BarrelId = "muzzle_missile_5", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch5"),
                    BarrelId = "muzzle_missile_5", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch5"),
                    BarrelId = "muzzle_missile_5", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher2"),
                    BarrelId = "muzzle_missile_6", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch6"),
                    BarrelId = "muzzle_missile_6", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch6"),
                    BarrelId = "muzzle_missile_6", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher3"),
                    BarrelId = "muzzle_missile_3", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch3"),
                    BarrelId = "muzzle_missile_3", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch3"),
                    BarrelId = "muzzle_missile_3", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher3"),
                    BarrelId = "muzzle_missile_7", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch7"),
                    BarrelId = "muzzle_missile_7", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch7"),
                    BarrelId = "muzzle_missile_7", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher4"),
                    BarrelId = "muzzle_missile_4", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch4"),
                    BarrelId = "muzzle_missile_4", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch4"),
                    BarrelId = "muzzle_missile_4", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("Launcher4"),
                    BarrelId = "muzzle_missile_8", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(45, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-1, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(-44, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_LeftHatch8"),
                    BarrelId = "muzzle_missile_8", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("L_RightHatch8"),
                    BarrelId = "muzzle_missile_8", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 60,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [PreFire] =
                            new[]
                            {
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 90, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },

                            },
                        [Firing] =
                            new[]
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -1, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, -89, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },

                    }

                },
				#endregion


            },

        };
    }
}