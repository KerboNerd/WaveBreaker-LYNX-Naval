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
        private AmmoDef LXN_HeavyAntiAir_FRAG => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "LXN_HeavyAntiAir_FRAG",
            BaseDamage = 2500,
            // BaseDamageCutoff = 0,
            Mass = 20f,
            NoGridOrArmorScaling = true,

            Shape = new ShapeDef // Defines the collision shape of the projectile, defaults to LineShape and uses the visual Line Length if set to 0.
            {
                Shape = SphereShape, // LineShape or SphereShape. Do not use SphereShape for fast moving projectiles if you care about precision.
                Diameter = 100, // Large collision size for better hit probability against missiles in clusters
            },
            Trajectory = new TrajectoryDef
            {
                MaxLifeTime = 60, // Increased lifetime for fragments to reach more missiles
                MaxTrajectory = 300f, // Increased range for better coverage of missile clusters
                DesiredSpeed = 300, // Higher speed for better hit probability against fast-moving missiles
            },
            AmmoGraphics = new GraphicDef
            {
                VisualProbability = 1f,
                Lines = new LineDef
                {
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 20f,
                        Width = 0.2f,
                        Color = Color(red: 5, green: 2, blue: 1f, alpha: 1),
                        Textures = new[] {"ProjectileTrailLine",},
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "", // SubtypeID for your Sound File. Travel, is sound generated around your Projectile in flight
                HitSound = "LXN_SmallMissileExplosion",
                ShotSound = "",
                ShieldHitSound = "LXN_SmallMissileExplosion",
                PlayerHitSound = "LXN_SmallMissileExplosion",
                VoxelHitSound = "LXN_SmallMissileExplosion",
                FloatingHitSound = "LXN_SmallMissileExplosion",
                HitPlayChance = 1f,
                HitPlayShield = true,
            },
        };
        private AmmoDef LXN_MediumAntiAir_FRAG => new AmmoDef
        {
            AmmoMagazine = "Energy",
            AmmoRound = "LXN_MediumAntiAir_FRAG",
            BaseDamage = 1500,
            // BaseDamageCutoff = 0,
            Mass = 5f,
            NoGridOrArmorScaling = true,

            Shape = new ShapeDef // Defines the collision shape of the projectile, defaults to LineShape and uses the visual Line Length if set to 0.
            {
                Shape = SphereShape, // LineShape or SphereShape. Do not use SphereShape for fast moving projectiles if you care about precision.
                Diameter = 100, // Large collision size for better hit probability against missiles in clusters
            },
            Trajectory = new TrajectoryDef
            {
                MaxLifeTime = 60, // Increased lifetime for fragments to reach more missiles
                MaxTrajectory = 300f, // Increased range for better coverage of missile clusters
                DesiredSpeed = 300, // Higher speed for better hit probability against fast-moving missiles
            },
            AmmoGraphics = new GraphicDef
            {
                VisualProbability = 1f,
                Lines = new LineDef
                {
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 20f,
                        Width = 0.2f,
                        Color = Color(red: 5, green: 2, blue: 1f, alpha: 1),
                        Textures = new[] {"ProjectileTrailLine",},
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "", // SubtypeID for your Sound File. Travel, is sound generated around your Projectile in flight
                HitSound = "LXN_SmallMissileExplosion",
                ShotSound = "",
                ShieldHitSound = "LXN_SmallMissileExplosion",
                PlayerHitSound = "LXN_SmallMissileExplosion",
                VoxelHitSound = "LXN_SmallMissileExplosion",
                FloatingHitSound = "LXN_SmallMissileExplosion",
                HitPlayChance = 1f,
                HitPlayShield = true,
            },
        };
    }
}

