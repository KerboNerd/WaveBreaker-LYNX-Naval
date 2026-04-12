@BlockID "30mm_Autocannon_Turret"
@Version 2
@WeaponCore 0

#--- Objects
using MissileTurretBase1 as subpart("MissileTurretBase1")

using MissileTurretBarrels as subpart("MissileTurretBarrels") parent MissileTurretBase1
using Barrel as subpart("Barrel") parent MissileTurretBarrels


using Ejector_Door as subpart("Ejector_Door") parent MissileTurretBarrels

using Emissive as Emissive("Emissive0") parent MissileTurretBarrels

#--- Animations
func BarrelMove() {

	Barrel.translate([0, 0, -0.14], 2, OutCubic)
	Barrel.delay(2).translate([0, 0, 0.14], 2, OutCubic)
	
	
	Ejector_Door.delay(1).translate([-0.03, -0.01, 0], 2, OutCubic)
	Ejector_Door.delay(3).translate([0.03, 0.01, 0], 2, OutCubic)
	Ejector_Door.delay(5).reset()

}


func ResetBarrel() {
		Barrel.reset()
    }

    
#--- Actions
action weaponcore() {
	firing() {
		ResetBarrel()
		BarrelMove()
	}
	init() {
		ResetBarrel()
	}

}


action Block() {
	Working() { 
		Emissive.SetColor(0, 150, 0, 5.0, false)
	}
	NotWorking() { 
		Emissive.SetColor(150, 0, 0, 5.0, false)
	}
}