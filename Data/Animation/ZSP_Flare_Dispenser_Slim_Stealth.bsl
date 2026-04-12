@BlockID "ZSP_Flare_Dispenser_Slim_Stealth"
@Version 2

#--- Objects
using Door_Left as subpart("Door_Left")
using Door_Right as subpart("Door_Right")


var Extended = false

#--- Animations
func extend() {
        if (Extended == false) {
        Door_Right.rotate([0, 1, 0], 110, 15, InOutCubic)
		Door_Left.rotate([0, 1, 0], -110, 15, InOutCubic)

		

        Extended = true
              }
    }
func retract() {
        if (Extended == true) {

		Door_Right.rotate([0, 1, 0], -110, 15, InOutCubic)
		Door_Left.rotate([0, 1, 0], 110, 15, InOutCubic)


        Extended = false
              }
    }
func reset() {
        Extended = false
        Door_Right.reset()
		Door_Left.reset()

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