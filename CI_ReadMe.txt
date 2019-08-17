Cylon Invasion Read Me

TODO list
Get Permission: BSG is an owned IP, game cannot be released without IP Owner's permission!

Commits
-Aug 9, 2019 @ 17:40 (PDT)
	Initiation of Project
	Creation of Terrain
-Aug 9, 2019 @ 19:54 (PDT)
	Started Prototyping a Viper Mk II in Blender
	Added 4 reference images
	Web search yeilds
		a ship length of 8.85m (approx 29ft 1/25th in)
			Ship width to be scaled based on ref images
		Mass = 12,824 kg
		Accelleration:
			Norm: 73.5 m/s^2
			Boost: 110.25 m/s^2
			Retro (braking): -55.125 m/s^2
		Weapons 2 Laser Torpedoes (Pump Lasers)
		Twin Fusion Plants (output: 58.4*10^12 Joules)		
		Tylium Reactor (output: 144.3*10^12 Joules)
-Aug 11, 2019 @ 14:13 (PDT)
	Loaded background music and created player for it
	Set up Camera Path via waypoints
	added Logo to Splash screen
		note: need to work on transparency!!!
-Aug 11, 2019 @ 19:46 (PDT)
	Created ship control script and tuned ship movement.
-Aug 12, 2019 @ 09:38
	Added Laser Cannons to Player Ship
	Created an explosion fX
-Aug 12, 2019 @ 20:39
	Made Music Player persistant
	Made Level Loader persistant
	Added Death sequence to player ship
	Created model for enemy ship
	Added Enemy ship model to Unity
	enabled laser damage on enemy
	Left TODO: fix bug where level does not reload on player death
	Left TODO: fix bug where Mesh Collider not recieving particle collisions
-Aug 15, 2019 @10:43
	Changed Cylon Raider collider to a Box Collider
	Instantiated enemy colliders at runtime
	instantiated enemy death effects on particle collisions
	Created Cleaner script
	Added Namespaces (Core, Control)
	Added UI Score text
	Added protection against ORIOs for enemy deathFX.parent
-August 15, 2019
	instantiated Scoring methodollogy
