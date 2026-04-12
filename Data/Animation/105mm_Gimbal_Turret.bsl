@BlockID "105mm_Gimbal_Turret"
@Version 2
@WeaponCore 0

#--- Objects
using MissileTurretBase1 as subpart("MissileTurretBase1")

using MissileTurretBarrels as subpart("MissileTurretBarrels") parent MissileTurretBase1
using Barrel as subpart("Barrel") parent MissileTurretBarrels

using AmmoLoader as subpart("AmmoLoader") parent MissileTurretBarrels
using AmmoLoaderDoor as subpart("Door") parent AmmoLoader


#--- Animations
func OpenOnFire() {

	Barrel.translate([0, 0, -0.14], 7, OutCubic)
	Barrel.delay(7).translate([0, 0, 0.14], 7, OutCubic)
	
	AmmoLoader.translate([0, 0, -0.45], 7, OutCubic)

	AmmoLoaderDoor.delay(120).rotate([0, 0, 1], 135, 30, OutCubic)

}

func CloseOnReload() {
	AmmoLoader.delay(205).translate([0, 0, 0.45], 15, InOutCubic)
	AmmoLoaderDoor.delay(180).rotate([0, 0, 1], -135, 25, OutCubic)
}


func reset() {
		Barrel.reset()
		AmmoLoader.reset()
		AmmoLoaderDoor.reset()
		
		
		
    }

    
#--- Actions
action weaponcore() {
	firing() {
		reset()
		OpenOnFire()
	}
	reloading() {
		CloseOnReload()
	}
	init() {
		reset()
	}

}