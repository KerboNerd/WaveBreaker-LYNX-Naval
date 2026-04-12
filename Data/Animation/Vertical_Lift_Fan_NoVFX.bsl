@BlockID "Vertical_Lift_Fan_NoVFX"
@Version 2

#--- Objects
using Piston as subpart("Piston")
using Door as subpart("Door")
using Fan as subpart("Fan")


var Extended = false
var speed = 0.0
var maxSpeed = 4


#--- Animations
func extend() {
        if (Extended == false) {
		
		Piston.translate([0, -0.115, 0], 240, InOutCubic)
		Door.rotate([1, 0, 0], 40, 240, InOutCubic)
        Extended = true
              }
    }
func retract() {
        if (Extended == true) {
			
		Piston.delay(120).translate([0, 0.115, 0], 240, InOutCubic)
		Door.delay(120).rotate([1, 0, 0], -40, 240, InOutCubic)
        Extended = false
              }
    }
	
	
func Rotation() {
	if (Extended == true) {
		speed = Math.min(speed + 0.3, maxSpeed)
	}
	if (Extended == false) {
		speed = speed * 0.5
	}
	if (speed > 0.05) {
		Fan.Spin([0, 1, 0], speed * -1, 200)
	}
}	
	
func reset() {
        Extended = false
		Piston.reset()
		Door.reset()
		Fan.reset()
    }
    
#--- Actions
action block() {
	Create() {
		API.StartLoop("Rotation", 20, -1)
	}
    working() {
        reset()
        extend()
    }
    notworking() {
        retract()
    }
}
