// This file contains the quick-configuration for the Weapons.

public static class GunConfig
{
    static float InventoryMultiplier = 1;

    // Naval Guns
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int Millenium_ROF = 750; // Rate of Fire of the Millenium gun
    public static int Millenium_ReloadTime = 8 * 60; // Reload time in ticks multiplied to Seconds
    public static float Millenium_MaxRange = 2500f; // Max Range of the Millenium gun
    public static float Millenium_MinRange = 100f; // Min Range of the Millenium gun
    public static float Millenium_Inventory = 0.300f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int OTO76_ROF = 80; // Rate of Fire of the OTO76 gun
    public static int OTO76_ReloadTime = 20 * 60; // Reload time in ticks multiplied to Seconds
    public static int OTO76_MagsToLoad = 60; // Number of physical magazines to consume on reload.
    public static float OTO76_MaxRange = 3000f; // Max Range of the OTO76 gun
    public static float OTO76_MinRange = 300f; // Min Range of the OTO76 gun
    public static float OTO76_Inventory = 0.500f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int MK45_ROF = 20; // Rate of Fire of the MK45 127mm gun
    public static int MK45_ReloadTime = 25 * 60; // Reload time in ticks multiplied to Seconds
    public static int MK45_MagsToLoad = 20; // Number of physical magazines to consume on reload.
    public static float MK45_MaxRange = 4000f; // Max Range of the MK45 127mm gun
    public static float MK45_MinRange = 300f; // Min Range of the MK45 127mm gun
    public static float MK45_InventorySize = 1f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}
public static class MissileConfig
{
    static float InventoryMultiplier = 1;
    static float SAM_InventoryMultiplier = 3;
    static float SpeedLimiterFactor = 0.5f;

