@BlockID "TTMK13"
@Version 2
@WeaponCore 0
@Author DarkXeRoX

#Declarations
using azi as Subpart("azimuth")
using ele as Subpart("elevation") parent azi
using Hatch as Subpart("Hatch") parent azi

using RIM66 as Subpart("RIM66") parent ele
using RGM84 as Subpart("RGM84") parent ele


#Functions

func ShowModelOnStartup() {
    RIM66.setvisible(false)
    RGM84.setvisible(false)


    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM84.setvisible(true)
    }    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM66.setvisible(true)
    }    
}


func ReloadAnimation(){
    RIM66.setvisible(false)

    RGM84.setvisible(false)


    RIM66.Translate([0, 0, -5], 0, Linear)
    RGM84.Translate([0, 0, -5], 0, Linear)

    Hatch.Translate([0, -0.025, 0], 30, Linear)
    Hatch.delay(30).Rotate([0, 1, 0], 90, 90, Linear)

    ele.delay(90).Rotate([1, 0, 0], -75, 90, Linear)

    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM84.delay(200).setvisible(true)
    }    

    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM66.delay(200).setvisible(true)
    }    

    RIM66.delay(240).Translate([0, 0, 5], 60, OutCubic)
    RGM84.delay(240).Translate([0, 0, 5], 60, OutCubic)

    ele.delay(400).Rotate([1, 0, 0], 75, 90, Linear)

    Hatch.delay(400).Rotate([0, 1, 0], -90, 90, Linear)
    Hatch.delay(500).Translate([0, 0.025, 0], 30, Linear)

}


func ShowModelOnReload() {
    RIM66.setvisible(false)
    RGM84.setvisible(false)

    if (weaponcore.getactiveammo() == "RGM-84 Harpoon") {
    RGM84.delay(900).setvisible(true)
    }    

    
    else if (weaponcore.getactiveammo() == "RIM-66 AA") {
    RIM66.delay(900).setvisible(true)
    }    
}

func HideModel() {
    RIM66.setvisible(false)
    RGM84.setvisible(false)
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
    reloading() {
        ReloadAnimation()
    }
}