# Unity VR Development Test Project for Interactive Reality Lab (Dr. Kopper)

## Project Description
This project is a VR interaction scenario developed for the Interactive Reality Lab test assignment. It meets and exceeds the outlined requirements by implementing teleportation, interactive objects, and UI elements, while adding creative enhancements such as a fully functional shooting range with various weapons, realistic textures, and a visually appealing environment for an immersive VR experience.

---

## Implementation Details

### Core Features
1. **VR Package Setup**:
   - Utilized the **OVR Meta XR package** included in the parent repository.
   - Used the following components:
     - **Grabbable** for picking up objects and enabling interactions.
     - **Teleport Interactable** for teleportation movement.
     - **Physics Materials** for creating a realistic bouncing effect for the sphere.

2. **Interactive Objects**:
   - Implemented a **3D button** on a **planned surface** using **Poke Interactable**, which spawns random objects in the scene.
   - Used the **Interactable Unity Event Wrapper** to change the cube’s color dynamically when grabbed.
   - Added a **Canvas UI** in the 3D world to display the number of spawned objects. A functional **UI button and a 3D button** were implemented to remove all generated objects.

3. **Enhanced Visuals**:
   - Added a **Sky Asset** for a more visually appealing sky environment.

### Additional Enhancements
1. **Shooting Range**:
   - Developed a fully interactive **shooting range**:
     - Targets react when shot and reset after a short duration.
     - Designed six unique and realistic guns:
       - **AR15**, **AK**, **M1911**, **Desert Eagle**, **Glock**, and **M870 Shotgun**.
       - Each gun features realistic shooting and reloading mechanics, achieved using scripting and animation.

2. **Immersive Audio**:
   - Integrated 3D audio clips for weapons and interactions to enhance realism and immersion.

3. **Environment Design**:
   - Used high-quality models, assets, and textures to create a user-friendly and visually appealing environment, avoiding placeholder objects.

4. **Material Optimization**:
   - Strategically applied materials and textures to improve object and environment realism.

---

