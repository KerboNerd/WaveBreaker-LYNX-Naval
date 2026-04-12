@BlockID "Bomber_Intake"
@Version 2

#--- Objects
using Fan_Front as subpart("Fan_Front")
using Fan_Back as subpart("Fan_Back")

var Active = false
var speed = 0.0
var maxSpeed = 5


#--- Animations

func Rotation() {
	if (Active == true) {
		speed = Math.min(speed + 0.15, maxSpeed)
		
	}
	if (Active == false) {
		speed = speed * 0.75
	}
	if (speed > 0.05) {
		Fan_Front.Spin([0, 0, 1], speed * -1, 200)
		Fan_Back.Spin([0, 0, 1], speed, 200)
	}
}	
	
func reset() {
        Active = false

		Fan_Front.reset()
		Fan_Back.reset()
    }
    
#--- Actions
action block() {
	Create() {
		API.StartLoop("Rotation", 20, -1)
	}
    working() {
        reset()
		Active = true
    }
    notworking() {
		Active = false
    }
}
