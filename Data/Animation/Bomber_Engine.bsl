@BlockID "Bomber_Engine"
@Version 2

#--- Objects
using Deflector_0 as Subpart("Deflector_1")
using Deflector_1 as Subpart("Deflector_2")
using Deflector_2 as Subpart("Deflector_3")
using Deflector_3 as Subpart("Deflector_4")
using Deflector_4 as Subpart("Deflector_5")
using Deflector_5 as Subpart("Deflector_6")
using Deflector_6 as Subpart("Deflector_7")
using Deflector_7 as Subpart("Deflector_8")
using Deflector_8 as Subpart("Deflector_9")
using Deflector_9 as Subpart("Deflector_10")
using Deflector_10 as Subpart("Deflector_11")
using Deflector_11 as Subpart("Deflector_12")


var Thrust = 0
var oldVal = 0
var value = 0

func SetPosition() {
	Thrust = Block.CurrentThrustPercent()
	var setVal = Thrust - oldVal;
	oldVal = Thrust
	
	Deflector_0.rotate([-1, 0, 0], setVal * 5.5, 20, Linear)
	Deflector_1.rotate([-0.86, 0.5, 0], setVal * 5.5, 20, Linear)
	Deflector_2.rotate([-0.5, 0.86, 0], setVal * 5.5, 20, Linear)
	Deflector_3.rotate([0, 1, 0], setVal * 5.5, 20, Linear)
	Deflector_4.rotate([0.5, 0.86, 0], setVal * 5.5, 20, Linear)
	Deflector_5.rotate([0.86, 0.5, 0], setVal * 5.5, 20, Linear)
    Deflector_6.rotate([1, 0, 0], setVal * 5.5, 20, Linear)
	Deflector_7.rotate([0.86, -0.5, 0], setVal * 5.5, 20, Linear)
	Deflector_8.rotate([0.5, -0.86, 0], setVal * 5.5, 20, Linear)
	Deflector_9.rotate([0, -1, 0], setVal * 5.5, 20, Linear)
	Deflector_10.rotate([-0.5, -0.86, 0], setVal * 5.5, 20, Linear)
	Deflector_11.rotate([-0.86, -0.5, 0], setVal * 5.5, 20, Linear)
	
}

func reset() {
		Deflector_0.delay(25).reset()
		Deflector_1.delay(25).reset()
		Deflector_2.delay(25).reset()
		Deflector_3.delay(25).reset()
		Deflector_4.delay(25).reset()
		Deflector_5.delay(25).reset()
		Deflector_6.delay(25).reset()
		Deflector_7.delay(25).reset()
		Deflector_8.delay(25).reset()
		Deflector_9.delay(25).reset()
		Deflector_10.delay(25).reset()
		Deflector_11.delay(25).reset()
}


action block() {

    notworking() {
        
		reset()
    }
	
	create() {
		oldVal = Block.CurrentThrustPercent()
		api.startLoop("SetPosition", 20, -1)
	}
    built() {
		oldVal = Block.CurrentThrustPercent()
    }
}

