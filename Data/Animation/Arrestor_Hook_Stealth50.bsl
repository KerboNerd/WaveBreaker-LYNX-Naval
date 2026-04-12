@BlockID "Arrestor_Hook_Stealth50"
@Version 2
@WeaponCore 0

#--- Objects
using DoorLeft as subpart("DoorLeft")
using DoorRight as subpart("DoorRight")

using Hook as subpart("Hook")

var speed = 0.0
var Extended = false

#--- Animations
func Retraction() {
	
	if ( speed < 100 ) {
		if (Extended == false) {
			DoorLeft.reset()
			DoorRight.reset()
			Hook.reset()
			
			DoorLeft.rotate([0, 0, 1], -110, 35, InOutCubic)
			DoorRight.rotate([0, 0, 1], 110, 35, InOutCubic)

			Hook.delay(20).rotate([1, 0, 0], 40, 35, Linear)

			Extended = true
		}
	}
	if ( speed > 100 ) {
		if (Extended == true) {

			DoorLeft.delay(35).rotate([0, 0, 1], 110, 35, InOutCubic)
			DoorRight.delay(35).rotate([0, 0, 1], -110, 35, InOutCubic)

			Hook.rotate([1, 0, 0], -40, 35, Linear)
			Extended = false
		}
	}
	speed = Math.abs(Grid.getspeed())
}	
    
#--- Actions
action block() {
    Create() {
		API.StartLoop("Retraction", 20, -1)
	}
}