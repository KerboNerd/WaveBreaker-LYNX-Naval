@BlockID "Retractable_ATGM"
@Version 2
@WeaponCore 0

#--- Objects
using Door_UP as subpart("Door_UP")
using Door_DOWN as subpart("Door_DOWN")

using Launcher as subpart("Launcher")
using Door1 as subpart("Door1") parent Launcher
using Door2 as subpart("Door2") parent Launcher
using Door3 as subpart("Door3") parent Launcher
using Door4 as subpart("Door4") parent Launcher

using Emitter_1 as Emitter("emitter_1")
using Emitter_2 as Emitter("emitter_2")
using Emitter_3 as Emitter("emitter_3")
using Emitter_4 as Emitter("emitter_4")

var Extended = false
var shotcounter = 0

var Door1b = false
var Door2b = false
var Door3b = false
var Door4b = false


#--- Animations
func extend() {
        if (Extended == false) {
		
		Launcher.delay(12).translate([-0.495, 0, 0], 60, OutCubic)
		
		
		Door_UP.rotate([0, 0, 1], 110, 30, OutCubic)
		Door_DOWN.rotate([0, 0, 1], -110, 30, OutCubic)
		
		
		
		
		

        Extended = true
              }
    }
func retract() {
        if (Extended == true) {
		
		Launcher.delay(35).translate([0.495, 0, 0], 60, OutCubic)

		Door_UP.delay(83).rotate([0, 0, 1], -110, 30, OutCubic)
		Door_DOWN.delay(83).rotate([0, 0, 1], 110, 30, OutCubic)
		
        Extended = false
              }
    }
	
	
	
func OpenDoors() {
	if ( shotcounter==1) {
		Door1.rotate([1, 0, 0], -100, 15, OutCubic)
		Emitter_1.playParticle("Laser_Guided_Missile_Launch",1.0,0.5)
		Emitter_1.delay(60).stopparticle()
		Door1b=true

	}
	if ( shotcounter==2) {
		Door2.rotate([1, 0, 0], -100, 15, OutCubic)
		Emitter_2.playParticle("Laser_Guided_Missile_Launch",1.0,0.5)
		Emitter_2.delay(60).stopparticle()
		Door2b=true

	}
	if ( shotcounter==3) {
		Door3.rotate([1, 0, 0], 100, 15, OutCubic)
		Emitter_3.playParticle("Laser_Guided_Missile_Launch",1.0,0.5)
		Emitter_3.delay(60).stopparticle()
		Door3b=true

	}
	if ( shotcounter==4) {
		Door4.rotate([1, 0, 0], 100, 15, OutCubic)
		Emitter_4.playParticle("Laser_Guided_Missile_Launch",1.0,0.5)
		Emitter_4.delay(60).stopparticle()
		Door4b=true
	}
}

func CloseDoors() {
	if ( Door1b==true) {
		Door1b=false
		Door1.delay(20).rotate([1, 0, 0], 100, 15, OutCubic)
		shotcounter=0	
	}
	if ( Door2b==true) {
		Door2b=false
		Door2.delay(20).rotate([1, 0, 0], 100, 15, OutCubic)
		shotcounter=0

	}
	if ( Door3b==true) {
		Door3b=false
		Door3.delay(20).rotate([1, 0, 0], -100, 15, OutCubic)
		shotcounter=0

	}
	if ( Door4b==true) {
		Door4b=false
		Door4.delay(20).rotate([1, 0, 0], -100, 15, OutCubic)
		shotcounter=0
	}
}

func CloseDoorsNoReset() {
	if ( Door1b==true) {
		Door1b=false
		Door1.rotate([1, 0, 0], 100, 15, OutCubic)
	}
	if ( Door2b==true) {
		Door2b=false
		Door2.rotate([1, 0, 0], 100, 15, OutCubic)

	}
	if ( Door3b==true) {
		Door3b=false
		Door3.rotate([1, 0, 0], -100, 15, OutCubic)
	}
	if ( Door4b==true) {
		Door4b=false
		Door4.rotate([1, 0, 0], -100, 15, OutCubic)
	}
}

	

func reset() {
        Extended = false
		Launcher.reset()
		Door_UP.reset()
		Door_DOWN.reset()
		Door1.reset()
		Door2.reset()
		Door3.reset()
		Door4.reset()
    }
    
#--- Actions
action block() {
    
    working() {
        reset()
        extend()
    }
	
    notworking() {
		CloseDoorsNoReset()
        retract()
    }
}

action weaponcore() {
	prefire() {
		shotcounter=shotcounter+1
		OpenDoors()
	}
	reloading() {
		CloseDoors()
	}

}