    // Air to Ground Missiles 
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Brimstone_Health = 40; // Health of the Brimstone missile
    public static float Brimstone_MaxRange = 5000f; // Max Range of the Brimstone missile
    public static float Brimstone_MinRange = 500f; // Min Range of the Brimstone missile
    public static float Brimstone_MaxSpeed = 700f * SpeedLimiterFactor; // Max Speed of the Brimstone missile
    public static float Brimstone_Inventory = 0.046f * InventoryMultiplier; // Inventory capacity in kL.
    public static float Brimstone_Mass = 46f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KH31AD_Health = 55; // Health of the Kh-31AD missile
    public static float KH31AD_MaxRange = 8000f; // Max Range of the Kh-31AD missile
    public static float KH31AD_MinRange = 3000f; // Min Range of the Kh-31AD missile
    public static float KH31AD_MaxSpeed = 1200f * SpeedLimiterFactor; // Max Speed of the Kh-31AD missile
    public static float KH31AD_Inventory = 0.540f * InventoryMultiplier; // Inventory capacity in kL.
    public static float KH31AD_Mass = 715f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KH31PK_Health = 45; // Health of the Kh-31PK missile
    public static float KH31PK_MaxRange = 8000f; // Max Range of the Kh-31PK missile
    public static float KH31PK_MinRange = 3000f; // Min Range of the Kh-31PK missile
    public static float KH31PK_MaxSpeed = 1200f * SpeedLimiterFactor; // Max Speed of the Kh-31PK missile
    public static float KH31PK_Inventory = 0.540f * InventoryMultiplier; // Inventory capacity in kL.
    public static float KH31PK_Mass = 715f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Short Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R73M_Health = 55; // Health of the R-73M missile
    public static float R73M_MaxRange = 3500f; // Max Range of the R-73M missile
    public static float R73M_MinRange = 300f; // Min Range of the R-73M missile
    public static float R73M_MaxSpeed = 857f * SpeedLimiterFactor; // Max Speed of the R-73M missile
    public static float R73M_Inventory = 0.062f * InventoryMultiplier; // Inventory capacity in kL.
    public static float R73M_Mass = 105f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float IRIST_Health = 55; // Health of the IRIS-T missile
    public static float IRIST_MaxRange = 5000f; // Max Range of the IRIS-T missile
    public static float IRIST_MinRange = 500f; // Min Range of the IRIS-T missile
    public static float IRIST_MaxSpeed = 1029f * SpeedLimiterFactor; // Max Speed of the IRIS-T missile
    public static float IRIST_Inventory = 0.037f * InventoryMultiplier; // Inventory capacity in kL.
    public static float IRIST_Mass = 87.4f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Medium Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R27ER_Health = 60; // Health of the R-27ER missile
    public static float R27ER_MaxRange = 8000f; // Max Range of the R-27ER missile
    public static float R27ER_MinRange = 3000f; // Min Range of the R-27ER missile
    public static float R27ER_MaxSpeed = 1543f * SpeedLimiterFactor; // Max Speed of the R-27ER missile
    public static float R27ER_Inventory = 0.119f * InventoryMultiplier; // Inventory capacity in kL.
    public static float R27ER_Mass = 350f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R27ET_Health = 50; // Health of the R-27ER missile
    public static float R27ET_MaxRange = 6000f; // Max Range of the R-27ER missile
    public static float R27ET_MinRange = 1000f; // Min Range of the R-27ER missile
    public static float R27ET_MaxSpeed = 1543f * SpeedLimiterFactor; // Max Speed of the R-27ER missile
    public static float R27ET_Inventory = 0.119f * InventoryMultiplier; // Inventory capacity in kL.
    public static float R27ET_Mass = 348f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R77_Health = 75; // Health of the R-77 missile
    public static float R77_MaxRange = 15000f; // Max Range of the R-77 missile
    public static float R77_MinRange = 5000f; // Min Range of the R-77 missile
    public static float R77_MaxSpeed = 1372f * SpeedLimiterFactor; // Max Speed of the R-77 missile
    public static float R77_Inventory = 0.113f * InventoryMultiplier; // Inventory capacity in kL.
    public static float R77_Mass = 175f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Meteor_Health = 80; // Health of the Meteor missile
    public static float Meteor_MaxRange = 17000f; // Max Range of the Meteor missile
    public static float Meteor_MinRange = 5000f; // Min Range of the Meteor missile
    public static float Meteor_MaxSpeed = 1372f * SpeedLimiterFactor; // Max Speed of the Meteor missile
    public static float Meteor_Inventory = 0.090f * InventoryMultiplier; // Inventory capacity in kL.
    public static float Meteor_Mass = 190f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Long Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RVVAEPD_Health = 130; // Health of the RVV-AE-PD missile
    public static float RVVAEPD_MaxRange = 17000f; // Max Range of the RVV-AE-PD missile
    public static float RVVAEPD_MinRange = 6500f; // Min Range of the RVV-AE-PD missile
    public static float RVVAEPD_MaxSpeed = 1543f * SpeedLimiterFactor; // Max Speed of the RVV-AE-PD missile
    public static float RVVAEPD_Inventory = 0.113f * InventoryMultiplier; // Inventory capacity in kL.
    public static float RVVAEPD_Mass = 190f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float AIM260_Health = 180; // Health of the AIM-260 missile
    public static float AIM260_MaxRange = 20000f; // Max Range of the AIM-260 missile
    public static float AIM260_MinRange = 5000f; // Min Range of the AIM-260 missile
    public static float AIM260_MaxSpeed = 1843f * SpeedLimiterFactor; // Max Speed of the AIM-260 missile
    public static float AIM260_Inventory = 0.100f * InventoryMultiplier; // Inventory capacity in kL.
    public static float AIM260_Mass = 180f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R37M_Health = 130; // Health of the R-37M missile
    public static float R37M_MaxRange = 18000f; // Max Range of the R-37M missile
    public static float R37M_MinRange = 8000f; // Min Range of the R-37M missile
    public static float R37M_MaxSpeed = 2058f * SpeedLimiterFactor; // Max Speed of the R-37M missile - MACH 6
    public static float R37M_Inventory = 0.500f * InventoryMultiplier; // Inventory capacity in kL.
    public static float R37M_Mass = 600f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // High Performance Missiles
    public static float S1M_Health = 120; // Health of the S-1M missile
    public static float S1M_MaxRange = 10000f; // Max Range of the S-1M missile
    public static float S1M_MinRange = 6000f; // Min Range of the S-1M missile  
    public static float S1M_MaxSpeed = 1100f * SpeedLimiterFactor; // Max Speed of the S-1M missile
    public static float S1M_Inventory = 1.200f * InventoryMultiplier; // Inventory capacity in kL.
    public static float S1M_Mass = 2500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Surface to Air Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float S400_Health = 130; // Health of the S-400 missile
    public static int S400_ROF = 10; // Rate of Fire of the Millenium gun
    public static int S400_ReloadTime = 60 * 60; // Reload time in ticks multiplied to Seconds
    public static float S400_MaxRange = 10000f; // Max Range of the S-400 missile
    public static float S400_MinRange = 2000f; // Min Range of the S-400 missile
    public static float S400_MaxSpeed = 1950f * SpeedLimiterFactor; // Max Speed of the S-400 missile
    public static int S400_BoosterTime = 12; // Seconds
    public static float S400_BoosterAccel = 60; // Meters Per Second
    public static float S400_Inventory = 1.410f * SAM_InventoryMultiplier; // Inventory capacity in kL.
    public static float S400x4_Inventory = 4 * 1.410f * SAM_InventoryMultiplier;
    public static float S400_Mass = 1900f; // Mass in kg.
    public static float S400_HealthHit = 100; // How much damage the missile does to other projectiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RIM174_SM6_Health = 140; // Health of the RIM-174 SM6 missile
    public static float RIM174_SM6_MaxRange = 8000f; // Max Range of the RIM-174 SM6 missile
    public static float RIM174_SM6_MinRange = 800f; // Min Range of the RIM-174 SM6 missile
    public static float RIM174_SM6_MaxSpeed = 1700f * SpeedLimiterFactor; // Max Speed of the RIM-174 SM6 missile
    public static int RIM174_SM6_BoosterTime = 10; // Seconds
    public static float RIM174_SM6_BoosterAccel = 100; // Meters Per Second
    public static float RIM174_SM6_Mass = 1500f; // Mass in kg.
    public static float RIM174_SM6_HealthHit = 100; // How much damage the missile does to other projectiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // 77N6 "Prometheus" Missile
    public static float Prometheus_77N6_Health = 120; // Health of the 77N6 "Prometheus" missile
    public static float Prometheus_77N6_MaxRange = 10000f; // Max Range of the 77N6 "Prometheus" missile
    public static float Prometheus_77N6_MinRange = 1500f; // Min Range of the 77N6 "Prometheus" missile
    public static float Prometheus_77N6_MaxSpeed = 2600f * SpeedLimiterFactor; // Max Speed of the 77N6 "Prometheus" missile
    public static int Prometheus_77N6_BoosterTime = 10; // Seconds
    public static float Prometheus_77N6_BoosterAccel = 120; // Meters Per Second
    public static float Prometheus_77N6_Mass = 1893f; // Mass in kg.
    public static float Prometheus_77N6_HealthHit = 100; // How much damage the missile does to other projectiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // 57E6 Missile
    public static float S1_57E6_Health = 30; // Health of the 57E6 missile
    public static float S1_57E6_MaxRange = 4000f; // Max Range of the 57E6 missile
    public static float S1_57E6_MinRange = 250f; // Min Range of the 57E6 missile
    public static float S1_57E6_MaxSpeed = 1220f * SpeedLimiterFactor; // Max Speed of the 57E6 missile (Mach 3.5)
    public static float S1_57E6_Inventory = 0.047f * 3 * SAM_InventoryMultiplier; // Inventory capacity in kL.
    public static float S1_57E6_Mass = 86f; // Mass in kg (86kg for 57E6 missile)
    public static float S1_57E6_HealthHit = 100; // How much damage the missile does to other projectiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
    // 9M330 Missile
    public static float TOR_9M330_Health = 90;
    public static float TOR_9M330_MaxRange = 4500f; // Meters
    public static float TOR_9M330_MinRange = 500f; // Meters
    public static float TOR_9M330_MaxSpeed = 1800f * SpeedLimiterFactor; // m/s
    public static float TOR_9M330_Inventory = 0.12f * 3 * SAM_InventoryMultiplier; // kL
    public static float TOR_9M330_Mass = 165f; // Kilograms
    public static int TOR_9M330_BoosterBurnTime = 5 * 60; // Seconds (Tick Conversion: 1 second = 60 ticks)
    public static float TOR_9M330_HealthHit = 100; // How much damage the missile does to other projectiles

    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    // RIM-66 Missile
    public static float RIM66_Health = 110;
    public static float RIM66_MaxRange = 5500f; // Meters
    public static float RIM66_MinRange = 500f; // Meters
    public static float RIM66_MaxSpeed = 1500f * SpeedLimiterFactor; // m/s
    public static float RIM66_Mass = 250f; // Kilograms
    public static int RIM66_BoosterBurnTime = 5 * 60; // Seconds (Tick Conversion: 1 second = 60 ticks)
    public static float RIM66_HealthHitModifier = 100; // How much damage the missile does to other projectiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Anti-Ship Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Zircon_Health = 75; // Health of the Zircon missile
    public static float Zircon_MaxRange = 13000f; // Max Range of the Zircon missile
    public static int Zircon_ReloadTime = 30 * 60; // Reload time in ticks multiplied to Seconds
    public static float Zircon_MinRange = 4500f; // Min Range of the Zircon missile
    public static float Zircon_MaxSpeed = 2500f * SpeedLimiterFactor; // Max Speed of the Zircon missile - MACH 9
    public static float Zircon_Inventory = 3.460f * InventoryMultiplier; // Inventory capacity in kL.
    public static float Zircon_Mass = 3000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Oniks_Health = 160; // Health of the Oniks missile
    public static int Oniks_BoosterTime = 8; // Seconds
    public static float Oniks_BoosterAccel = 35; // Meters Per Second
    public static float Oniks_SkimmingAltitude = 30f; // Meters
    public static float Oniks_TerminalApproachAltitude = 10f; // Meters
    public static float Oniks_TerminalApproachDistance = 100f; // Meters
    public static float Oniks_MaxRange = 9000f; // Max Range of the Oniks missile
    public static float Oniks_MinRange = 3000f; // Min Range of the Oniks missile
    public static float Oniks_MaxSpeed = 1300f * SpeedLimiterFactor; // Max Speed of the Oniks missile
    public static float Oniks_Inventory = 3.410f * InventoryMultiplier; // Inventory capacity in kL.
    public static float Oniks_Mass = 3000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Kalibr_Health = 130; // Health of the Kalibr missile
    public static int Kalibr_BoosterTime = 8; // Seconds
    public static float Kalibr_BoosterAccel = 45; // Meters Per Second
    public static float Kalibr_SkimmingAltitude = 50f; // Meters
    public static float Kalibr_TerminalApproachAltitude = 8f; // Meters
    public static float Kalibr_TerminalApproachDistance = 100f; // Meters
    public static float Kalibr_MaxRange = 10000f; // Max Range of the Kalibr missile
    public static float Kalibr_MinRange = 3000f; // Min Range of the Kalibr missile
    public static float Kalibr_MaxSpeed = 900f * SpeedLimiterFactor; // Max Speed of the Kalibr missile
    public static float Kalibr_Mass = 3000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Moskit_Health = 165; // Health of the Moskit missile
    public static int Moskit_BoosterTime = 4; // Seconds
    public static float Moskit_BoosterAccel = 128; // Meters Per Second
    public static float Moskit_SkimmingAltitude = 30f; // Meters
    public static float Moskit_TerminalApproachAltitude = 10f; // Meters
    public static float Moskit_TerminalApproachDistance = 100f; // Meters
    public static int Moskit_ROF = 5; // Rate of Fire of the Millenium gun
    public static int Moskit_ReloadTime = 20 * 60; // Reload time in ticks multiplied to Seconds
    public static float Moskit_MaxRange = 8000f; // Max Range of the Moskit missile
    public static float Moskit_MinRange = 3000f; // Min Range of the Moskit missile
    public static float Moskit_MaxSpeed = 1200f * SpeedLimiterFactor; // Max Speed of the Moskit missile
    public static float Moskit_Inventory = 3.720f * InventoryMultiplier; // Inventory capacity in kL.
    public static float Moskit_Mass = 4000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Harpoon_Health = 120; // Health of the Harpoon missile
    public static float Harpoon_BoostAltitude = 400f; // Meters    
    public static float Harpoon_SkimmingAltitude = 75f; // Meters    
    public static float Harpoon_TerminalApproachAltitude = 25f; // Meters 
    public static float Harpoon_MaxRange = 7000f; // Max Range of the Harpoon missile
    public static float Harpoon_MinRange = 1500f; // Min Range of the Harpoon missile
    public static float Harpoon_MaxSpeed = 1200f * SpeedLimiterFactor; // Max Speed of the Harpoon missile
    public static float Harpoon_Mass = 4000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Tomahawk_Health = 170; // Health of the Tomahawk missile
    public static float Tomahawk_BoostAltitude = 100f; // Meters    
    public static float Tomahawk_SkimmingAltitude = 50f; // Meters    
    public static float Tomahawk_TerminalApproachAltitude = 15f; // Meters    
    public static float Tomahawk_MaxRange = 10000f; // Max Range of the Tomahawk missile
    public static float Tomahawk_MinRange = 3000f; // Min Range of the Tomahawk missile
    public static float Tomahawk_MaxSpeed = 1200f * SpeedLimiterFactor; // Max Speed of the Tomahawk missile
    public static float Tomahawk_Mass = 4000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Static Launchers
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int VLS3S14_ROF = 15; // Rate of Fire of the Millenium gun
    public static int VLS3S14_ReloadTime = 60 * 60; // Reload time in ticks multiplied to Seconds
    public static float VLS3S14_MaxRange = 10000f; // Max Range of the 3S14 VLS
    public static float VLS3S14_MinRange = 1000f; // Min Range of the 3S14 VLS
    public static float VLS3S14_Inventory = 20.000f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int SubVLS_ROF = 5; // Rate of Fire of the Millenium gun
    public static int SubVLS_ReloadTime = 12 * 60; // Reload time in ticks multiplied to Seconds
    public static float SubVLS_MaxRange = 8000f; // Max Range of the SubVLS
    public static float SubVLS_MinRange = 500f; // Min Range of the SubVLS
    public static float SubVLS_Inventory = 20.000f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // MK-141 Harpoon
    public static int MK141_ROF = 30; // Rate of Fire of the Millenium gun
    public static int MK141_ReloadTime = 30 * 60; // Reload time in ticks multiplied to Seconds
    public static float MK141_MaxRange = 7000f; // Max Range of the SubVLS
    public static float MK141_MinRange = 500f; // Min Range of the SubVLS
    public static float MK141_Inventory = 4f * InventoryMultiplier; // Inventory capacity in kL.

