# Unity VR Development Test Project

This project is my solution to the Unity VR Development Test Project provided by Dr. Kopper. It includes the following features:

## Features
1. **Teleportation Movement**: Implemented a teleportation system using mouse click for selecting teleportation points.
2. **Interactable Objects**:
   - A **cube** that changes color when pressed "Space" bar.
   - A **sphere** that can be thrown and bounces realistically.
   - A **button** that spawns random objects in the scene.
3. **UI Element**: Displays the current number of objects in the scene and updates dynamically.
4. **Random Object Deletion**: A button allows the users to randomly delete one of the spawned objects.

## Documentation
### Teleportation
- Implemented teleportation using a 'TeleportController' script.
- Teleportation points are selected with the mouse, and the camera position is updated accordingly.

### Interactable Objects
- **Cube**: Changes to a random color when typing the "space" bar using the 'ChangeColorOnGrab' script.
- **Sphere**: Can be thrown with realistic physics using the 'ThrowBall' script.
- **Button**: Spawns random objects, including cubes and spheres, using the 'ObjectSpawner' script.

### Object Counter
- A UI counter implemented with TextMeshPro dynamically displays the current number of objects in the scene.

### Random Deletion
- Implemented a 'DeleteRandomObject' method in the 'ObjectSpawner' script to randomly delete spawned objects.

## Deployment Instructions
1. Clone this repository.
2. Open the project in Unity (version 2023.2 or higher recommended).
3. Press the Play button to test the features.
4. Interact with objects and use the UI to spawn and delete objects dynamically.