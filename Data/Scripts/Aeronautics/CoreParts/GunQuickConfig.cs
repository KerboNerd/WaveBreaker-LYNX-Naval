// This file contains the quick-configuration for guns.

public static class GunConfig
{
    static float inventoryMultiplier = 1;

    // Naval Guns
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int AK220M_ROF = 10; // Rate of Fire of the AK-220M gun
    public static float AK220M_MaxTargetDistance = 4000f; // Max Range of the AK-220M gun
    public static float AK220M_MinTargetDistance = 500f; // Min Range of the AK-220M gun
    public static float AK220M_Inventory = 0.410f * inventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static int AK130M_ROF = 30; // Rate of Fire of the AK-130M gun
    public static float AK130M_MaxTargetDistance = 3000f; // Max Range of the AK-130M gun
    public static float AK130M_MinTargetDistance = 300f; // Min Range of the AK-130M gun
    public static float AK130M_Inventory = 0.410f * inventoryMultiplier; // Inventory capacity in kL.
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
}