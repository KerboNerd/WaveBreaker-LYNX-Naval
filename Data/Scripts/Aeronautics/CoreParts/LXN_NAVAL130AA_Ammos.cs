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
{
    partial class Parts
    {
        private AmmoDef LXN_NAVAL130AA_Ammo => new AmmoDef
        {
            AmmoMagazine = "LXN_NAVAL130AAMag",
            AmmoRound = "130mm Naval AA",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 10f,
            Mass = 35f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 71500f, // Calcuated as Kgf
            DecayPerShot = 0f,
            HardPointUsable = true,
            IgnoreWater = false,
            NoGridOrArmorScaling = true, // If you enable this you can remove the damagescale section entirely.

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            Fragment = new FragmentDef // Formerly known as Shrapnel. Spawns specified ammo fragments on projectile death (via hit or detonation).
            {
                AmmoRound = "NAVAL130AA Fragmentation", // AmmoRound field of the ammo to spawn.
                Fragments = 60,
                Degrees = 360,
                Reverse = false,
                DropVelocity = true,
                Offset = 0f,
                Radial = 0f,
                MaxChildren = 0,
                IgnoreArming = true,
                ArmWhenHit = false,
                AdvOffset = Vector(x: 0, y: 0, z: 0),

                TimedSpawns = new TimedSpawnDef
                {
                    Enable = false,
                    // Enable = true,
                    // Interval = 0,
                    // StartTime = 0,
                    // MaxSpawns = 1,
                    // Proximity = 7, // 7m Proximity Fuse
                    // ParentDies = true,
                    // PointAtTarget = true,
                    // PointType = Direct,
                    // DirectAimCone = 360f,
                    // GroupSize = 1,
                    // GroupDelay = 0,
                },
            },
            AreaOfDamage = new AreaOfDamageDef
            {
                ByBlockHit = new ByBlockHitDef
                {
                    Enable = false,
                    Radius = 0f,
                    Damage = 0f,
                    Depth = 0f,
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
                    Enable = false,
                    Radius = 10f,
                    Damage = 100f,
                    Depth = 10f,
                    MaxAbsorb = 0f,
                    Falloff = Linear, //.NoFalloff applies the same damage to all blocks in radius
                    //.Linear drops evenly by distance from center out to max radius
                    //.Curve drops off damage sharply as it approaches the max radius
                    //.InvCurve drops off sharply from the middle and tapers to max radius
                    //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
                    //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
                    ArmOnlyOnHit = false,
                    MinArmingTime = 0,
                    NoVisuals = false,
                    NoSound = false,
                    ParticleScale = 0.5f,
                    CustomParticle = "",
                    CustomSound = "",
                },
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = TravelTo,
                TargetLossDegree = 60f,
                TargetLossTime = 20, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 3900, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 850,
                MaxTrajectory = 8000f,
                SpeedVariance = Random(start: -5, end: 5), // subtracts value from DesiredSpeed
                // RangeVariance = Random(start: -25, end: 25), // subtracts value from MaxTrajectory
                GravityMultiplier = 1f, // Gravity influences the trajectory of the projectile.
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        Color = Color(red: 255, green: 60, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 0.1f,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LXN_NAVAL130MM_HE",
                        ApplyToShield = true,
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 15000,
                            MaxDuration = 1f,
                            Scale = 0.5f,
                            HitPlayChance = 0.5f,
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
                        Length = 12f,
                        Width = 0.08f,
                        Color = Color(red: 15.80f, green: 4.5f, blue: 2.0f, alpha: 0.8f),
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 1,
                        Color = Color(red: 1.985f, green: 0f, blue: 0f, alpha: 0.8f),
                        Back = false,
                        CustomWidth = 0.05f,
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
                HitPlayChance = 0.4f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };

        // private AmmoDef LXN_NAVAL130AA_Frags => new AmmoDef // Your ID, for slotting into the Weapon CS
        // {
        //     AmmoMagazine = "Energy", // SubtypeId of physical ammo magazine. Use "Energy" for weapons without physical ammo.
        //     AmmoRound = "NAVAL130AA Fragmentation", // Name of ammo in terminal, should be different for each ammo type used by the same weapon. Is used by Shrapnel.
        //     HybridRound = false, // Use both a physical ammo magazine and energy per shot.
        //     EnergyCost = 0f, // Scaler for energy per shot (EnergyCost * BaseDamage * (RateOfFire / 3600) * BarrelsPerShot * TrajectilesPerBarrel). Uses EffectStrength instead of BaseDamage if EWAR.
        //     BaseDamage = 10, // Direct damage; one steel plate is worth 100.
        //     Mass = 3, // In kilograms; how much force the impact will apply to the target.
        //     Health = 0, // How much damage the projectile can take from other projectiles (base of 1 per hit) before dying; 0 disables this and makes the projectile untargetable.
        //     BackKickForce = 0, // Recoil. This is applied to the Parent Grid.
        //     DecayPerShot = 0f, // Damage to the firing weapon itself. 
        //                        //float.MaxValue will drop the weapon to the first build state and destroy all components used for construction
        //                        //If greater than cube integrity it will remove the cube upon firing, without causing deformation (makes it look like the whole "block" flew away)
        //     HardPointUsable = false, // Whether this is a primary ammo type fired directly by the turret. Set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
        //     EnergyMagazineSize = 1, // For energy weapons, how many shots to fire before reloading.
        //     IgnoreWater = false, // Whether the projectile should be able to penetrate water when using WaterMod.
        //     IgnoreVoxels = false, // Whether the projectile should be able to penetrate voxels.
        //     HeatModifier = -1f, // Allows this ammo to modify the amount of heat the weapon produces per shot.
        //     NpcSafe = false, // This is you tell npc moders that your ammo was designed with them in mind, if they tell you otherwise set this to false.
        //     NoGridOrArmorScaling = false, // If you enable this you can remove the damagescale section entirely.
        //     Sync = new SynchronizeDef
        //     {
        //         Full = false, // Be careful, do not use on high fire rate weapons or ammos with many simultaneous fragments. This will send position updates twice per second per projectile/fragment and sync target (grid/block) changes.
        //         PointDefense = false, // Server will inform clients of what projectiles have died by PD defense and will trigger destruction.
        //         OnHitDeath = false, // Server will inform clients when projectiles die due to them hitting something and will trigger destruction.
        //     },
        //     Shape = new ShapeDef // Defines the collision shape of the projectile, defaults to LineShape and uses the visual Line Length if set to 0.
        //     {
        //         Shape = SphereShape, // LineShape or SphereShape. Do not use SphereShape for fast moving projectiles if you care about precision.
        //         Diameter = 100, // Diameter is minimum length of LineShape or minimum diameter of SphereShape.
        //     },
            
        //     DamageScales = new DamageScaleDef
        //     {
        //         MaxIntegrity = 0f, // Blocks with integrity higher than this value will be immune to damage from this projectile; 0 = disabled.
        //         DamageVoxels = false, // Whether to damage voxels.
        //         SelfDamage = false, // Whether to damage the weapon's own grid.
        //         HealthHitModifier = 1.5f, // How much Health to subtract from another projectile on hit; defaults to 1 if zero or less.
        //         VoxelHitModifier = 0, // Voxel damage multiplier; defaults to 1 if zero or less.
        //         Characters = -1f, // Character damage multiplier; defaults to 1 if zero or less.
        //         // For the following modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01f = 1% damage, 2 = 200% damage.
        //         FallOff = new FallOffDef
        //         {
        //             Distance = 0f, // Distance at which damage begins falling off.
        //             MinMultipler = 0.5f, // Value from 0.0001f to 1f where 0.1f would be a min damage of 10% of base damage.
        //         },
        //         Grids = new GridSizeDef
        //         {
        //             Large = 0.2f, // Multiplier for damage against large grids.
        //             Small = -1f, // Multiplier for damage against small grids.
        //         },
        //         Armor = new ArmorDef
        //         {
        //             Armor = -1f, // Multiplier for damage against all armor. This is multiplied with the specific armor type multiplier (light, heavy).
        //             Light = -1f, // Multiplier for damage against light armor.
        //             Heavy = 0.8f, // Multiplier for damage against heavy armor.
        //             NonArmor = 1.5f, // Multiplier for damage against every else.
        //         },
        //         Shields = new ShieldDef
        //         {
        //             Modifier = 1f, // Multiplier for damage against shields.
        //             Type = Default, // Damage vs healing against shields; Default, Heal
        //             BypassModifier = -1f, // If greater than zero, the percentage of damage that will penetrate the shield.
        //         },
        //         DamageType = new DamageTypes // Damage type of each element of the projectile's damage; Kinetic, Energy
        //         {
        //             Base = Kinetic, // Base Damage uses this
        //             AreaEffect = Energy,
        //             Detonation = Energy,
        //             Shield = Energy, // Damage against shields is currently all of one type per projectile. Shield Bypass Weapons, always Deal Energy regardless of this line
        //         },
        //         Deform = new DeformDef
        //         {
        //             DeformType = HitBlock,
        //             DeformDelay = 30,
        //         },
        //         Custom = new CustomScalesDef
        //         {
        //             SkipOthers = NoSkip, // Controls how projectile interacts with other blocks in relation to those defined here, NoSkip, Exclusive, Inclusive.
        //             Types = new[] // List of blocks to apply custom damage multipliers to.
        //            {
        //                 new CustomBlocksDef
        //                 {
        //                     SubTypeId = "Test1",
        //                     Modifier = -1f,
        //                 },
        //                 new CustomBlocksDef
        //                 {
        //                     SubTypeId = "Test2",
        //                     Modifier = -1f,
        //                 },
        //             },
        //         },
        //     },

        //     AreaOfDamage = new AreaOfDamageDef // Note AOE is only applied to the Player/Grid it hit (and nearby projectiles) not nearby grids/players.
        //     {
        //         ByBlockHit = new ByBlockHitDef
        //         {
        //             Enable = false,
        //             Radius = 5f, // Meters
        //             Damage = 5f,
        //             Depth = 1f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
        //             MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
        //             Falloff = Pooled, //.NoFalloff applies the same damage to all blocks in radius
        //             //.Linear drops evenly by distance from center out to max radius
        //             //.Curve drops off damage sharply as it approaches the max radius
        //             //.InvCurve drops off sharply from the middle and tapers to max radius
        //             //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
        //             //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
        //             //.Exponential drops off exponentially.  Does not scale to max radius
        //             Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
        //         },
        //         EndOfLife = new EndOfLifeDef
        //         {
        //             Enable = true,
        //             Radius = 2f, // Radius of AOE effect, in meters.
        //             Damage = 50f,
        //             Depth = 2f, // Max depth of AOE effect, in meters. 0=disabled, and AOE effect will reach to a depth of the radius value
        //             MaxAbsorb = 0f, // Soft cutoff for damage, except for pooled falloff.  If pooled falloff, limits max damage per block.
        //             Falloff = Linear, //.NoFalloff applies the same damage to all blocks in radius
        //             //.Linear drops evenly by distance from center out to max radius
        //             //.Curve drops off damage sharply as it approaches the max radius
        //             //.InvCurve drops off sharply from the middle and tapers to max radius
        //             //.Squeeze does little damage to the middle, but rapidly increases damage toward max radius
        //             //.Pooled damage behaves in a pooled manner that once exhausted damage ceases.
        //             //.Exponential drops off exponentially.  Does not scale to max radius
        //             ArmOnlyOnHit = false, // Detonation only is available, After it hits something when this is true. IE, if shot down, it won't explode.
        //             MinArmingTime = 0, // In ticks, before the Ammo is allowed to explode, detonate or similar; This affects shrapnel spawning.
        //             NoVisuals = false,
        //             NoSound = false,
        //             ParticleScale = 0f,
        //             CustomParticle = "", // Particle SubtypeID, from your Particle SBC
        //             CustomSound = "", // SubtypeID from your Audio SBC, not a filename
        //             Shape = Diamond, // Round or Diamond shape.  Diamond is more performance friendly.
        //         },
        //     },
        //     Trajectory = new TrajectoryDef
        //     {
        //         Guidance = None, // None, Remote, TravelTo, Smart, DetectTravelTo, DetectSmart, DetectFixed
        //         TargetLossDegree = 0, // Degrees, Is pointed forward
        //         TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
        //         MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..). time begins at 0 and time must EXCEED this value to trigger "time > maxValue". Please have a value for this, It stops Bad things.
        //         AccelPerSec = 0, // Acceleration in Meters Per Second. Projectile starts on tick 0 at its parents (weapon/other projectiles) travel velocity.
        //         DesiredSpeed = 200, // voxel phasing if you go above 5100
        //         MaxTrajectory = 50, // Max Distance the projectile or beam can Travel.
        //         DeaccelTime = 0, // 0 is disabled, a value causes the projectile to come to rest overtime, (Measured in game ticks, 60 = 1 second)
        //         GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable. Natural Gravity Only.
        //         DragPerSecond = 0f, // Amount of drag (m/s) deducted from the projectile's speed, multiplied by age.  Will not go below zero/negative
        //         SpeedVariance = Random(start: 0, end: 80), // subtracts value from DesiredSpeed. Be warned, you can make your projectile go backwards.
        //         RangeVariance = Random(start: 0, end: 60), // subtracts value from MaxTrajectory
        //         MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
        //         TotalAcceleration = 0, // 0 means no limit, something to do due with a thing called delta and something called v.
        //     },
        //     AmmoGraphics = new GraphicDef
        //     {
        //         ModelName = "", // Model Path goes here.
        //         VisualProbability = 1f, // %
        //         ShieldHitDraw = false,
        //         Decals = new DecalDef
        //         {
        //             MaxAge = 600,
        //             Map = new[]
        //            {
        //                 new TextureMapDef
        //                 {
        //                     HitMaterial = "Metal",
        //                     DecalMaterial = "GunBullet",
        //                 },
        //                 new TextureMapDef
        //                 {
        //                     HitMaterial = "Glass",
        //                     DecalMaterial = "GunBullet",
        //                 },
        //             },
        //         },
        //         Particles = new AmmoParticleDef
        //         {
        //             Ammo = new ParticleDef
        //             {
        //                 Name = "LXN_NAVAL130MM_HE", //ShipWelderArc
        //                 Offset = Vector(x: 0, y: 0, z: 0),
        //                 DisableCameraCulling = true,// If not true will not cull when not in view of camera, be careful with this and only use if you know you need it
        //                 Extras = new ParticleOptionDef
        //                 {
        //                     Scale = 0.5f,
        //                 },
        //             },
        //             Hit = new ParticleDef
        //             {
        //                 Name = "",
        //                 ApplyToShield = true,
        //                 Offset = Vector(x: 0, y: 0, z: 0),
        //                 DisableCameraCulling = true, // If not true will not cull when not in view of camera, be careful with this and only use if you know you need it
        //                 Extras = new ParticleOptionDef
        //                 {
        //                     Scale = 0.2f,
        //                     HitPlayChance = 1f,
        //                 },
        //             },
        //             Eject = new ParticleDef
        //             {
        //                 Name = "",
        //                 ApplyToShield = true,
        //                 Offset = Vector(x: 0, y: 0, z: 0),
        //                 DisableCameraCulling = true, // If not true will not cull when not in view of camera, be careful with this and only use if you know you need it
        //                 Extras = new ParticleOptionDef
        //                 {
        //                     Scale = 1,
        //                     HitPlayChance = 1f,
        //                 },
        //             },
        //         },
        //         Lines = new LineDef
        //         {
        //             ColorVariance = Random(start: 0f, end: 0f), // multiply the color by random values within range.
        //             WidthVariance = Random(start: 0f, end: 0f), // adds random value to default width (negatives shrinks width)
        //             DropParentVelocity = false, // If set to true will not take on the parents (grid/player) initial velocity when rendering.

        //             Tracer = new TracerBaseDef
        //             {
        //                 Enable = false,
        //                 Length = 10f, //
        //                 Width = 0.5f, //
        //                 Color = Color(red: 50, green: 0, blue: 0, alpha: 1), // RBG 255 is Neon Glowing, 100 is Quite Bright.
        //                 FactionColor = DontUse, // DontUse, Foreground, Background.
        //                 VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
        //                 VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
        //                 AlwaysDraw = true, // Prevents this tracer from being culled.  Only use if you have a reason too (very long tracers/trails).
        //                 Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
        //                     "ProjectileTrailLine", // Please always have this Line set, if this Section is enabled.
        //                 },
        //                 TextureMode = Normal, // Normal, Cycle, Chaos, Wave
        //                 Segmentation = new SegmentDef
        //                 {
        //                     Enable = false, // If true Tracer TextureMode is ignored
        //                     Textures = new[] {
        //                         "", // Please always have this Line set, if this Section is enabled.
        //                     },
        //                     SegmentLength = 0f, // Uses the values below.
        //                     SegmentGap = 0f, // Uses Tracer textures and values
        //                     Speed = 1f, // meters per second
        //                     Color = Color(red: 1, green: 2, blue: 2.5f, alpha: 1),
        //                     FactionColor = DontUse, // DontUse, Foreground, Background.
        //                     WidthMultiplier = 1f,
        //                     Reverse = false,
        //                     UseLineVariance = true,
        //                     WidthVariance = Random(start: 0f, end: 0f),
        //                     ColorVariance = Random(start: 0f, end: 0f)
        //                 }
        //             },
        //             Trail = new TrailDef
        //             {
        //                 Enable = false,
        //                 AlwaysDraw = false, // Prevents this tracer from being culled.  Only use if you have a reason too (very long tracers/trails).
        //                 Textures = new[] {
        //                     "WeaponLaser", // Please always have this Line set, if this Section is enabled.
        //                 },
        //                 TextureMode = Normal,
        //                 DecayTime = 10, // In Ticks. 1 = 1 Additional Tracer generated per motion, 33 is 33 lines drawn per projectile. Keep this number low.
        //                 Color = Color(red: 20, green: 10, blue: 5, alpha: 1),
        //                 FactionColor = DontUse, // DontUse, Foreground, Background.
        //                 Back = false,
        //                 CustomWidth = 0,
        //                 UseWidthVariance = false,
        //                 UseColorFade = true,
        //             },
        //             OffsetEffect = new OffsetEffectDef
        //             {
        //                 MaxOffset = 0,// 0 offset value disables this effect
        //                 MinLength = 0.2f,
        //                 MaxLength = 3,
        //             },
        //         },
        //     },
        // };


        private AmmoDef LXN_NAVAL130AA_Frags => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "NAVAL130AA Fragmentation",
            BaseDamage = 200,
            BaseDamageCutoff = 100,
            Mass = 5f,
            NoGridOrArmorScaling = false, 

            Trajectory = new TrajectoryDef
            {
                MaxLifeTime = 180,
                MaxTrajectory = 15f,
                DesiredSpeed = 300,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // Blocks with integrity higher than this value will be immune to damage from this projectile; 0 = disabled.
                DamageVoxels = false, // Whether to damage voxels.
                SelfDamage = false, // Whether to damage the weapon's own grid.
                HealthHitModifier = 1.5f, // How much Health to subtract from another projectile on hit; defaults to 1 if zero or less.
                VoxelHitModifier = 0, // Voxel damage multiplier; defaults to 1 if zero or less.
                Characters = -1f, // Character damage multiplier; defaults to 1 if zero or less.
                // For the following modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01f = 1% damage, 2 = 200% damage.
                FallOff = new FallOffDef
                {
                    Distance = 0f, // Distance at which damage begins falling off.
                    MinMultipler = 0.5f, // Value from 0.0001f to 1f where 0.1f would be a min damage of 10% of base damage.
                },
                Grids = new GridSizeDef
                {
                    Large = 0.2f, // Multiplier for damage against large grids.
                    Small = -1f, // Multiplier for damage against small grids.
                },
                Armor = new ArmorDef
                {
                    Armor = -1f, // Multiplier for damage against all armor. This is multiplied with the specific armor type multiplier (light, heavy).
                    Light = -1f, // Multiplier for damage against light armor.
                    Heavy = 0.8f, // Multiplier for damage against heavy armor.
                    NonArmor = 1.5f, // Multiplier for damage against every else.
                },
                Shields = new ShieldDef
                {
                    Modifier = 1f, // Multiplier for damage against shields.
                    Type = Default, // Damage vs healing against shields; Default, Heal
                    BypassModifier = -1f, // If greater than zero, the percentage of damage that will penetrate the shield.
                },
                DamageType = new DamageTypes
                {
                    Base = Kinetic,
                    AreaEffect = Kinetic,
                    Detonation = Kinetic,
                    Shield = Kinetic,
                },
                Deform = new DeformDef
                {
                    DeformType = HitBlock,
                    DeformDelay = 30,
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
            AmmoGraphics = new GraphicDef
            {
                VisualProbability = 1f,
                Lines = new LineDef
                {
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 10f,
                        Width = 0.1f,
                        Color = Color(red: 5, green: 2, blue: 1f, alpha: 1),
                        Textures = new[] {"ProjectileTrailLine",},
                    },
                },
            },
        };


    }
}