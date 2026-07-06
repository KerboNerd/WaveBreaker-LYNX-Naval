using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AmmoDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EjectionDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EjectionDef.SpawnType;
using static Scripts.Structure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static Scripts.Structure.WeaponDefinition.AmmoDef.DamageScaleDef.CustomScalesDef.SkipMode;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.FragmentDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.PatternDef.PatternModes;
using static Scripts.Structure.WeaponDefinition.AmmoDef.FragmentDef.TimedSpawnDef.PointTypes;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.Conditions;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.UpRelativeTo;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.FwdRelativeTo;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.ReInitCondition;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.RelativeTo;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.ConditionOperators;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef.StageEvents;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.ApproachDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static Scripts.Structure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static Scripts.Structure.WeaponDefinition.AmmoDef.DamageScaleDef.DeformDef.DeformTypes;
using static Scripts.Structure.WeaponDefinition.AmmoDef.AreaOfDamageDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.AreaOfDamageDef.Falloff;
using static Scripts.Structure.WeaponDefinition.AmmoDef.AreaOfDamageDef.AoeShape;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EwarDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EwarDef.EwarMode;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EwarDef.EwarType;
using static Scripts.Structure.WeaponDefinition.AmmoDef.EwarDef.PushPullDef.Force;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.FactionColor;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.TracerBaseDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.Texture;
using static Scripts.Structure.WeaponDefinition.AmmoDef.GraphicDef.DecalDef;
using static Scripts.Structure.WeaponDefinition.AmmoDef.DamageScaleDef.DamageTypes.Damage;


namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AmmoDef TTRUR5ASROC_launch => new AmmoDef // Your ID, for slotting into the Weapon CS
        {
            AmmoMagazine = "TTMK44_Torpedo", // SubtypeId of physical ammo magazine. Use "Energy" for weapons without physical ammo.
            AmmoRound = "RUR5ASROC", // Name of ammo in terminal, should be different for each ammo type used by the same weapon. Is used by Shrapnel.
            HybridRound = false, // Use both a physical ammo magazine and energy per shot.
            EnergyCost = 0.4f, // Scaler for energy per shot (EnergyCost * BaseDamage * (RateOfFire / 3600) * BarrelsPerShot * TrajectilesPerBarrel). Uses EffectStrength instead of BaseDamage if EWAR.
            BaseDamage = 1f, // Direct damage; one steel plate is worth 100.
            Mass = 113f, // In kilograms; how much force the impact will apply to the target.
            Health = 0, // How much damage the projectile can take from other projectiles (base of 1 per hit) before dying; 0 disables this and makes the projectile untargetable.
            BackKickForce = 45000f, // Recoil. This is applied to the Parent Grid.
            DecayPerShot = 0f, // Damage to the firing weapon itself.
			       //float.MaxValue will drop the weapon to the first build state and destroy all components used for construction
			       //If greater than cube integrity it will remove the cube upon firing, without causing deformation (makes it look like the whole "block" flew away)
            HardPointUsable = true, // Whether this is a primary ammo type fired directly by the turret. Set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
            EnergyMagazineSize = 0, // For energy weapons, how many shots to fire before reloading.
            IgnoreWater = true, // Whether the projectile should be able to penetrate water when using WaterMod.
            IgnoreVoxels = false, // Whether the projectile should be able to penetrate voxels.
            Synchronize = false, // For future use
            HeatModifier = 0f, // Allows this ammo to modify the amount of heat the weapon produces per shot.
            Shape = new ShapeDef // Defines the collision shape of the projectile, defaults to LineShape and uses the visual Line Length if set to 0.
            {
                Shape = LineShape, // LineShape or SphereShape. Do not use SphereShape for fast moving projectiles if you care about precision.
                Diameter = 1, // Diameter is minimum length of LineShape or minimum diameter of SphereShape.
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // Limits the number of entities (grids, players, projectiles) the projectile can penetrate; 0 = unlimited.
                CountBlocks = false, // Counts individual blocks, not just entities hit.
            },
            Fragment = new FragmentDef // Formerly known as Shrapnel. Spawns specified ammo fragments on projectile death (via hit or detonation).
            {
                AmmoRound = "RUR5ASROC DepthCharge", // AmmoRound field of the ammo to spawn.
                Fragments = 1, // Number of projectiles to spawn.
                Degrees = 0, // Cone in which to randomize direction of spawned projectiles.
                Reverse = false, // Spawn projectiles backward instead of forward.
                DropVelocity = true, // fragments will not inherit velocity from parent.
                Offset = 0f, // Offsets the fragment spawn by this amount, in meters (positive forward, negative for backwards), value is read from parent ammo type.
                Radial = 0f, // Determines starting angle for Degrees of spread above.  IE, 0 degrees and 90 radial goes perpendicular to travel path
                MaxChildren = 0, // number of maximum branches for fragments from the roots point of view, 0 is unlimited
                IgnoreArming = false, // If true, ignore ArmOnHit or MinArmingTime in EndOfLife definitions
                AdvOffset = Vector(x: 0, y: 0, z: 0), // advanced offsets the fragment by xyz coordinates relative to parent, value is read from fragment ammo type.
                TimedSpawns = new TimedSpawnDef // disables FragOnEnd in favor of info specified below
                {
                    Enable = false, // Enables TimedSpawns mechanism
                    Interval = 0, // Time between spawning fragments, in ticks, 0 means every tick, 1 means every other
                    StartTime = 0, // Time delay to start spawning fragments, in ticks, of total projectile life
                    MaxSpawns = 1, // Max number of fragment children to spawn
                    Proximity = 500, // Starting distance from target bounding sphere to start spawning fragments, 0 disables this feature.  No spawning outside this distance
                    ParentDies = true, // Parent dies once after it spawns its last child.
                    PointAtTarget = true, // Start fragment direction pointing at Target
                    PointType = Predict, // Point accuracy, Direct (straight forward), Lead (always fire), Predict (only fire if it can hit)
                    DirectAimCone = 0f, //Aim cone used for Direct fire, in degrees
                    GroupSize = 5, // Number of spawns in each group
                    GroupDelay = 120, // Delay between each group.
                },
            },
            Pattern = new PatternDef
            {
                Patterns = new[] { // If enabled, set of multiple ammos to fire in order instead of the main ammo.
                    "",
                },
                Mode = Never, // Select when to activate this pattern, options: Never, Weapon, Fragment, Both
                TriggerChance = 1f, // This is %
                Random = false, // This randomizes the number spawned at once, NOT the list order.
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false, // Skip the Ammo itself, in the list
                PatternSteps = 1, // Number of Ammos activated per round, will progress in order and loop. Ignored if Random = true.
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // Blocks with integrity higher than this value will be immune to damage from this projectile; 0 = disabled.
                DamageVoxels = false, // Whether to damage voxels.
                SelfDamage = false, // Whether to damage the weapon's own grid.
                HealthHitModifier = 0.1, // How much Health to subtract from another projectile on hit; defaults to 1 if zero or less.
                VoxelHitModifier = 2, // Voxel damage multiplier; defaults to 1 if zero or less.
                Characters = 0.1f, // Character damage multiplier; defaults to 1 if zero or less.
                // For the following modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01f = 1% damage, 2 = 200% damage.
                FallOff = new FallOffDef
                {
                    Distance = 5000f, // Distance at which damage begins falling off.
                    MinMultipler = -1f, // Value from 0.0001f to 1f where 0.1f would be a min damage of 10% of base damage.
                },
                Grids = new GridSizeDef
                {
                    Large = 1.2f, // Multiplier for damage against large grids.
                    Small = 0.6f, // Multiplier for damage against small grids.
                },
                Armor = new ArmorDef
                {
                    Armor = -1f, // Multiplier for damage against all armor. This is multiplied with the specific armor type multiplier (light, heavy).
                    Light = 0.6f, // Multiplier for damage against light armor.
                    Heavy = 0.9f, // Multiplier for damage against heavy armor.
                    NonArmor = 0.9f, // Multiplier for damage against every else.
                },
                Shields = new ShieldDef
                {
                    Modifier = 3f, // Multiplier for damage against shields.
                    Type = Default, // Damage vs healing against shields; Default, Heal
                    BypassModifier = -1f, // If greater than zero, the percentage of damage that will penetrate the shield.
                },
                DamageType = new DamageTypes // Damage type of each element of the projectile's damage; Kinetic, Energy
                {
                    Base = Kinetic, // Base Damage uses this
                    AreaEffect = Kinetic,
                    Detonation = Kinetic,
                    Shield = Kinetic, // Damage against shields is currently all of one type per projectile. Shield Bypass Weapons, always Deal Energy regardless of this line
                },
                Custom = new CustomScalesDef
                {
                    SkipOthers = NoSkip, // Controls how projectile interacts with other blocks in relation to those defined here, NoSkip, Exclusive, Inclusive.
                    Types = new[] // List of blocks to apply custom damage multipliers to.
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaOfDamage = new AreaOfDamageDef
            {
                ByBlockHit = new ByBlockHitDef
                {
                    Enable = false,
                    Radius = 2.5f, // Meters
                    Damage = 2750f,
                    Depth = 2.5f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
                    MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
                    Falloff = Curve, //.NoFalloff applies the same damage to all blocks in radius
                    //.Linear drops evenly by distance from center out to max radius
                    //.Curve drops off damage sharply as it approaches the max radius
                    //.InvCurve drops off sharply from the middle and tapers to max radius
                    //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                    //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    //.Exponential drops off exponentially.  Does not scale to max radius
                    Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
                },
                EndOfLife = new EndOfLifeDef
                {
                    Enable = false,
                    Radius = 3f, // Radius of AOE effect, in meters.
                    Damage = 2500f,
                    Depth = 2f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
                    MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
                    Falloff = InvCurve, //.NoFalloff applies the same damage to all blocks in radius
                    //.Linear drops evenly by distance from center out to max radius
                    //.Curve drops off damage sharply as it approaches the max radius
                    //.InvCurve drops off sharply from the middle and tapers to max radius
                    //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                    //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    //.Exponential drops off exponentially.  Does not scale to max radius
                    ArmOnlyOnHit = false, // Detonation only is available, After it hits something, when this is true. IE, if shot down, it won't explode.
                    MinArmingTime = 0, // In ticks, before the Ammo is allowed to explode, detonate or similar; This affects shrapnel spawning.
                    NoVisuals = false,
                    NoSound = false,
                    ParticleScale = 0.5f,
                    CustomParticle = "SmallArtExplosionLight", // Particle SubtypeID, from your Particle SBC
                    CustomSound = "ArcWepSmallMissileExpl", // SubtypeID from your Audio SBC, not a filename
                    Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
                },
            },
            Ewar = new EwarDef
            {
                Enable = false, // Enables EWAR effects AND DISABLES BASE DAMAGE AND AOE DAMAGE!!
                Type = EnergySink, // EnergySink, Emp, Offense, Nav, Dot, AntiSmart, JumpNull, Anchor, Tractor, Pull, Push,
                Mode = Effect, // Effect , Field
                Strength = 100f,
                Radius = 5f, // Meters
                Duration = 100, // In Ticks
                StackDuration = true, // Combined Durations
                Depletable = true,
                MaxStacks = 10, // Max Debuffs at once
                NoHitParticle = false,
                /*
                EnergySink : Targets & Shutdowns Power Supplies, such as Batteries & Reactor
                Emp : Targets & Shutdown any Block capable of being powered
                Offense : Targets & Shutdowns Weaponry
                Nav : Targets & Shutdown Gyros or Locks them down
                Dot : Deals Damage to Blocks in radius
                AntiSmart : Effects & Scrambles the Targeting List of Affected Missiles
                JumpNull : Shutdown & Stops any Active Jumps, or JumpDrive Units in radius
                Tractor : Affects target with Physics
                Pull : Affects target with Physics
                Push : Affects target with Physics
                Anchor : Targets & Shutdowns Thrusters

                */
                Force = new PushPullDef
                {
                    ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    DisableRelativeMass = false,
                    TractorRange = 0,
                    ShooterFeelsForce = false,
                },
                Field = new FieldDef
                {
                    Interval = 0, // Time between each pulse, in game ticks (60 == 1 second), starts at 0 (59 == tick 60).
                    PulseChance = 0, // Chance from 0 - 100 that an entity in the field will be hit by any given pulse.
                    GrowTime = 0, // How many ticks it should take the field to grow to full size.
                    HideModel = false, // Hide the default bubble, or other model if specified.
                    ShowParticle = true, // Show Block damage effect.
                    TriggerRange = 250f, //range at which fields are triggered
                    Particle = new ParticleDef // Particle effect to generate at the field's position.
                    {
                        Name = "", // SubtypeId of field particle effect.
                        Extras = new ParticleOptionDef
                        {
                            Scale = 1, // Scale of effect.
                        },
                    },
                },
            },
            Beams = new BeamDef
            {
                Enable = false, // Enable beam behaviour. Please have 3600 RPM, when this Setting is enabled. Please do not fire Beams into Voxels.
                VirtualBeams = false, // Only one damaging beam, but with the effectiveness of the visual beams combined (better performance).
                ConvergeBeams = false, // When using virtual beams, converge the visual beams to the location of the real beam.
                RotateRealBeam = false, // The real beam is rotated between all visual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = Smart, // None, Remote, TravelTo, Smart, DetectTravelTo, DetectSmart, DetectFixed
                TargetLossDegree = 0f, // Degrees, Is pointed forward
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 60, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..). time begins at 0 and time must EXCEED this value to trigger "time > maxValue". Please have a value for this, It stops Bad things.
                AccelPerSec = 0f, // Meters Per Second. This is the spawning Speed of the Projectile, and used by turning.
                DesiredSpeed = 300, // voxel phasing if you go above 5100
                MaxTrajectory = 20000f, // Max Distance the projectile or beam can Travel.
                DeaccelTime = 0, // 0 is disabled, a value causes the projectile to come to rest overtime, (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable. Natural Gravity Only.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed. Be warned, you can make your projectile go backwards.
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 60, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoint's.
                    CheckFutureIntersection = false, // Utilize obstacle avoidance for drones
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                    KeepAliveAfterTargetLoss = false, // Whether to stop early death of projectile on target loss
                    OffsetRatio = 0.05f, // The ratio to offset the random direction (0 to 1)
                    OffsetTime = 60, // how often to offset degree, measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..)
                },
                Mines = new MinesDef  // Note: This is being investigated. Please report to Github, any issues.
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "\\Models\\Ammo\\TTMK44L.mwm", // Model Path goes here.  "\\Models\\Ammo\\Starcore_Arrow_Missile_Large"
                VisualProbability = 1f, // %
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "ussr_missile_trail", //ShipWelderArc
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 2000,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "MaterialHit_Metal",
                        ApplyToShield = true,
                        Color = Color(red: 3, green: 2, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 1,
                            Scale = 1,
                            HitPlayChance = 0.1f,
                        },
                    },
                    Eject = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = true,
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 3f, //
                        Width = 0.50f, //
                        Color = Color(red: 80f, green: 30f, blue: 10f, alpha: 1), // RBG 255 is Neon Glowing, 100 is Quite Bright.
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "ProjectileTrailLine", // Please always have this Line set, if this Section is enabled.
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "ProjectileTrailLine", // Please always have this Line set, if this Section is enabled.
                            },
                            SegmentLength = 5f, // Uses the values below.
                            SegmentGap = 1f, // Uses Tracer textures and values
                            Speed = 15f, // meters per second
                            Color = Color(red: 25f, green: 9f, blue: 0f, alpha: 1),
                            WidthMultiplier = 1f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: 0f, end: 0f),
                            ColorVariance = Random(start: 0f, end: 0f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Textures = new[] {
                            "WarpBubble", // Please always have this Line set, if this Section is enabled.
                        },
                        TextureMode = Normal,
                        DecayTime = 2, // In Ticks. 1 = 1 Additional Tracer generated per motion, 33 is 33 lines drawn per projectile. Keep this number low.
                        Color = Color(red: 24f, green: 24.8f, blue: 25.5f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.2f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.1f,
                        MaxLength = 0.2f,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "", // SubtypeID for your Sound File. Travel, is sound generated around your Projectile in flight
                HitSound = "",
                ShotSound = "",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            },
            Ejection = new EjectionDef // Optional Component, allows generation of Particle or Item (Typically magazine), on firing, to simulate Tank shell ejection
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemName = "", //InventoryComponent name
                    ItemLifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            }, // Don't edit below this line
        };

        private AmmoDef TTRUR5ASROC_Deptharge => new AmmoDef // Your ID, for slotting into the Weapon CS
        {
            AmmoMagazine = "Energy", // SubtypeId of physical ammo magazine. Use "Energy" for weapons without physical ammo.
            AmmoRound = "RUR5ASROC DepthCharge", // Name of ammo in terminal, should be different for each ammo type used by the same weapon. Is used by Shrapnel.
            HybridRound = false, // Use both a physical ammo magazine and energy per shot.
            EnergyCost = 0.4f, // Scaler for energy per shot (EnergyCost * BaseDamage * (RateOfFire / 3600) * BarrelsPerShot * TrajectilesPerBarrel). Uses EffectStrength instead of BaseDamage if EWAR.
            BaseDamage = 1f, // Direct damage; one steel plate is worth 100.
            Mass = 113f, // In kilograms; how much force the impact will apply to the target.
            Health = 1, // How much damage the projectile can take from other projectiles (base of 1 per hit) before dying; 0 disables this and makes the projectile untargetable.
            BackKickForce = 45000f, // Recoil. This is applied to the Parent Grid.
            DecayPerShot = 0f, // Damage to the firing weapon itself.
			       //float.MaxValue will drop the weapon to the first build state and destroy all components used for construction
			       //If greater than cube integrity it will remove the cube upon firing, without causing deformation (makes it look like the whole "block" flew away)
            HardPointUsable = false, // Whether this is a primary ammo type fired directly by the turret. Set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
            EnergyMagazineSize = 0, // For energy weapons, how many shots to fire before reloading.
            IgnoreWater = false, // Whether the projectile should be able to penetrate water when using WaterMod.
            IgnoreVoxels = false, // Whether the projectile should be able to penetrate voxels.
            Synchronize = false, // For future use
            HeatModifier = 0f, // Allows this ammo to modify the amount of heat the weapon produces per shot.
            Shape = new ShapeDef // Defines the collision shape of the projectile, defaults to LineShape and uses the visual Line Length if set to 0.
            {
                Shape = LineShape, // LineShape or SphereShape. Do not use SphereShape for fast moving projectiles if you care about precision.
                Diameter = 1, // Diameter is minimum length of LineShape or minimum diameter of SphereShape.
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // Limits the number of entities (grids, players, projectiles) the projectile can penetrate; 0 = unlimited.
                CountBlocks = false, // Counts individual blocks, not just entities hit.
            },
            Fragment = new FragmentDef // Formerly known as Shrapnel. Spawns specified ammo fragments on projectile death (via hit or detonation).
            {
                AmmoRound = "RUR5ASROCWater", // AmmoRound field of the ammo to spawn.
                Fragments = 1, // Number of projectiles to spawn.
                Degrees = 0, // Cone in which to randomize direction of spawned projectiles.
                Reverse = false, // Spawn projectiles backward instead of forward.
                DropVelocity = true, // fragments will not inherit velocity from parent.
                Offset = 0f, // Offsets the fragment spawn by this amount, in meters (positive forward, negative for backwards), value is read from parent ammo type.
                Radial = 0f, // Determines starting angle for Degrees of spread above.  IE, 0 degrees and 90 radial goes perpendicular to travel path
                MaxChildren = 0, // number of maximum branches for fragments from the roots point of view, 0 is unlimited
                IgnoreArming = false, // If true, ignore ArmOnHit or MinArmingTime in EndOfLife definitions
                AdvOffset = Vector(x: 0, y: 0, z: 0), // advanced offsets the fragment by xyz coordinates relative to parent, value is read from fragment ammo type.
                TimedSpawns = new TimedSpawnDef // disables FragOnEnd in favor of info specified below
                {
                    Enable = false, // Enables TimedSpawns mechanism
                    Interval = 0, // Time between spawning fragments, in ticks, 0 means every tick, 1 means every other
                    StartTime = 0, // Time delay to start spawning fragments, in ticks, of total projectile life
                    MaxSpawns = 1, // Max number of fragment children to spawn
                    Proximity = 500, // Starting distance from target bounding sphere to start spawning fragments, 0 disables this feature.  No spawning outside this distance
                    ParentDies = true, // Parent dies once after it spawns its last child.
                    PointAtTarget = true, // Start fragment direction pointing at Target
                    PointType = Predict, // Point accuracy, Direct (straight forward), Lead (always fire), Predict (only fire if it can hit)
                    DirectAimCone = 0f, //Aim cone used for Direct fire, in degrees
                    GroupSize = 5, // Number of spawns in each group
                    GroupDelay = 120, // Delay between each group.
                },
            },
            Pattern = new PatternDef
            {
                Patterns = new[] { // If enabled, set of multiple ammos to fire in order instead of the main ammo.
                    "",
                },
                Mode = Never, // Select when to activate this pattern, options: Never, Weapon, Fragment, Both
                TriggerChance = 1f, // This is %
                Random = false, // This randomizes the number spawned at once, NOT the list order.
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false, // Skip the Ammo itself, in the list
                PatternSteps = 1, // Number of Ammos activated per round, will progress in order and loop. Ignored if Random = true.
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // Blocks with integrity higher than this value will be immune to damage from this projectile; 0 = disabled.
                DamageVoxels = false, // Whether to damage voxels.
                SelfDamage = false, // Whether to damage the weapon's own grid.
                HealthHitModifier = 0.1, // How much Health to subtract from another projectile on hit; defaults to 1 if zero or less.
                VoxelHitModifier = 2, // Voxel damage multiplier; defaults to 1 if zero or less.
                Characters = 0.1f, // Character damage multiplier; defaults to 1 if zero or less.
                // For the following modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01f = 1% damage, 2 = 200% damage.
                FallOff = new FallOffDef
                {
                    Distance = 5000f, // Distance at which damage begins falling off.
                    MinMultipler = -1f, // Value from 0.0001f to 1f where 0.1f would be a min damage of 10% of base damage.
                },
                Grids = new GridSizeDef
                {
                    Large = 1.2f, // Multiplier for damage against large grids.
                    Small = 0.6f, // Multiplier for damage against small grids.
                },
                Armor = new ArmorDef
                {
                    Armor = -1f, // Multiplier for damage against all armor. This is multiplied with the specific armor type multiplier (light, heavy).
                    Light = 0.6f, // Multiplier for damage against light armor.
                    Heavy = 0.9f, // Multiplier for damage against heavy armor.
                    NonArmor = 0.9f, // Multiplier for damage against every else.
                },
                Shields = new ShieldDef
                {
                    Modifier = 3f, // Multiplier for damage against shields.
                    Type = Default, // Damage vs healing against shields; Default, Heal
                    BypassModifier = -1f, // If greater than zero, the percentage of damage that will penetrate the shield.
                },
                DamageType = new DamageTypes // Damage type of each element of the projectile's damage; Kinetic, Energy
                {
                    Base = Kinetic, // Base Damage uses this
                    AreaEffect = Kinetic,
                    Detonation = Kinetic,
                    Shield = Kinetic, // Damage against shields is currently all of one type per projectile. Shield Bypass Weapons, always Deal Energy regardless of this line
                },
                Custom = new CustomScalesDef
                {
                    SkipOthers = NoSkip, // Controls how projectile interacts with other blocks in relation to those defined here, NoSkip, Exclusive, Inclusive.
                    Types = new[] // List of blocks to apply custom damage multipliers to.
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaOfDamage = new AreaOfDamageDef
            {
                ByBlockHit = new ByBlockHitDef
                {
                    Enable = false,
                    Radius = 2.5f, // Meters
                    Damage = 2750f,
                    Depth = 2.5f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
                    MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
                    Falloff = Curve, //.NoFalloff applies the same damage to all blocks in radius
                    //.Linear drops evenly by distance from center out to max radius
                    //.Curve drops off damage sharply as it approaches the max radius
                    //.InvCurve drops off sharply from the middle and tapers to max radius
                    //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                    //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    //.Exponential drops off exponentially.  Does not scale to max radius
                    Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
                },
                EndOfLife = new EndOfLifeDef
                {
                    Enable = true,
                    Radius = 1f, // Radius of AOE effect, in meters.
                    Damage = 1f,
                    Depth = 1f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
                    MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
                    Falloff = InvCurve, //.NoFalloff applies the same damage to all blocks in radius
                    //.Linear drops evenly by distance from center out to max radius
                    //.Curve drops off damage sharply as it approaches the max radius
                    //.InvCurve drops off sharply from the middle and tapers to max radius
                    //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                    //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    //.Exponential drops off exponentially.  Does not scale to max radius
                    ArmOnlyOnHit = true, // Detonation only is available, After it hits something, when this is true. IE, if shot down, it won't explode.
                    MinArmingTime = 120, // In ticks, before the Ammo is allowed to explode, detonate or similar; This affects shrapnel spawning.
                    NoVisuals = false,
                    NoSound = false,
                    ParticleScale = 0.5f,
                    CustomParticle = "SmallArtExplosionLight", // Particle SubtypeID, from your Particle SBC
                    CustomSound = "ArcWepSmallMissileExpl", // SubtypeID from your Audio SBC, not a filename
                    Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
                },
            },
            Ewar = new EwarDef
            {
                Enable = false, // Enables EWAR effects AND DISABLES BASE DAMAGE AND AOE DAMAGE!!
                Type = EnergySink, // EnergySink, Emp, Offense, Nav, Dot, AntiSmart, JumpNull, Anchor, Tractor, Pull, Push,
                Mode = Effect, // Effect , Field
                Strength = 100f,
                Radius = 5f, // Meters
                Duration = 100, // In Ticks
                StackDuration = true, // Combined Durations
                Depletable = true,
                MaxStacks = 10, // Max Debuffs at once
                NoHitParticle = false,
                /*
                EnergySink : Targets & Shutdowns Power Supplies, such as Batteries & Reactor
                Emp : Targets & Shutdown any Block capable of being powered
                Offense : Targets & Shutdowns Weaponry
                Nav : Targets & Shutdown Gyros or Locks them down
                Dot : Deals Damage to Blocks in radius
                AntiSmart : Effects & Scrambles the Targeting List of Affected Missiles
                JumpNull : Shutdown & Stops any Active Jumps, or JumpDrive Units in radius
                Tractor : Affects target with Physics
                Pull : Affects target with Physics
                Push : Affects target with Physics
                Anchor : Targets & Shutdowns Thrusters

                */
                Force = new PushPullDef
                {
                    ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    DisableRelativeMass = false,
                    TractorRange = 0,
                    ShooterFeelsForce = false,
                },
                Field = new FieldDef
                {
                    Interval = 0, // Time between each pulse, in game ticks (60 == 1 second), starts at 0 (59 == tick 60).
                    PulseChance = 0, // Chance from 0 - 100 that an entity in the field will be hit by any given pulse.
                    GrowTime = 0, // How many ticks it should take the field to grow to full size.
                    HideModel = false, // Hide the default bubble, or other model if specified.
                    ShowParticle = true, // Show Block damage effect.
                    TriggerRange = 250f, //range at which fields are triggered
                    Particle = new ParticleDef // Particle effect to generate at the field's position.
                    {
                        Name = "", // SubtypeId of field particle effect.
                        Extras = new ParticleOptionDef
                        {
                            Scale = 1, // Scale of effect.
                        },
                    },
                },
            },
            Beams = new BeamDef
            {
                Enable = false, // Enable beam behaviour. Please have 3600 RPM, when this Setting is enabled. Please do not fire Beams into Voxels.
                VirtualBeams = false, // Only one damaging beam, but with the effectiveness of the visual beams combined (better performance).
                ConvergeBeams = false, // When using virtual beams, converge the visual beams to the location of the real beam.
                RotateRealBeam = false, // The real beam is rotated between all visual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = Smart, // None, Remote, TravelTo, Smart, DetectTravelTo, DetectSmart, DetectFixed
                TargetLossDegree = 0f, // Degrees, Is pointed forward
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 10000, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..). time begins at 0 and time must EXCEED this value to trigger "time > maxValue". Please have a value for this, It stops Bad things.
                AccelPerSec = 0f, // Meters Per Second. This is the spawning Speed of the Projectile, and used by turning.
                DesiredSpeed = 200, // voxel phasing if you go above 5100
                MaxTrajectory = 20000f, // Max Distance the projectile or beam can Travel.
                DeaccelTime = 0, // 0 is disabled, a value causes the projectile to come to rest overtime, (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable. Natural Gravity Only.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed. Be warned, you can make your projectile go backwards.
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 200, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoint's.
                    CheckFutureIntersection = false, // Utilize obstacle avoidance for drones
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                    KeepAliveAfterTargetLoss = false, // Whether to stop early death of projectile on target loss
                    OffsetRatio = 0.5f, // The ratio to offset the random direction (0 to 1)
                    OffsetTime = 60, // how often to offset degree, measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..)
                },

                Mines = new MinesDef  // Note: This is being investigated. Please report to Github, any issues.
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "\\Models\\Ammo\\TTMK44L.mwm", // Model Path goes here.  "\\Models\\Ammo\\Starcore_Arrow_Missile_Large"
                VisualProbability = 1f, // %
                ShieldHitDraw = false,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "ussr_missile_trail", //ShipWelderArc
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 4000,
                            MaxDuration = 1,
                            Scale = 0.25f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "MaterialHit_Metal",
                        ApplyToShield = true,
                        Color = Color(red: 3, green: 2, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 1,
                            Scale = 1,
                            HitPlayChance = 0.1f,
                        },
                    },
                    Eject = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = true,
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 3f, //
                        Width = 0.50f, //
                        Color = Color(red: 80f, green: 30f, blue: 10f, alpha: 1), // RBG 255 is Neon Glowing, 100 is Quite Bright.
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "ProjectileTrailLine", // Please always have this Line set, if this Section is enabled.
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "ProjectileTrailLine", // Please always have this Line set, if this Section is enabled.
                            },
                            SegmentLength = 5f, // Uses the values below.
                            SegmentGap = 1f, // Uses Tracer textures and values
                            Speed = 15f, // meters per second
                            Color = Color(red: 25f, green: 9f, blue: 0f, alpha: 1),
                            WidthMultiplier = 1f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: 0f, end: 0f),
                            ColorVariance = Random(start: 0f, end: 0f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Textures = new[] {
                            "WarpBubble", // Please always have this Line set, if this Section is enabled.
                        },
                        TextureMode = Normal,
                        DecayTime = 2, // In Ticks. 1 = 1 Additional Tracer generated per motion, 33 is 33 lines drawn per projectile. Keep this number low.
                        Color = Color(red: 24f, green: 24.8f, blue: 25.5f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.2f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.1f,
                        MaxLength = 0.2f,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "", // SubtypeID for your Sound File. Travel, is sound generated around your Projectile in flight
                HitSound = "",
                ShotSound = "",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            },
            Ejection = new EjectionDef // Optional Component, allows generation of Particle or Item (Typically magazine), on firing, to simulate Tank shell ejection
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemName = "", //InventoryComponent name
                    ItemLifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            }, // Don't edit below this line
        };

        private AmmoDef TTRUR5ASROC_Water => new AmmoDef
        {
          AmmoMagazine = "Energy",
          AmmoRound = "RUR5ASROCWater",
          HybridRound = false, //AmmoMagazine based weapon with energy cost
          EnergyCost = 0.0001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
          BaseDamage = 1500f,
          Mass = 0f, // in kilograms
          Health = 50, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
          BackKickForce = 0f,
          DecayPerShot = 0f,
        HardPointUsable = false,
          IgnoreWater = true,

          Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
          {
              Shape = LineShape,
              Diameter = 1,
          },
          ObjectsHit = new ObjectsHitDef
          {
              MaxObjectsHit = 0, // 0 = disabled
              CountBlocks = false, // counts gridBlocks and not just entities hit
          },
          Fragment = new FragmentDef // Formerly known as Shrapnel. Spawns specified ammo fragments on projectile death (via hit or detonation).
          {
              AmmoRound = "ASHM_HE_Fragment",
              Fragments = 25, // Number of projectiles to spawn.
                Degrees = 180, // Cone in which to randomize direction of spawned projectiles.
                Reverse = false, // Spawn projectiles backward instead of forward.
                DropVelocity = true, // fragments will not inherit velocity from parent.
                Offset = 0f, // Offsets the fragment spawn by this amount, in meters (positive forward, negative for backwards).
                Radial = 0f, // Determines starting angle for Degrees of spread above.  IE, 0 degrees and 90 radial goes perpendicular to travel path
                MaxChildren = 0, // number of maximum branches for fragments from the roots point of view, 0 is unlimited
                IgnoreArming = false, // If true, ignore ArmOnHit or MinArmingTime in EndOfLife definitions
                ArmWhenHit = false, // Setting this to true will arm the projectile when its shot by other projectiles.
                AdvOffset = Vector(x: 0, y: 0, z: 0), // advanced offsets the fragment by xyz coordinates relative to parent, value is read from fragment ammo type.
                TimedSpawns = new TimedSpawnDef // disables FragOnEnd in favor of info specified below, unless ArmWhenHit or Eol ArmOnlyOnHit is set to true then both kinds of frags are active
                {
                    Enable = false, // Enables TimedSpawns mechanism
                    Interval = 0, // Time between spawning fragments, in ticks, 0 means every tick, 1 means every other
                    StartTime = 0, // Time delay to start spawning fragments, in ticks, of total projectile life
                    MaxSpawns = 1, // Max number of fragment children to spawn
                    Proximity = 250, // Starting distance from target bounding sphere to start spawning fragments, 0 disables this feature.  No spawning outside this distance
                    ParentDies = true, // Parent dies once after it spawns its last child.
                    PointAtTarget = true, // Start fragment direction pointing at Target
                    PointType = Direct, // Point accuracy, Direct (straight forward), Lead (always fire), Predict (only fire if it can hit)
                    DirectAimCone = 0f, //Aim cone used for Direct fire, in degrees
                    GroupSize = 1, // Number of spawns in each group
                    GroupDelay = 0, // Delay between each group.
                },
          },
          Pattern = new PatternDef
          {
              Patterns = new[] { // If enabled, set of multiple ammos to fire in order instead of the main ammo.
                  "",
              },
              Enable = false,
              TriggerChance = 1f,
              Random = false,
              RandomMin = 1,
              RandomMax = 1,
              SkipParent = false,
          },
          DamageScales = new DamageScaleDef
          {
              MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
              DamageVoxels = false, // true = voxels are vulnerable to this weapon
              SelfDamage = false, // true = allow self damage.
              HealthHitModifier = 1, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
              // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
              VoxelHitModifier = 1,
              Characters = -1f,
            FallOff = new FallOffDef
              {
               Distance = 0f, // Distance at which max damage begins falling off.
               MinMultipler = -1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
          },
              Grids = new GridSizeDef
              {
                  Large = -1f,
                  Small = 0.1f,
              },
              Armor = new ArmorDef
              {
                  Armor = 1f,
                  Light = 1.2f,
                  Heavy = 0.8f,
                  NonArmor = 0.8f,
              },
              Shields = new ShieldDef
              {
                  Modifier = 4f,
                  Type = Default, // Damage vs healing against shields; Default, Heal
                  BypassModifier = -1f,
              },
              DamageType = new DamageTypes // Damage type of each element of the projectile's damage; Kinetic, Energy
              {
                  Base = Kinetic,
                  AreaEffect = Kinetic,
                  Detonation = Kinetic,
                  Shield = Kinetic, // Damage against shields is currently all of one type per projectile.
              },
              Custom = new CustomScalesDef
              {
                  IgnoreAllOthers = false,
                  Types = new[]
                  {
                      new CustomBlocksDef
                      {
                          SubTypeId = "LargeHeavyBlockArmorBlock",
                          Modifier = -1f,
                      },
                      new CustomBlocksDef
                      {
                          SubTypeId = "Test2",
                          Modifier = -1f,
                      },
                  },
              },
          },
          AreaOfDamage = new AreaOfDamageDef
          {
              ByBlockHit = new ByBlockHitDef
              {
                  Enable = false,
                  Radius = 1f,
                  Damage = 250f,
                  Depth = 1f,
                  MaxAbsorb = 0f,
                  Falloff = Pooled, //.NoFalloff applies the same damage to all blocks in radius
                  //.Linear drops evenly by distance from center out to max radius
                  //.Curve drops off damage sharply as it approaches the max radius
                  //.InvCurve drops off sharply from the middle and tapers to max radius
                  //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                  //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
              },
              EndOfLife = new EndOfLifeDef
              {
                  Enable = true,
                  Radius = 1f,
                  Damage = 5f,
                  Depth = 0f,
                  MaxAbsorb = 0f,
                  Falloff = Linear, //.NoFalloff applies the same damage to all blocks in radius
                  //.Linear drops evenly by distance from center out to max radius
                  //.Curve drops off damage sharply as it approaches the max radius
                  //.InvCurve drops off sharply from the middle and tapers to max radius
                  //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                  //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    ArmOnlyOnHit = false, // Detonation only is available, After it hits something, when this is true. IE, if shot down, it won't explode.
                    MinArmingTime = 120, // In ticks, before the Ammo is allowed to explode, detonate or similar; This affects shrapnel spawning.
                    NoVisuals = false,
                    NoSound = false,
                    ParticleScale = 0.4f,
                    CustomParticle = "Explosion_Warhead_30", // Particle SubtypeID, from your Particle SBC
                    CustomSound = "MediumMissileImpact", // SubtypeID from your Audio SBC, not a filename
                    Shape = Diamond, // Round or Diamond
              },
          },
          Ewar = new EwarDef
          {
              Enable = false,
              Type = EnergySink,
              Mode = Effect,
              Strength = 0f,
              Radius = 0f,
              Duration = 0,
              StackDuration = true,
              Depletable = true,
              MaxStacks = 0,
              NoHitParticle = false,
              Force = new PushPullDef
              {
                  ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                  ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                  Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                  DisableRelativeMass = false,
                  TractorRange = 0,
                  ShooterFeelsForce = false,
              },
              Field = new FieldDef
              {
                  Interval = 0, // Time between each pulse, in game ticks (60 == 1 second).
                  PulseChance = 0, // Chance from 0 - 100 that an entity in the field will be hit by any given pulse.
                  GrowTime = 0, // How many ticks it should take the field to grow to full size.
                  HideModel = false, // Hide the projectile model if it has one.
                  ShowParticle = false, // Deprecated.
                  Particle = new ParticleDef // Particle effect to generate at the field's position.
                  {
                      Name = "", // SubtypeId of field particle effect.
                      Color = Color(red: 0, green: 0, blue: 0, alpha: 0), // Deprecated, set color in particle sbc.
                      Extras = new ParticleOptionDef
                      {
                          Loop = false, // Deprecated, set this in particle sbc.
                          Restart = false, // Not used.
                          MaxDistance = 5000, // Not used.
                          MaxDuration = 1, // Not used.
                          Scale = 1, // Scale of effect.
                      },
                  },
              },
          },
          Beams = new BeamDef
          {
              Enable = false,
              VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
              ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
              RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
              OneParticle = false, // Only spawn one particle hit per beam weapon.
          },
          Trajectory = new TrajectoryDef
          {
                Guidance = Smart, // None, Remote, TravelTo, Smart, DetectTravelTo, DetectSmart, DetectFixed
                TargetLossDegree = 40f, // Degrees, Is pointed forward
                TargetLossTime = 300, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 7200, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..). time begins at 0 and time must EXCEED this value to trigger "time > maxValue". Please have a value for this, It stops Bad things.
                AccelPerSec = 30, // Acceleration in Meters Per Second. Projectile starts on tick 0 at its parents (weapon/other projectiles) travel velocity.
                DesiredSpeed = 100, // voxel phasing if you go above 5100
                MaxTrajectory = 10000f, // Max Distance the projectile or beam can Travel.
                DeaccelTime = 0, // 0 is disabled, a value causes the projectile to come to rest overtime, (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable. Natural Gravity Only.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed. Be warned, you can make your projectile go backwards.
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
                TotalAcceleration = 0, // 0 means no limit, something to do due with a thing called delta and something called v.
                Smarts = new SmartsDef
                {
                    SteeringLimit = 175, // 0 means no limit, value is in degrees, good starting is 150.  This enable advanced smart "control", cost of 3 on a scale of 1-5, 0 being basic smart.
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 3f, // controls how responsive tracking is, recommended value 3-5.
                    MaxLateralThrust = 1.5f, // controls how sharp the projectile may turn, this is the cheaper but less realistic version of SteeringLimit, cost of 2 on a scale of 1-5, 0 being basic smart.
                    NavAcceleration = 0, // helps influence how the projectile steers, 0 defaults to 1/2 Aggressiveness value or 0 if its 0, a value less than 0 disables this feature. 
                    TrackingDelay = 0, // Measured in Shape diameter units traveled.
                    AccelClearance = false, // Setting this to true will prevent smart acceleration until it is clear of the grid and tracking delay has been met (free fall).
                    MaxChaseTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoint's.
                    CheckFutureIntersection = true, // Utilize obstacle avoidance for drones/smarts
                    FutureIntersectionRange = 0, // Range in front of the projectile at which it will detect obstacle.  If set to zero it defaults to DesiredSpeed + Shape Diameter
                    MaxTargets = 1, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                    KeepAliveAfterTargetLoss = false, // Whether to stop early death of projectile on target loss
                    OffsetRatio = 0f, // The ratio to offset the random direction (0 to 1) 
                    OffsetTime = 0, // how often to offset degree, measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..)
                    OffsetMinRange = 0, // The range from target at which offsets are no longer active
                    FocusOnly = true, // only target the constructs Ai's focus target
                    FocusEviction = false, // If FocusOnly and this to true will force smarts to lose target when there is no focus target
                    ScanRange = 0, // 0 disables projectile screening, the max range that this projectile will be seen at by defending grids (adds this projectile to defenders lookup database). 
                    NoSteering = false, // this disables target follow and instead travel straight ahead (but will respect offsets).
                    MinTurnSpeed = 0, // set this to a reasonable value to avoid projectiles from spinning in place or being too aggressive turing at slow speeds 
                    NoTargetApproach = false, // If true approaches can begin prior to the projectile ever having had a target.
                    AltNavigation = false, // If true this will swap the default navigation algorithm from ProNav to ZeroEffort Miss.  Zero effort is more direct/precise but less cinematic 
                },
Approaches = new [] // These approaches move forward and backward in order, once the end condition of the last one is reached it will revert to default behavior.
                {
                   new ApproachDef // * in comments means default
                   {
                       // Start/End conditions
                       StartCondition1 = Spawn, // Each condition type is either >= or <= the corresponding value defined below.
                                                   // Ignore(skip this condition)*, DistanceFromPositionC[<=], DistanceToPositionC[>=], DistanceFromPositionB[<=], DistanceToPositionB[>=]
                                                   // DistanceFromTarget[<=], DistanceToTarget[>=], DistanceFromEndTrajectory[<=], DistanceToEndTrajectory[>=], Lifetime[>=], DeadTime[<=],
                                                   // MinTravelRequired[>=], MaxTravelRequired[<=], Spawn(per stage), DesiredElevation(tolerance can be set with ElevationTolerance),
                                                   // NextTimedSpawn[<=], SinceTimedSpawn[>=], RelativeLifetime[>=], RelativeDeadTime[<=], RelativeSpawns[>=], EnemyTargetLoss[>=],
                                                   // RelativeHealthLost[>=], HealthRemaining[<=],
                                                   // *NOTE* DO NOT set start1 and start2 or end1 and end2 to same condition
                       StartCondition2 = Ignore,
                       EndCondition1 = DistanceFromTarget,
                       End1Value = 170,

                       Forward = ForwardTargetDirection, // ForwardElevationDirection*, ForwardRelativeToBlock, ForwardRelativeToShooter, ForwardRelativeToGravity, ForwardTargetDirection, ForwardTargetVelocity, ForwardStoredStartPosition, ForwardStoredEndPosition, ForwardStoredStartLocalPosition, ForwardStoredEndLocalPosition, ForwardOriginDirection
                       Up = UpRelativeToGravity, // UpRelativeToBlock*, UpRelativeToShooter, UpRelativeToGravity, UpTargetDirection, UpTargetVelocity, UpStoredStartPosition, UpStoredEndPosition, UpStoredStartLocalPosition, UpStoredEndLocalPosition, UpOriginDirection, UpElevationDirection
                       PositionB = PositionA, // Origin*, Shooter, Target, Surface, MidPoint, PositionA, Nothing, StoredStartPosition, StoredEndPosition, StoredStartLocalPosition, StoredEndLocalPosition
                       PositionC = Target,
                       Elevation = Surface,
                       AdjustForward = true, // adjust forwardDir overtime.
                       AdjustUp = false, // adjust upDir overtime
                       AdjustPositionB = true, // Updated the position overtime.
                       AdjustPositionC = true, // Update the position overtime.
                       LeadRotateElevatePositionB = true, // Add Lead, Rotation and DesiredElevation to PositionB
                       LeadRotateElevatePositionC = true, // Add Lead, Rotation and DesiredElevation to PositionC
                       TrajectoryRelativeToB = true, // If true the projectiles immediate trajectory will be relative to PositionB instead of PositionC (e.g. quick response to elevation changes relative to PositionB position assuming that position is closer to PositionA)
                       ElevationRelativeToC = false, // If true the projectiles desired elevation will be relative to PositionC instead of PositionB (e.g. quick response to elevation changes relative to PositionC position assuming that position is closer to PositionA)

                       ElevationTolerance = 5, // adds additional tolerance (in meters) to meet the Elevation condition requirement.  *note* collision size is also added to the tolerance
                       TrackingDistance = 0, // Minimum travel distance before projectile begins racing to heading
                       DesiredElevation = -175, // The desired elevation relative to reference position

                       // Controls the leading behavior
                       LeadDistance = 200, // Add additional "lead" in meters to the trajectory (project in the future), this will be applied even before TrackingDistance is met.
                       PushLeadByTravelDistance = false, // the follow lead position will move in its point direction by an amount equal to the projectiles travel distance.

                       // Modify speed and acceleration ratios while this approach is active
                       AccelMulti = 1.5f, // Modify default acceleration by this factor
                       DeAccelMulti = 0, // Modifies your default deacceleration by this factor
                       TotalAccelMulti = 0, // Modifies your default totalacceleration by this factor
                       SpeedCapMulti = 0.9f, // Limit max speed to this factor, must keep this value BELOW default maxspeed (1).                       // Audio/Visual Section

                        // Other
                        NoTimedSpawns = false, // When true timedSpawns will not be triggered while this approach is active.
                        DisableAvoidance = false, // Disable futureIntersect.
                        IgnoreAntiSmart = false, // If set to true, antismart cannot change this approaches target.
                        HeatRefund = 0, // how much heat to refund when related EndEvent/StartEvent is met.
                        ReloadRefund = false, // Refund a reload (for max reload).
                        ToggleIngoreVoxels = false, // Toggles whatever the default IgnoreVoxel value to its opposite. 
                        SelfAvoidance = true, // If this and FutureIntersect is enabled then projectiles will actively avoid the parent grids.
                        TargetAvoidance = false, // If this and FutureIntersect is enabled then projectiles will actively avoid the target.
                        SelfPhasing = false, // If enabled the projectiles can phase through the parent grids without doing damage or dying.
                        SwapNavigationType = false, // This will swap to other navigation  (i.e. the alternate of what is set in smart, ProNav vs ZeroEffort) 
                       AlternateParticle = new ParticleDef // if blank it will use default, must be a default version for this to be useable.
                       {
                           Name = "TTTorpedo_Trail1",
                           Offset = Vector(x: 0, y: 0, z: 0),
                           DisableCameraCulling = true,// If not true will not cull when not in view of camera, be careful with this and only use if you know you need it
                           Extras = new ParticleOptionDef
                           {
                               Scale = 1,
                           },
                       },
                       StartParticle = new ParticleDef // Optional particle to play when this stage begins
                       {
                           Name = "",
                           Offset = Vector(x: 0, y: 0, z: 0),
                           DisableCameraCulling = true,// If not true will not cull when not in view of camera, be careful with this and only use if you know you need it
                           Extras = new ParticleOptionDef
                           {
                               Scale = 1,
                           },
                       },
                       AlternateModel = "", // Define only if you want to switch to an alternate model in this phase
                       AlternateSound = "", // if blank it will use default, must be a default version for this to be useable.
                       ModelRotateTime = 0, // If this value is greater than 0 then the projectile model will rotate to face the target, a value of 1 is instant (in ticks).
                   },
                },
                   
              Mines = new MinesDef
              {
                  DetectRadius = 200,
                  DeCloakRadius = 100,
                  FieldTime = 1800,
                  Cloak = false,
                  Persist = false,
              },
          },
          AmmoGraphics = new GraphicDef
          {
              ModelName = "\\Models\\Ammo\\TTMK44G.mwm",
              VisualProbability = 1f,
              ShieldHitDraw = false,
              Particles = new AmmoParticleDef
              {
                  Ammo = new ParticleDef
                  {
                      Name = "TTTorpedo_Trail1", //ShipWelderArc
                      Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                      Offset = Vector(x: 0, y: 0, z: 0),
                      Extras = new ParticleOptionDef
                      {
                          Loop = false,
                          Restart = false,
                          MaxDistance = 5000,
                          MaxDuration = 1,
                          Scale = 1f,
                      },
                  },
                  Hit = new ParticleDef
                  {
                      Name = "",
                      ApplyToShield = false,
                      Color = Color(red: 50, green: 50, blue: 50, alpha: 0.1f),
                      Offset = Vector(x: 0, y: 0, z: 0),
                      Extras = new ParticleOptionDef
                      {
                          Loop = false,
                          Restart = false,
                          MaxDistance = 5000,
                          MaxDuration = 0.2f,
                          Scale = 0.2f,
                          HitPlayChance = 1f,
                      },
                  },
              },
              Lines = new LineDef
              {
                  TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                  ColorVariance = Random(start: 0.1f, end: 2f), // multiply the color by random values within range.
                  WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
                  Tracer = new TracerBaseDef
                  {
                      Enable = true,
                      Length = 5f,
                      Width = 0.1f,
                      Color = Color(red: 2f, green: 2f, blue: 2f, alpha: 0.2f),
                  },
                  Trail = new TrailDef
                  {
                      Enable = false,
                      Material = "WeaponLaser",
                      DecayTime = 8,
                      Color = Color(red: 18.985f, green: 18.162f, blue: 0.81f, alpha: 1f),
                      Back = false,
                      CustomWidth = 0.1f,
                      UseWidthVariance = true,
                      UseColorFade = true,
                  },
                  OffsetEffect = new OffsetEffectDef
                  {
                      MaxOffset = 0,// 0 offset value disables this effect
                      MinLength = 0.2f,
                      MaxLength = 3,
                  },
              },
          },
          AmmoAudio = new AmmoAudioDef
          {
              TravelSound = "",
              HitSound = "",
              HitPlayChance = 1f,
              HitPlayShield = false,
          }, // Don't edit below this line
        };
        

    }
}
