# Unity VR Development Test Project for Interactive Reality Lab (Dr. Kopper)

## Overview
This repository contains a bare Unity project set up for VR development. Your task is to demonstrate your Unity and VR development skills by completing the challenge described below.

## Challenge
Create a simple VR interaction scenario with the following requirements:

1. Implement a VR player controller that allows for teleportation movement
2. Create three interactable objects in the scene:
   - A cube that changes color when grabbed
   - A sphere that can be thrown and bounces realistically
   - A button that, when pressed, spawns a new random object in the scene
3. Implement a simple UI element that displays the number of objects in the scene
4. Ensure the project runs smoothly on a VR headset (e.g., Oculus Quest 2 or Mock HMD).

Note: You are encouraged to go beyond these minimal requirements and showcase your creativity and skills.

## Deadline
The project is due 2 weeks after it's assigned.

## Submission
To submit your solution:
1. Fork this repository
2. Complete the challenge
3. Push your changes to your forked repository
4. Submit a pull request to the original repository
5. Modify this README.md file to include documentation about your solution and instructions to deploy
6. Contact Dr. Kopper to schedule a meeting and demonstrate the project

## Evaluation Criteria
Your submission will be evaluated based on:
- Correct implementation of VR interactions
- Code quality and organization
- Performance optimization
- Creativity in solving the challenge
- Quality of documentation and deployment instructions
Good luck!

# Documentation

## Overview
![Scene.png](DocumentAssets%2FScene.png)
This is a VR horror game developed based on Unity and Meta XR interaction libraries and Wwise audio middleware. 
The player will be born in the mission starting location, get the weapons and equipment needed for the mission through the UI window, 
find and defeat 31 zombies in the darkness to complete the mission.

## Player Locomotion/Interaction

The player uses a controller to navigate and interact within the game. 
Movement is controlled via teleportation, with the teleportation destinations determined by the pre-baked Nav Mesh of the map. 
The controller also enables players to grab and throw objects.

Additionally, the controller supports ray-based interaction with the UI. 
A ray emitted from the controller assists the player in selecting and clicking on UI elements.

## Weapon Interaction

### Glow Stick
![GlowStick.png](DocumentAssets%2FGlowStick.png)
The glow stick is one of the only two lighting tools in the game. When obtained, it starts in an unlit state. 
By grabbing it with the controller and pressing the trigger button, the glow stick can be lit. 
Pressing the trigger again will extinguish it. The glow stick uses two different materials for its lit and unlit states. 
The lit state material has a self-illuminating property. Additionally, the glow stick contains a point light source, 
which is responsible for influencing the lighting in the scene.

### Grenades
![Grenade.png](DocumentAssets%2FGrenade.png)
Like the glow stick, grenades also have realistic gravity properties. When the player throws a glow stick or a grenade to the ground, 
they will bounce upwards, achieved by configuring the physical material properties of the ground.

Grenades are a type of large-scale attack weapon, capable of devastatingly destroying zombies and weapon items within their range.
To use a grenade, grab it with the right-hand controller, press the A button, and throw it. 
The grenade will explode after 5 seconds. The destruction affects only zombies and weapons, 
leaving other elements in the scene untouched. This is implemented using Unity’s custom layers, 
where only the layers containing weapons and zombies detect the explosion.

### Rifle
![Rifle.png](DocumentAssets%2FRifle.png)
The rifle is a long-range damage weapon equipped with a laser sight under the barrel to assist with aiming. 
When holding the rifle with the left hand, pressing the left-hand trigger will fire the weapon.
The rifle supports dual-handed control, allowing players to grab it with both hands to adjust its rotation for more precise aiming at zombies.
Each shot produces a brief muzzle flash, illuminating the environment in the direction the muzzle is pointing.

Shooting based on infrared aiming is implemented using Unity's raycasting method. 
A ray is cast along the muzzle's direction, and the properties of the object it hits are used to determine whether it is a zombie and calculate the damage dealt accordingly.
For the muzzle flash effect, a spotlight is placed at the muzzle, 
which is activated during shooting to create the lighting effects in the scene.

## UI interactions
![UI.png](DocumentAssets%2FUI.png)
To the right of the player's spawn point is a UI panel that displays the number of weapons generated and the remaining number of zombies. 
On the left side of the panel, a dropdown menu allows players to select the type of item to generate. 
In the center, a slider lets players choose the quantity of the item to generate, ranging from a minimum of 0 to a maximum of 10.
On the right, a "Spawn Weapon" button creates the selected items when pressed.

The UI panel supports ray interaction with the controller. It is surrounded by a collision volume of the same size, 
which is used for raycast detection to facilitate interaction.

## Zombies
![Zombie.png](DocumentAssets%2FZombie.png)
At the start of the game, zombies spawn at fixed locations in the environment and come in two states: 
standing zombies and crawling zombies feeding on the ground. 
Defeating a zombie requires three rifle shots or a single grenade explosion.

When hit by a bullet for the first time, zombies begin to chase the player. 
Standing zombies stagger forward, while crawling zombies approach by crawling. 
After being hit a second time, the zombies' eyes emit a yellow glow. On the third hit, the zombies disappear.

The control of zombie animations is handled using Unity's animation state machine, 
where the zombies' states determine the skeletal animations played. 
Zombie movement to chase the player is managed by a Nav Mesh Agent, 
which uses the pre-baked Nav Mesh of the scene to automatically navigate toward the player's position.

## Wwise SFX
![Wwise.png](DocumentAssets%2FWwise.png)

Wwise, used as the audio plugin for Unity, replaces Unity's native audio playback system. The game incorporates five types of sound effects: 
glow stick toggle, zombie elimination, gunfire, grenade explosion, and zombie idle sounds. 
All sound effects are configured with 3D attenuation, adjusting the volume based on the player's distance and direction relative to the sound source.

The zombie idle sound effect uses a Random Container, which randomly selects one of three different zombie idle sounds for playback. 
Additionally, it includes a random initial delay between consecutive plays.

## Game Scene

The game's environment is based on free assets from the Unity Asset Store, modified to fit the setting. 
The original daytime HDRI was replaced with a nighttime starry sky HDRI, and the scene lighting was reconfigured, 
reducing the intensity of the light sources. 
Additionally, volumetric fog was added to limit the player's visibility.

# Demo Video
【Unity VR Development Test Project for Interactive Reality Lab】 https://www.bilibili.com/video/BV191mZY5EHy/?share_source=copy_web&vd_source=6aa869f68a48ddddeacee34dc346827a

# Deployment

## Unity Project File

- Hardware requirement
  - Minimum RAM: 16 GB
  - Disk Space: 15 GB
  - Processer: Intel i9 13900H
  - Oculue Quest 2
- Software requirement
  - Wwise 2023.1.8.8601 (for SoundBank Edit)
  - Unity Editor 6.0.23.f1
  - Meta Quest Link

### How to Start The Project

1. Clone the repository from Github
2. Open the Project file with Unity Editor 6.0.23.f1
3. Connect your Quest with WIFI or cable through Meta Quest Link
4. Start Quest Link in your Quest 2
5. Press Play button in Unity and wait

## Oculus APK

Wait for future develop..




