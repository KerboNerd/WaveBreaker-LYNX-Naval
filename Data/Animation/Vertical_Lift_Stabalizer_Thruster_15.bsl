@BlockID "Vertical_Lift_Stabalizer_Thruster_15"
@Version 2
@WeaponCore 0

#--- Objects
using LeftDoor as subpart("LeftDoor")
using RightDoor as subpart("RightDoor")

using Blades1 as subpart("Blades1")
using Blades2 as subpart("Blades2")
using Blades3 as subpart("Blades3")

using emitter_FanSmoke1 as Emitter("emitter_FanSmoke1")
using emitter_FanSmoke2 as Emitter("emitter_FanSmoke2")

var Extended = false
var Thrust = 0
var oldVal = 0

#--- Animations
func extend() {
        if (Extended == false) {

		
		LeftDoor.rotate([0, 0.25, 1], 110, 120, InOutCubic)
		RightDoor.rotate([0, 0.25, 1], -110, 120, InOutCubic)
		


        Extended = true
              }
    }
func retract() {
        if (Extended == true) {
		
		LeftDoor.rotate([0, 0.25, 1], -110, 120, InOutCubic)
		RightDoor.rotate([0, 0.25, 1], 110, 120, InOutCubic)
		Thrust = 0
		
		emitter_FanSmoke1.delay(120).stopparticle()
		emitter_FanSmoke2.delay(120).stopparticle()
		
        Extended = false
              }
    }
	
	
	
func SetThrust() {
	Thrust = Block.CurrentThrustPercent()
	
	
	var setVal = Thrust - oldVal;
	oldVal = Thrust
	if (Thrust>0) {
	emitter_FanSmoke1.playParticle("Lift_Thruster_Smoke", Thrust*0.35, 0.5)
	emitter_FanSmoke2.playParticle("Lift_Thruster_Smoke", Thrust*0.35, 0.5)
	
	}
	
	if (Thrust==0) {
	emitter_FanSmoke1.delay(60).stopparticle()
	emitter_FanSmoke2.delay(60).stopparticle()
	
	}
	
	Blades1.rotate([1, 0, 0], setVal*-60, 45, Linear)
	Blades2.rotate([1, 0, 0], setVal*-60, 45, Linear)
	Blades3.rotate([1, 0, 0], setVal*-60, 45, Linear)
	
}
	

func reset() {
        Extended = false
		LeftDoor.reset()
		RightDoor.reset()
		Blades1.reset()
		Blades2.reset()
		Blades3.reset()
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
