@BlockID "Tiltrotor_Blades_Emissive"
@Version 2

#--- Objects
using Blades as subpart("Blades")
using Ring as subpart("Ring")

using EmissiveMain as Emissive("Emissive") parent Blades
using EmissiveRing as Emissive("Emissive1") parent Ring

var Extended = false
var speed = 0.0
var maxSpeed = 5.0
var Thrust = 0
var maxSpeedCurrent = 0.0

func Rotation() {
	Thrust = Block.CurrentThrustPercent() * 100
	maxSpeedCurrent=Math.max(maxSpeed * Thrust/100, 0.3)
	
	if (Extended == true) {
		if (speed < maxSpeedCurrent) {
			speed = Math.min(speed + 0.3, maxSpeedCurrent)
		}
		if (speed >= maxSpeedCurrent) {
			speed = Math.min(speed - 0.1, maxSpeedCurrent)
		}
	}
	if (Extended == false) {
		speed = speed * 0.8
	}
	if (speed > 0.05) {
		Blades.Spin([0, 0, 1], speed * -1, 200)
		Ring.Spin([0, 0, 1], speed * -0.75, 200)
	}
	if (speed < maxSpeed * 0.95) {
		Ring.setvisible(false)
		EmissiveRing.SetColor(0, 0, 0, 1.0, false)
	}
	if (speed > maxSpeed * 0.95) {
		Ring.setvisible(true)
		EmissiveRing.SetColor(0, 255, 0, 1.0, false)
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
		EmissiveMain.SetColor(0, 255, 0, 1.0, false)
		Extended = true
	}
	NotWorking() { 
		EmissiveMain.SetColor(0, 0, 0, 1.0, false)
		Extended = false
	}
}

