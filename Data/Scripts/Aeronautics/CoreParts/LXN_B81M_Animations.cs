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
        private AnimationDef LXN_B81M_Anim => new AnimationDef
        {
            AnimationSets = new[]
            {
				#region Muzzles Animations
               
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket1"),
                    BarrelId = "muzzle_missile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket2"),
                    BarrelId = "muzzle_missile_2", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket3"),
                    BarrelId = "muzzle_missile_3", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket4"),
                    BarrelId = "muzzle_missile_4", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket5"),
                    BarrelId = "muzzle_missile_5", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket6"),
                    BarrelId = "muzzle_missile_6", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket7"),
                    BarrelId = "muzzle_missile_7", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket8"),
                    BarrelId = "muzzle_missile_8", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket9"),
                    BarrelId = "muzzle_missile_9", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket10"),
                    BarrelId = "muzzle_missile_10", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket11"),
                    BarrelId = "muzzle_missile_11", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket12"),
                    BarrelId = "muzzle_missile_12", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket13"),
                    BarrelId = "muzzle_missile_13", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket14"),
                    BarrelId = "muzzle_missile_14", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket15"),
                    BarrelId = "muzzle_missile_15", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket16"),
                    BarrelId = "muzzle_missile_16", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket17"),
                    BarrelId = "muzzle_missile_17", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket18"),
                    BarrelId = "muzzle_missile_18", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket19"),
                    BarrelId = "muzzle_missile_19", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                }, 
               new PartAnimationSetDef()
                {
                    SubpartId = Names("rocket20"),
                    BarrelId = "muzzle_missile_20", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Firing] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] =
                        new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1700, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, 1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0f, -1), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        // [NoMagsToLoad] =
                        // new[]
                        // {
                        //     new RelMove
                        //     {
                        //         CenterEmpty = "",
                        //         TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                        //         MovementType = Hide, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                        //         LinearPoints = new XYZ[0],
                        //         Rotation = Transformation(0, 0, 0), //degrees
                        //         RotAroundCenter = Transformation(0, 0, 0), //degrees
                        //     },
                        // },
                    }
                },               
				
                #endregion


            }
        };
    }
}