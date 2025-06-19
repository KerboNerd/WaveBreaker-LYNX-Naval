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
        private AnimationDef LXN_R77_bay1_Anim => new AnimationDef
        {
            AnimationSets = new[]
            {
				#region Muzzles Animations
               
                // Missile
               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile"),
                    BarrelId = "muzzle_missile_1", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Init] =
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

                // Slider
               new PartAnimationSetDef()
                {
                    SubpartId = Names("slider"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [TurnOn] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, -0.57f, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        [TurnOff] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0.57f, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                        [Reloading] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0.57f, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
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
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, -0.57f, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                            },
                        },
                    }
                },

                // Door1
               new PartAnimationSetDef()
                {
                    SubpartId = Names("door1"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                    // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Init] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [TurnOn] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [TurnOff] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, -120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, -120f), //degrees
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
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                },  

                // Door2
               new PartAnimationSetDef()
                {
                    SubpartId = Names("door2"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay: 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                    // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [Init] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [TurnOn] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, -120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [TurnOff] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                        [Reloading] = new[]
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 120f), //degrees
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
                                TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, -120f), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                },      
				
                #endregion
            }
        };
    }
}