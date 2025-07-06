// This file contains the quick-configuration for the missiles.

public static class MissileConfig
{
    static float inventoryMultiplier = 1;
    static float SAM_InventoryMultiplier = 2;
    static float speedLimiterFactor = 0.55f;

    // Air to Ground Missiles 
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float AGM84SLAMMER_Health = 30; // Health of the AGM-84 SLAMMER missile
    public static int AGM84SLAMMER_BoosterTime = 3; // Seconds
    public static float AGM84SLAMMER_BoosterAccel = 43; // Meters Per Second
    public static float AGM84SLAMMER_SkimmingAltitude = 50f; // Meters
    public static float AGM84SLAMMER_TerminalApproachAltitude = 10f; // Meters
    public static float AGM84SLAMMER_TerminalApproachDistance = 300f; // Meters
    public static float AGM84SLAMMER_MaxRange = 15000f; // Max Range of the AGM-84 SLAMMER missile
    public static float AGM84SLAMMER_MinRange = 5000f; // Min Range of the AGM-84 SLAMMER missile
    public static float AGM84SLAMMER_MaxSpeed = 300f * speedLimiterFactor; // Max Speed of the AGM-84 SLAMMER missile
    public static float AGM84SLAMMER_Inventory = 0.410f * inventoryMultiplier; // Inventory capacity in kL.
    public static float AGM84SLAMMER_Mass = 674.5f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Brimstone_Health = 40; // Health of the Brimstone missile
    public static float Brimstone_MaxRange = 5000f; // Max Range of the Brimstone missile
    public static float Brimstone_MinRange = 500f; // Min Range of the Brimstone missile
    public static float Brimstone_MaxSpeed = 450f * speedLimiterFactor; // Max Speed of the Brimstone missile
    public static float Brimstone_Inventory = 0.046f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Brimstone_Mass = 46f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KH31AD_Health = 35; // Health of the Kh-31AD missile
    public static float KH31AD_MaxRange = 15000f; // Max Range of the Kh-31AD missile
    public static float KH31AD_MinRange = 3000f; // Min Range of the Kh-31AD missile
    public static float KH31AD_MaxSpeed = 1200f * speedLimiterFactor; // Max Speed of the Kh-31AD missile
    public static float KH31AD_Inventory = 0.540f * inventoryMultiplier; // Inventory capacity in kL.
    public static float KH31AD_Mass = 715f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float KH31PK_Health = 35; // Health of the Kh-31PK missile
    public static float KH31PK_MaxRange = 15000f; // Max Range of the Kh-31PK missile
    public static float KH31PK_MinRange = 3000f; // Min Range of the Kh-31PK missile
    public static float KH31PK_MaxSpeed = 1200f * speedLimiterFactor; // Max Speed of the Kh-31PK missile
    public static float KH31PK_Inventory = 0.540f * inventoryMultiplier; // Inventory capacity in kL.
    public static float KH31PK_Mass = 715f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Short Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R73M_Health = 70; // Health of the R-73M missile
    public static float R73M_MaxRange = 3500f; // Max Range of the R-73M missile
    public static float R73M_MinRange = 300f; // Min Range of the R-73M missile
    public static float R73M_MaxSpeed = 857f * speedLimiterFactor; // Max Speed of the R-73M missile
    public static float R73M_Inventory = 0.062f * inventoryMultiplier; // Inventory capacity in kL.
    public static float R73M_Mass = 105f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float IRIST_Health = 70; // Health of the IRIS-T missile
    public static float IRIST_MaxRange = 5000f; // Max Range of the IRIS-T missile
    public static float IRIST_MinRange = 500f; // Min Range of the IRIS-T missile
    public static float IRIST_MaxSpeed = 1029f * speedLimiterFactor; // Max Speed of the IRIS-T missile
    public static float IRIST_Inventory = 0.037f * inventoryMultiplier; // Inventory capacity in kL.
    public static float IRIST_Mass = 87.4f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Medium Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R27ER_Health = 85; // Health of the R-27ER missile
    public static float R27ER_MaxRange = 10000f; // Max Range of the R-27ER missile
    public static float R27ER_MinRange = 3000f; // Min Range of the R-27ER missile
    public static float R27ER_MaxSpeed = 1543f * speedLimiterFactor; // Max Speed of the R-27ER missile
    public static float R27ER_Inventory = 0.119f * inventoryMultiplier; // Inventory capacity in kL.
    public static float R27ER_Mass = 350f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public static float R27ET_Health = 90; // Health of the R-27ER missile
    public static float R27ET_MaxRange = 8000f; // Max Range of the R-27ER missile
    public static float R27ET_MinRange = 1000f; // Min Range of the R-27ER missile
    public static float R27ET_MaxSpeed = 1543f * speedLimiterFactor; // Max Speed of the R-27ER missile
    public static float R27ET_Inventory = 0.119f * inventoryMultiplier; // Inventory capacity in kL.
    public static float R27ET_Mass = 348f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R77_Health = 90; // Health of the R-77 missile
    public static float R77_MaxRange = 14000f; // Max Range of the R-77 missile
    public static float R77_MinRange = 5000f; // Min Range of the R-77 missile
    public static float R77_MaxSpeed = 1372f * speedLimiterFactor; // Max Speed of the R-77 missile
    public static float R77_Inventory = 0.113f * inventoryMultiplier; // Inventory capacity in kL.
    public static float R77_Mass = 175f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Meteor_Health = 95; // Health of the Meteor missile
    public static float Meteor_MaxRange = 16000f; // Max Range of the Meteor missile
    public static float Meteor_MinRange = 5000f; // Min Range of the Meteor missile
    public static float Meteor_MaxSpeed = 1372f * speedLimiterFactor; // Max Speed of the Meteor missile
    public static float Meteor_Inventory = 0.090f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Meteor_Mass = 190f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float AIM120_Health = 95; // Health of the AIM-120 missile
    public static float AIM120_MaxRange = 15000f; // Max Range of the AIM-120 missile
    public static float AIM120_MinRange = 3500f; // Min Range of the AIM-120 missile
    public static float AIM120_MaxSpeed = 1372f * speedLimiterFactor; // Max Speed of the AIM-120 missile
    public static float AIM120_Inventory = 0.090f * inventoryMultiplier; // Inventory capacity in kL.
    public static float AIM120_Mass = 152f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    
    // Long Range Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RVVAEPD_Health = 130; // Health of the RVV-AE-PD missile
    public static float RVVAEPD_MaxRange = 20000f; // Max Range of the RVV-AE-PD missile
    public static float RVVAEPD_MinRange = 6500f; // Min Range of the RVV-AE-PD missile
    public static float RVVAEPD_MaxSpeed = 1543f * speedLimiterFactor; // Max Speed of the RVV-AE-PD missile
    public static float RVVAEPD_Inventory = 0.113f * inventoryMultiplier; // Inventory capacity in kL.
    public static float RVVAEPD_Mass = 190f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float AIM260_Health = 150; // Health of the AIM-120 missile
    public static float AIM260_MaxRange = 20000f; // Max Range of the AIM-120 missile
    public static float AIM260_MinRange = 5000f; // Min Range of the AIM-120 missile
    public static float AIM260_MaxSpeed = 1543f * speedLimiterFactor; // Max Speed of the AIM-120 missile
    public static float AIM260_Inventory = 0.100f * inventoryMultiplier; // Inventory capacity in kL.
    public static float AIM260_Mass = 180f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float R37M_Health = 130; // Health of the R-37M missile
    public static float R37M_MaxRange = 20000f; // Max Range of the R-37M missile
    public static float R37M_MinRange = 8000f; // Min Range of the R-37M missile
    public static float R37M_MaxSpeed = 2058f * speedLimiterFactor; // Max Speed of the R-37M missile - MACH 6
    public static float R37M_Inventory = 0.500f * inventoryMultiplier; // Inventory capacity in kL.
    public static float R37M_Mass = 600f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // High Performance Missiles
    public static float S1M_Health = 90; // Health of the S-1M missile
    public static float S1M_MaxRange = 20000f; // Max Range of the S-1M missile
    public static float S1M_MinRange = 8000f; // Min Range of the S-1M missile  
    public static float S1M_MaxSpeed = 826f * speedLimiterFactor; // Max Speed of the S-1M missile
    public static float S1M_Inventory = 1.200f * inventoryMultiplier; // Inventory capacity in kL.
    public static float S1M_Mass = 2500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Surface to Air Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float S400_Health = 130; // Health of the S-400 missile
    public static float S400_MaxRange = 15000f; // Max Range of the S-400 missile
    public static float S400_MinRange = 500f; // Min Range of the S-400 missile
    public static float S400_MaxSpeed = 1500f * speedLimiterFactor; // Max Speed of the S-400 missile
    public static int S400_BoosterTime = 30; // Seconds
    public static float S400_BoosterAccel = 50; // Meters Per Second
    public static float S400_Inventory = 1.410f * SAM_InventoryMultiplier; // Inventory capacity in kL.
    public static float S400x4_Inventory = 4 * 1.410f * SAM_InventoryMultiplier;
    public static float S400_Mass = 1900f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RIM174_SM6_Health = 120; // Health of the RIM-174 SM6 missile
    public static float RIM174_SM6_MaxRange = 15000f; // Max Range of the RIM-174 SM6 missile
    public static float RIM174_SM6_MinRange = 300f; // Min Range of the RIM-174 SM6 missile
    public static float RIM174_SM6_MaxSpeed = 1200f * speedLimiterFactor; // Max Speed of the RIM-174 SM6 missile
    public static int RIM174_SM6_BoosterTime = 10; // Seconds
    public static float RIM174_SM6_BoosterAccel = 100; // Meters Per Second
    public static float RIM174_SM6_Mass = 1500f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Anti-Ship Missiles
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Zircon_Health = 20; // Health of the Zircon missile
    public static float Zircon_MaxRange = 15000f; // Max Range of the Zircon missile
    public static float Zircon_MinRange = 8000f; // Min Range of the Zircon missile
    public static float Zircon_MaxSpeed = 2500f * speedLimiterFactor; // Max Speed of the Zircon missile - MACH 9
    public static float Zircon_Inventory = 3.460f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Zircon_Mass = 1800f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Oniks_Health = 60; // Health of the Oniks missile
    public static int Oniks_BoosterTime = 8; // Seconds
    public static float Oniks_BoosterAccel = 15; // Meters Per Second
    public static float Oniks_SkimmingAltitude = 15f; // Meters
    public static float Oniks_TerminalApproachAltitude = 7f; // Meters
    public static float Oniks_TerminalApproachDistance = 300f; // Meters
    public static float Oniks_MaxRange = 15000f; // Max Range of the Oniks missile
    public static float Oniks_MinRange = 5000f; // Min Range of the Oniks missile
    public static float Oniks_MaxSpeed = 800f * speedLimiterFactor; // Max Speed of the Oniks missile
    public static float Oniks_Inventory = 2.520f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Oniks_Mass = 3000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Kalibr_Health = 40; // Health of the Kalibr missile
    public static int Kalibr_BoosterTime = 15; // Seconds
    public static float Kalibr_BoosterAccel = 45; // Meters Per Second
    public static float Kalibr_SkimmingAltitude = 50f; // Meters
    public static float Kalibr_TerminalApproachAltitude = 5f; // Meters
    public static float Kalibr_TerminalApproachDistance = 300f; // Meters
    public static float Kalibr_MaxRange = 15000f; // Max Range of the Kalibr missile
    public static float Kalibr_MinRange = 3000f; // Min Range of the Kalibr missile
    public static float Kalibr_MaxSpeed = 1000f * speedLimiterFactor; // Max Speed of the Kalibr missile
    public static float Kalibr_Mass = 3000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Moskit_Health = 80; // Health of the Moskit missile
    public static int Moskit_BoosterTime = 4; // Seconds
    public static float Moskit_BoosterAccel = 128; // Meters Per Second
    public static float Moskit_SkimmingAltitude = 20f; // Meters
    public static float Moskit_TerminalApproachAltitude = 7f; // Meters
    public static float Moskit_TerminalApproachDistance = 300f; // Meters
    public static float Moskit_MaxRange = 15000f; // Max Range of the Moskit missile
    public static float Moskit_MinRange = 3000f; // Min Range of the Moskit missile
    public static float Moskit_MaxSpeed = 1100f * speedLimiterFactor; // Max Speed of the Moskit missile
    public static float Moskit_Inventory = 4.370f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Moskit_Mass = 4000f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float RBU6000_Health = 50; // Health of the RBU-6000 missile
    public static float RBU6000_MaxRange = 2000f; // Max Range of the RBU-6000 missile
    public static float RBU6000_MinRange = 50f; // Min Range of the RBU-6000 missile
    public static float RBU6000_MaxSpeed = 300f * speedLimiterFactor; // Max Speed of the RBU-6000 missile
    public static float RBU6000_Inventory = 0.640f * inventoryMultiplier; // Inventory capacity in kL.
    public static float RBU6000_Mass = 110f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float VLS3S14_MaxRange = 15000f; // Max Range of the 3S14 VLS
    public static float VLS3S14_MinRange = 500f; // Min Range of the 3S14 VLS
    public static float VLS3S14_AA_MaxRange = 8000f; // Max Range of the 3S14 AA VLS
    public static float VLS3S14_AA_MinRange = 500f; // Min Range of the 3S14 AA VLS
    public static float VLS3S14_Inventory = 20.000f * inventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // 9M330 Missile
    public static float TOR_9M330_Health = 90;
    public static float TOR_9M330_MaxRange = 8000f; // Meters
    public static float TOR_9M330_MinRange = 100f; // Meters
    public static float TOR_9M330_MaxSpeed = 1000f * speedLimiterFactor; // m/s
    public static float TOR_9M330_Inventory = 0.12f * 3 * SAM_InventoryMultiplier; // kL
    public static float TOR_9M330_Mass = 165f; // Kilograms
    public static int TOR_9M330_BoosterBurnTime = 5 * 60; // Seconds (Tick Conversion: 1 second = 60 ticks)
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



