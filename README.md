Prey 2017, GOO Recreation
Prey’s GLOO Cannon:

The genius of the GLOO Cannon comes from its varied uses. Much like Mario’s cap in Odyssey and Kratos’ axe in God of War (2018), the cannon is an almost necessary tool in Prey. From stunning enemies, to covering hazards of fire or toxic goo, to path creation and platforming, this cannon is insanely important, and interesting; so I’d like to recreate it.

What are the core elements of the GLOO Cannon? First of all, it is a projectile-shooting cannon with a max amount of ammo until it needs to be reloaded with GLOO canisters. These projectiles are interpolated and affected by gravity. Upon hitting any surface, these projectiles create a solid ball-shaped blob that can be walked upon, leaving room for path-creation and platforming. If they hit a surface with toxic goo, fire, or electricity, they clear the path on top of creating these solid mounds of GLOO, except with electricity, which breaks through the GLOO after a while. If these projectiles hit broken pipes emitting fire or hot steam, they will cover the hole and thus clear the path. Finally, GLOO can be used to slow down enemies by completely stunning them in place. After a little while, the GLOO will break apart and the enemies will be able to move again.

To keep my scope simple, I plan on recreating only two of GLOO’s many uses: platforming, and path clearing. However, if I have time, I will try to create enemies that can be slowed down. 

Shooting:
	Shooting sounds simple, although it could be a bit complicated. I need to have a counter for the max amount of GLOO a canister can hold, and only allow shooting if and only if the canister is not empty. This means I will also need collectibles for canisters that refresh your shooting (I’ll ignore reloads to make this easier). The gun should instantiate a gloo blob game object (with a trail, for added effect) that falls with gravity but is pushed with a certain force.

Platforming:
	Here, I want to create a system that creates a prefab object wherever the projectile lands (as long as that area is not tagged an enemy). I will have to limit the amount of prefabs that can be in place at a time if I want the ability to be similar to the game, and to limit processing power, and I cannot have GLOO stick to GLOO. GLOO should not be affected by gravity, either, as it only exists wherever it is stuck to. Finally, this prefab object must have colliders so that it may a) be walked upon/obstruct the path, and b) may be destroyed by the player. 

Path Clearing:
	For this, I will need to have game objects with colliders with custom tags, such as “Fire”, or “Toxic Goo”. These game objects will have particle systems that show their respective hazards, will hurt the player, and then be diminished (particleSystem.Stop()) by the GLOO gun upon collision. 

