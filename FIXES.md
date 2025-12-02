# WaveBreaker-LYNX-Naval Mod Fixes

## Fixed Issues

### Build Stage Model Fixes
After checking the filebase, found that most build stage models don't exist. Fixed by:

1. **LXN_STRELAM_1.sbc** - ✅ Removed BuildProgressModels (no BS models exist)
2. **LXN_AK130M_1.sbc** - ✅ Removed BuildProgressModels (no BS models exist)
3. **LXN_AK130M_2.sbc** - ✅ Removed BuildProgressModels (no BS models exist)
4. **LXN_AK220M_1.sbc** - ✅ Removed BuildProgressModels (no BS models exist)
5. **LXN_PALASHM_1.sbc** - ✅ Removed BuildProgressModels (no BS models exist)
6. **LXN_SubVLS_1.sbc** - ✅ Already using BS1 (exists in filebase)
7. **LXN_MFD_04.sbc** - ✅ Updated to use BS2/BS3 (BS1 doesn't exist, but BS2/BS3 do)
8. **LXN_ShipGyro_1_rudder.sbc** - ✅ Updated to use BS3 (BS1 doesn't exist, but BS3 does)

**Filebase Check Results:**
- STRELAM: No BS models exist (only main model + sub-models)
- PALASHM: No BS models exist (only main model + sub-models)
- AK130M: No BS models exist (only main model + sub-models)
- MFD: Has BS2 and BS3, but NO BS1
- ShipGyro: Has BS3, but NO BS1
- SubVLS: Has BS1 and BS3 (no BS2)

## Missing Resources

### Missing Textures

1. **LXN_9M330.sbc** (Definitions)
   - Missing: `Textures\GUI\Icons\Ammo\TT9M331G.dds`
   - Error: Resource not found, setting to null
   - File: `Data\Definitions\LXN_9M330.sbc`

2. **LXN_SubVLS_1.sbc** (ShipMissiles)
   - Missing: `Textures\GUI\Icons\Cubes\LXN_SubVLS_1.dds`
   - Error: Resource not found, setting to null
   - File: `Data\CubeBlocks\Weapons\ShipMissiles\LXN_SubVLS_1.sbc`

3. **LXN_ShipGyro_1_rudder.sbc** (Blocks)
   - Missing: `Textures\Icons\ShipGyro\LXN_ShipGyro_1_rudder.dds`
   - Error: Resource not found, setting to null
   - File: `Data\CubeBlocks\Blocks\LXN_ShipGyro_1_rudder.sbc`

### Missing Models

1. **LXN_9M330.sbc** (Definitions)
   - Missing: `Models\Ammo\TT9M331L.mwm`
   - Error: Resource not found, setting to error model
   - File: `Data\Definitions\LXN_9M330.sbc`

## Summary

- **Fixed Build Stage Models**: 8 files (removed non-existent BS models or updated to use existing BS2/BS3)
- **Missing Textures**: 3 unique files
- **Missing Other Models**: 1 file (ammo model)
- **Total Remaining Errors**: 4 unique resource errors

## Action Items

### Priority 1: Missing Textures
- `Textures\GUI\Icons\Ammo\TT9M331G.dds`
- `Textures\GUI\Icons\Cubes\LXN_SubVLS_1.dds`
- `Textures\Icons\ShipGyro\LXN_ShipGyro_1_rudder.dds`

### Priority 2: Missing Models
- `Models\Ammo\TT9M331L.mwm`

### Optional: Create Build Stage Models (for visual progression)
If you want build stage progression, these models would need to be created:
- `Models\STRELAM\LXN_STRELAM_1_BS1.mwm` / `BS2.mwm` / `BS3.mwm`
- `Models\PALASHM\LXN_PALASHM_1_BS1.mwm` / `BS2.mwm` / `BS3.mwm`
- `Models\AK130M\LXN_AK130M_1_BS1.mwm` / `BS2.mwm` / `BS3.mwm`
- `Models\AK130M\LXN_AK130M_2_BS1.mwm` / `BS2.mwm` / `BS3.mwm`
- `Models\MFD\LXN_MFD_04_BS1.mwm` (BS2 and BS3 already exist)
- `Models\ShipGyro\LXN_ShipGyro_1_rudder_BS1.mwm` / `BS2.mwm` (BS3 already exists)
