@BlockID "TTMK26"
@Version 2
@WeaponCore 0
@Author DarkXeRoX

#Declarations
using azi as Subpart("azimuth")
using ele as Subpart("elevation") parent azi

using RIM661 as Subpart("RIM66_L") parent ele
using RIM662 as Subpart("RIM66_R") parent ele
using RGM841 as Subpart("RGM84_L") parent ele
using RGM842 as Subpart("RGM84_R") parent ele

using HatchL as Subpart("HatchL")
using HatchR as Subpart("HatchR")

var ShotsFired = 0

#Functions

func ShowModelOnStartup() {
    RIM661.setvisible(false)
    RIM662.setvisible(false)
    RGM841.setvisible(false)
    RGM842.setvisible(false)

    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM841.setvisible(true)
    RGM842.setvisible(true)
    }    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM661.setvisible(true)
    RIM662.setvisible(true)
    }    
}

func ShowModelOnReload() {
    RIM661.setvisible(false)
    RIM662.setvisible(false)
    RGM841.setvisible(false)
    RGM842.setvisible(false)

    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM841.delay(900).setvisible(true)
    RGM842.delay(1200).setvisible(true)
    }    

    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM661.delay(900).setvisible(true)
    RIM662.delay(1200).setvisible(true)
    }    
}
func HideMissile() {
    RIM661.setvisible(false)
    RGM841.setvisible(false)
}


func ReloadAnimation(){
    RIM661.setvisible(false)
    RIM662.setvisible(false)
    RGM841.setvisible(false)
    RGM842.setvisible(false)

    RIM661.Translate([0, 0, -5], 0, Linear)
    RIM662.Translate([0, 0, -5], 0, Linear)
    RGM841.Translate([0, 0, -5], 0, Linear)
    RGM842.Translate([0, 0, -5], 0, Linear)

    HatchL.Translate([0, -0.025, 0], 30, Linear)
    HatchR.Translate([0, -0.025, 0], 30, Linear)
    HatchL.delay(30).Rotate([0, 1, 0], -90, 90, Linear)
    HatchR.delay(30).Rotate([0, 1, 0], 90, 90, Linear)

    ele.delay(90).Rotate([1, 0, 0], -75, 90, Linear)

    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM841.delay(200).setvisible(true)
    RGM842.delay(200).setvisible(true)
    }    

    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM661.delay(200).setvisible(true)
    RIM662.delay(200).setvisible(true)
    }    

    RIM661.delay(240).Translate([0, 0, 5], 60, OutCubic)
    RIM662.delay(240).Translate([0, 0, 5], 60, OutCubic)
    RGM841.delay(240).Translate([0, 0, 5], 60, OutCubic)
    RGM842.delay(240).Translate([0, 0, 5], 60, OutCubic)

    ele.delay(400).Rotate([1, 0, 0], 75, 90, Linear)

    HatchL.delay(500).Rotate([0, 1, 0], 90, 90, Linear)
    HatchR.delay(500).Rotate([0, 1, 0], -90, 90, Linear)
    HatchL.delay(600).Translate([0, 0.025, 0], 30, Linear)
    HatchR.delay(600).Translate([0, 0.025, 0], 30, Linear)

}


func HideModel() {
    RIM661.setvisible(false)
    RIM662.setvisible(false)
    RGM841.setvisible(false)
    RGM842.setvisible(false)
}

#Actions

action block() {
    built() {
        HideModel()
    }
    create() {
        HideModel()
    }
    working() {
        ShowModelOnStartup()
    }
    notworking() {
        HideModel()
    }
}

action weaponcore() {
    firing() {
        ShotsFired = ShotsFired + 1
        HideMissile()
    }

    reloading() {
        ReloadAnimation()
    }
}