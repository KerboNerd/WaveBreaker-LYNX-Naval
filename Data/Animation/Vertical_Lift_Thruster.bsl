@BlockID "Vertical_Lift_Thruster"
@Version 2
@WeaponCore 0

#--- Objects
using DoorLeft as subpart("DoorLeft")
using DoorRight as subpart("DoorRight")

using Blades1 as subpart("Blades1")
using Blades2 as subpart("Blades2")
using Blades3 as subpart("Blades3")
using Blades4 as subpart("Blades4")
using Blades5 as subpart("Blades5")
using Blades6 as subpart("Blades6")

using emitter_FanSmoke1 as Emitter("emitter_FanSmoke1")
using emitter_FanSmoke2 as Emitter("emitter_FanSmoke2")
using emitter_FanSmoke3 as Emitter("emitter_FanSmoke3")
using emitter_FanSmoke4 as Emitter("emitter_FanSmoke4")

var Extended = false
var Thrust = 0
var oldVal = 0

#--- Animations
func extend() {
        if (Extended == false) {

		
		DoorLeft.rotate([0, 1, 0], -110, 200, InOutCubic)
		DoorRight.rotate([0, 1, 0], 110, 200, InOutCubic)
		


        Extended = true
              }
    }
func retract() {
        if (Extended == true) {
		
		DoorLeft.rotate([0, 1, 0], 110, 200, InOutCubic)
		DoorRight.rotate([0, 1, 0], -110, 200, InOutCubic)
		Thrust = 0
		
		emitter_FanSmoke1.delay(120).stopparticle()
		emitter_FanSmoke2.delay(120).stopparticle()
		emitter_FanSmoke3.delay(120).stopparticle()
		emitter_FanSmoke4.delay(120).stopparticle()
        Extended = false
              }
    }
	
	
	
func SetThrust() {
	Thrust = Block.CurrentThrustPercent()
	
	
	var setVal = Thrust - oldVal;
	oldVal = Thrust
	if (Thrust>0) {
	emitter_FanSmoke1.playParticle("Lift_Thruster_Smoke", Thrust, 0.5)
	emitter_FanSmoke2.playParticle("Lift_Thruster_Smoke", Thrust, 0.5)
	emitter_FanSmoke3.playParticle("Lift_Thruster_Smoke", Thrust, 0.5)
	emitter_FanSmoke4.playParticle("Lift_Thruster_Smoke", Thrust, 0.5)
	}
	
	if (Thrust==0) {
	emitter_FanSmoke1.delay(60).stopparticle()
	emitter_FanSmoke2.delay(60).stopparticle()
	emitter_FanSmoke3.delay(60).stopparticle()
	emitter_FanSmoke4.delay(60).stopparticle()
	}
	
	Blades1.rotate([1, 0, 0], setVal*-45, 45, Linear)
	Blades2.rotate([1, 0, 0], setVal*-45, 45, Linear)
	Blades3.rotate([1, 0, 0], setVal*-45, 45, Linear)
	Blades4.rotate([1, 0, 0], setVal*-45, 45, Linear)
	Blades5.rotate([1, 0, 0], setVal*-45, 45, Linear)
	Blades6.rotate([1, 0, 0], setVal*-45, 45, Linear)
}
	

func reset() {
        Extended = false
		DoorLeft.reset()
		DoorRight.reset()
		Blades1.reset()
		Blades2.reset()
		Blades3.reset()
		Blades4.reset()
		Blades5.reset()
		Blades6.reset()
		Thrust = 0
		
    }
    
#--- Actions
action block() {
    
    working() {
        reset()
        extend()
    }
	
    notworking() {
        retract()
    }
	
	create() {
		api.startLoop("SetThrust", 20, -1)
	}
    built() {
		Thrust = Block.CurrentThrustPercent()
    }
} 
