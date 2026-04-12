@BlockID "30mm_Drum"
@Version 2

#---Declarations---
using Handle as Subpart("Handle")

var storageLevel = 1.0

#--- Utility Functions
func ResetHandle() {
	Handle.reset()
}


#---Handle Animations---
func PlayHandle() {
	Handle.rotate([ 1, 0, 0], 90.0, 75, InOutCubic)
	Handle.delay(80).rotate([ 1, 0, 0], -90.0, 30, InOutCubic)
}

#---Actions---

action inventory() {
	Changed(InvLvl){
		if (InvLvl != storageLevel) { 
			storageLevel = InvLvl
			ResetHandle()
			PlayHandle()
		}
	}
}
