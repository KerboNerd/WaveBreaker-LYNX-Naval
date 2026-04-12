@BlockID "25mm_Rotary_Cannon_Stealth"
@Version 2

#--- Objects
using Door as subpart("Door")

var Extended = false

#--- Animations
func extend() {
        if (Extended == false) {
		
		Door.translate([0.07, -0.07, 0], 15, InOutCubic)


        Extended = true
              }
    }
func retract() {
        if (Extended == true) {
			
		Door.translate([-0.07, 0.07, 0], 15, InOutCubic)
			


        Extended = false
              }
    }
func reset() {
        Extended = false
		Door.reset()

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
}