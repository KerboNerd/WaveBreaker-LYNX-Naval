@BlockID "Reliable_Jet_Engine_Intake"
@Version 2

#--- Objects

using Fan as subpart("Fan")



var Rotate = false
var speed = 0.0
var maxSpeed = 2


#--- Animations
	
func Rotation() {
	if (Rotate == true) {
		speed = Math.min(speed + 0.3, maxSpeed)
	}
	if (Rotate == false) {
		speed = speed * 0.5
	}
	if (speed > 0.05) {
		Fan.Spin([0, 0, 1], speed * -1, 200)
	}
}	
	
    
#--- Actions
action block() {
	Create() {
		API.StartLoop("Rotation", 20, -1)
	}
    working() {
        Rotate=true
    }
    notworking() {
        Rotate=false
    }
}
