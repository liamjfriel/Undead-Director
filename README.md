## Undead Director

Undead Director is a simple top down twin stick shooter/real time strategy hybrid game for PC that was made using XNA with C#. It was created as part of my third year "Games Development" module during my BSc. Applied Computing program and achieved an A-Grade.

### Code structure

The game uses the Model View Controller design pattern, the "update" game design pattern, the sub-class sandbox design pattern and a game loop.

Below is the class diagram created during the design phase. There was very little deviation in the development stag with only the “Sniper Rifle” and “HUD Renderer” classes being removed. All other classes featured in the diagram appear in the final product, in the exact relationships that they previously had. The only exception to this is "WorldRenderer" which does appear but inherits from an abstract class “Renderer”. A controller was added for every game state also (menu, game world, game over screen etc.) rather than just having one “WorldController” controller. This is the same for the Renderer classes, every Controller has a related Renderer (the view in MVC).

![Undead Director class diagram](http://i.imgur.com/R8FuoZH.png?1)

### Gameplay

The game can be played by a single player (versus one of three AI personalities chosen randomly at the game start) or by up to four players locally through the use of multiple controllers. One player (or AI) controls the zombies on screen, spawns "special" zombies using resources that generate over time or triggers effects in their quest to wipe out the team of survivors. The other player(s) control human characters that shoot zombies using a typical twin stick shooter gameplay style.

Zombies come in different shapes and sizes. The "director" (the person controlling the zombie horde) can spawn several different types of zombies. Common zombies are controlled by invisible flag moved by the left analogue stick, special zombies by an invisible flag controlled by the right analogue stick.


* Common
	* Run of the mill zombie that spawns automatically, runs at normal pace and controllable by the left stick.
* Exploder
	* Explodes upon death, killing any survivors in the radius. Costs resources to spawn. 
* Juggernaught 
	* Slower than other zombies, takes several hits to kill. 
* Speeder
`	* Much faster than the other zombies, but dies with a single bullet.

The director can also trigger several different effects to aid their quest in killing all survivors. 

* Zombie speed increase 
	* Increase the movement speed of all zombies on screen for 1000 resources.
* Player slow 
	* Decrease the movement speed of all survivors for 1000 resources.
* Spawn weapon
	* Give the survivors a random weapon at a random location in return for a 1000 resource REWARD.

Survivors can pick up weapons that spawn on screen and use them (providing they have enough ammunition left). 

* Pistol
	* Standard weapon, slow fire rate but infinite ammo.
* Assault Rifle
	* Faster fire rate, but limited ammo.
* Shotgun
	* Bullet spread, but limited ammo.


![Main menu](http://i.imgur.com/ncwFiWW.png)

![Player 1 with an assault rifle fighting zombies](http://i.imgur.com/HQEbMWM.jpg)

![How to play screen](http://i.imgur.com/CAINah3.png)

![Game over screen](http://i.imgur.com/F2bY2yR.png)