    // Torpedoes
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float Futlyar_Health = 200; // Health of the Futlyar torpedo
    public static float Futlyar_MaxRange = 20000f; // Max Range of the Futlyar torpedo
    public static float Futlyar_MinRange = 5000f; // Min Range of the Futlyar torpedo
    public static float Futlyar_MaxSpeed = 50f; // Max Speed of the Futlyar torpedo
    public static float Futlyar_Inventory = 1.280f * inventoryMultiplier; // Inventory capacity in kL.
    public static float Futlyar_Mass = 2200f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Rockets
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static float B8M1_Health = 10; // Health of the B8M1 rocket
    public static float B8M1_MaxRange = 3000f; // Max Range of the B8M1 rocket
    public static float B8M1_MinRange = 100f; // Min Range of the B8M1 rocket
    public static float B8M1_MaxSpeed = 500f; // Max Speed of the B8M1 rocket
    public static float B8M1_Inventory = 0.76f * inventoryMultiplier; // Inventory capacity in kL.
    public static float B8M1_Mass = 20f; // Mass in kg.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}


public static class BombsConfig
{
    static float inventoryMultiplier = 1;

    public static float FAB500_Health = 500; // Health of the FAB-500 bomb
    public static float FAB500_Inventory = 0.190f * inventoryMultiplier; // Inventory capacity in kL.
    public static float FAB500_Mass = 500f; // Mass in kg.

    public static float KAB500KR_Health = 200; // Health of the KAB-500KR bomb
    public static float KAB500KR_MaxRange = 10000f; // Max Range of the KAB-500KR bomb
    public static float KAB500KR_MinRange = 0f; // Min Range of the KAB-500KR bomb
    public static float KAB500KR_Inventory = 0.310f * inventoryMultiplier; // Inventory capacity in kL.
    public static float KAB500KR_Mass = 500f; // Mass in kg.

    public static float KAB1500SM_Health = 220; // Health of the KAB-1500SM bomb
    public static float KAB1500SM_Inventory = 1.160f * inventoryMultiplier; // Inventory capacity in kL.
    public static float KAB1500SM_Mass = 1500f; // Mass in kg.

    public static float MOAB_Health = 150; // Health of the MOAB bomb
    public static float MOAB_Inventory = 7.600f * inventoryMultiplier; // Inventory capacity in kL.
    public static float MOAB_Mass = 9800f; // Mass in kg.


    public static float YAB10_Health = 300; // Health of the KAB-1500SM bomb
    public static float YAB10_Inventory = 1.160f * inventoryMultiplier; // Inventory capacity in kL.
    public static float YAB10_Mass = 1500f; // Mass in kg.
}