    // Arm Launchers
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // STRELA-M CIWS
    public static int STRELA_ROF = 55; // Rate of Fire of the Millenium gun
    public static uint STRELA_ReloadTime = 15 * 60; // Reload time in ticks multiplied to Seconds
    public static float STRELA_MaxRange = 3500f; // Max Range of the Millenium gun
    public static float STRELA_MinRange = 300f; // Min Range of the Millenium gun
    public static float STRELA_Inventory = 1.175f * InventoryMultiplier; // Inventory capacity in kL.

    // MK-13 Single Arm,
    public static int MK13_ROF = 75; // Rate of Fire of the Millenium gun
    public static int MK13_ReloadTime = 8 * 60 + 30; // Reload time in ticks multiplied to Seconds
    public static float MK13_MaxRange = 7000f; // Max Range of the Millenium gun
    public static float MK13_MinRange = 500f; // Min Range of the Millenium gun
    public static float MK13_Inventory = 1f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // MK-26 Dual Arm
    public static int MK26_ROF = 75; // Rate of Fire of the Millenium gun
    public static int MK26_ReloadTime = 10 * 60; // Reload time in ticks multiplied to Seconds
    public static float MK26_MaxRange = 7000f; // Max Range of the Millenium gun
    public static float MK26_MinRange = 500f; // Min Range of the Millenium gun
    public static float MK26_Inventory = 2f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Anti-Submarine
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RBU6000_Health = 20; // Health of the RBU-6000 missile
    public static int RBU6000_ROF = 75; // Rate of Fire of the Millenium gun
    public static int RBU6000_ReloadTime = 20 * 60; // Reload time in ticks multiplied to Seconds    
    public static float RBU6000_MaxRange = 1500f; // Max Range of the RBU-6000 missile
    public static float RBU6000_MinRange = 200f; // Min Range of the RBU-6000 missile
    public static float RBU6000_MaxSpeed = 250f * SpeedLimiterFactor; // Max Speed of the RBU-6000 missile
    public static float RBU6000_Inventory = 0.640f * InventoryMultiplier; // Inventory capacity in kL.
    public static float RBU6000_Mass = 110f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int ASROC_ROF = 30; // Rate of Fire of the Millenium gun
    public static int ASROC_ReloadTime = 40 * 60; // Reload time in ticks multiplied to Seconds    
    public static float ASROC_MaxRange = 7000f; // Max Range of the ASROC missile
    public static float ASROC_MinRange = 500f; // Min Range of the ASROC missile
    public static float ASROC_Inventory = 8f * InventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // Rockets
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float B8M1_Health = 10; // Health of the B8M1 rocket
    public static float B8M1_MaxRange = 4000f; // Max Range of the B8M1 rocket
    public static float B8M1_MinRange = 100f; // Min Range of the B8M1 rocket
    public static float B8M1_MaxSpeed = 500f; // Max Speed of the B8M1 rocket
    public static float B8M1_Inventory = 0.76f * InventoryMultiplier; // Inventory capacity in kL.
    public static float B8M1_Mass = 20f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}

public static class BombsConfig
{
    static float InventoryMultiplier = 1;
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float FAB500_Health = 100; // Health of the FAB-500 bomb
    public static float FAB500_Inventory = 0.190f * InventoryMultiplier; // Inventory capacity in kL.
    public static float FAB500_Mass = 500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KAB500KR_Health = 100; // Health of the KAB-500KR bomb
    public static float KAB500KR_MaxRange = 12000f; // Max Range of the KAB-500KR bomb
    public static float KAB500KR_MinRange = 0f; // Min Range of the KAB-500KR bomb
    public static float KAB500KR_Inventory = 0.310f * InventoryMultiplier; // Inventory capacity in kL.
    public static float KAB500KR_Mass = 500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KAB1500SM_Health = 150; // Health of the KAB-1500SM bomb
    public static float KAB1500SM_Inventory = 1.160f * InventoryMultiplier; // Inventory capacity in kL.
    public static float KAB1500SM_Mass = 1500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float MOAB_Health = 200; // Health of the MOAB bomb
    public static float MOAB_Inventory = 3.950f * InventoryMultiplier; // Inventory capacity in kL.
    public static float MOAB_Mass = 9800f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}

