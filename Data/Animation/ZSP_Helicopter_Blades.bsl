@BlockID "ZSP_Helicopter_Blades"
@Version 2

#--- Objects
using RotorBlades as subpart("RotorBlades")

var Extended = false
var speed = 0.0
var maxSpeed = 5.0
var Thrust = 0
var maxSpeedCurrent = 0.0

func Rotation() {
	Thrust = Block.CurrentThrustPercent() * 100
	maxSpeedCurrent=Math.max(maxSpeed * Thrust/100, 1)
	
	if (Extended == true) {
		if (speed < maxSpeedCurrent) {
			speed = Math.min(speed + 0.6, maxSpeedCurrent)
		}
		if (speed >= maxSpeedCurrent) {
			speed = Math.min(speed - 0.2, maxSpeedCurrent)
		}
	}
	if (Extended == false) {
		speed = speed * 0.8
	}
	if (speed > 0.05) {
		RotorBlades.Spin([0, 0, 1], speed * -1, 200)
	}
	
}	


action Block() {
	create() {
		api.startLoop("Rotation", 20, -1)
	}
    built() {
		Thrust = Block.CurrentThrustPercent()
    }
	Working() { 
		Extended = true
	}
	NotWorking() { 
		Extended = false
	}
}

