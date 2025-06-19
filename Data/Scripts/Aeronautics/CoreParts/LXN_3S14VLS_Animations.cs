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
        private AnimationDef LXN_3S14VLS_Anim => new AnimationDef
        {
            AnimationSets = new[]
            {
				#region Muzzles Animations

               new PartAnimationSetDef()
                {
                    SubpartId = Names("door1"),
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },
            

               new PartAnimationSetDef()
                {
                    SubpartId = Names("door2"),
                    BarrelId = "muzzle_missile_2", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door3"),
                    BarrelId = "muzzle_missile_3", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door4"),
                    BarrelId = "muzzle_missile_4", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door5"),
                    BarrelId = "muzzle_missile_5", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door6"),
                    BarrelId = "muzzle_missile_6", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door7"),
                    BarrelId = "muzzle_missile_7", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0,- 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },


               new PartAnimationSetDef()
                {
                    SubpartId = Names("door8"),
                    BarrelId = "muzzle_missile_8", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },






               new PartAnimationSetDef()
                {
                    SubpartId = Names("blastwall"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
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
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
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
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, -90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 90), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },






               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile1"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile2"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile3"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile4"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile5"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile6"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile7"),
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
                            },
                    }
                }, 

               new PartAnimationSetDef()
                {
                    SubpartId = Names("missile8"),
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
                            },
                    }
                }, 




				#endregion


            }
        };
    }
}