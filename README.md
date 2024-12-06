# Shakrin's Basic Unity VR Scene - Challenge Solution 

  

This repository contains my solution for the Unity VR challenge. The project demonstrates the use of Unity's XR Interaction Toolkit for creating a simple VR scene with interactive elements, including a spawner button and a counter system. The scene is designed for desktop testing using the XR Device Simulator. 

  

--- 

  

## Features 

  

### **1. Scene Objects** 

- A blue plane. 

- A red cube as table. 

- A yellow cube placed on the table. 

- A black sphere placed on the table. 

  

### **3. Canvas UI** 

- Includes a **Spawner** button to dynamically add objects to the scene. 

- A **CounterText (TMP)** element to display the number of the total objects in the scene. 

  

### **4. XR Device Simulator** 

- Allows simulation of VR interactions directly in the Unity Editor. 

- Useful for testing without a VR headset. 

  

--- 

  

## Scene Overview 

  

The following is a breakdown of the Unity scene hierarchy: 

  

- **OVRCameraRig**: Configured for VR camera and hand controller interactions. 

- **XR Interaction Manager**: Manages interactions and events within the VR scene. 

- **XR Origin (VR)**: 

  - Contains the Main Camera for rendering. 

  - Includes the LeftHand and RightHand Controllers for simulating hand input. 

- **Objects**: 

  - `Cube`: A yellow cube that changes color from yellow to green when grabbed. Again, the color changes back to yellow by releasing the grab action.  

  - `Sphere`: A black sphere could be grabbed and bounced realisticly. 

- **Teleportation**: 

  - A player can teleport within the plane except at the place of the table. The ray interection is enabled here. It shows red ray when player wants to teleport on the table or outside the plane. Otherwise, it shows green ray meaning that the player is allowed to teleport.  

- **Canvas**: 

  - A **Button** labeled "Spawner" to add new objects in random places within a certain range. 

  - **CounterText**: Displays the number of total objects in the scene. After spawning objects, it also updates the number. 

  

--- 

  

## How to Deploy and Run the Project 

  

### **1. Prerequisites** 

- **Unity Editor**: 

  - Version: Unity 2021.3 LTS or later. (used version:6000.0.23f1) 

  - Install Unity Hub to manage Unity installations. 

- **XR Interaction Toolkit**: 

  - Ensure the package is installed via Unity Package Manager. 

- **Git**: 

  - Install Git to clone the repository. 

  

--- 

  

### **2. Clone the Repository** 

To download the project, run the following commands in your terminal: 

```bash 

git clone https://github.com/Shakrin2020/basic-unity-vr-challenge.git 

cd basic-unity-vr-challenge 

``` 

--- 

  

### **3. Open the Project in Unity** 

- Launch Unity Hub. 

- Click Open and select the cloned project folder. 

  

### **4. Install Dependencies** 

- Go to Window > Package Manager. 

- Search for XR Interaction Toolkit in the Package Manager. (used version:2.5.4) 

- Install the package. 

  

### **5. Configure XR Settings** 

- Navigate to Edit > Project Settings > XR Plugin Management. 

- Enable VR support for your target platform: 

        - Oculus for Oculus Quest devices. 

        - OpenXR for cross-platform compatibility. 

  

### **6. Test in Unity Editor** 

- Open the BasicVRScene file from the Assets folder. 

- Click the Play button in the Unity Editor to test the scene. 

- Use the XR Device Simulator to simulate VR interactions without requiring a VR headset: 

            - Enable the simulator via Window > Analysis > XR Device Simulator. 

  

### **7. Build the Project** 

- Navigate to File > Build Settings. 

- Select your target platform: Windows: For PC VR. 

- Click Build and Run to deploy the application on your target device. 

  

  

### **7. Interaction Instructions: Using XR Device Simulator** 

- Activate the XR Device Simulator in Unity (Window > Analysis > XR Device Simulator). 

- Use the keyboard and mouse to simulate VR interactions: 

       - WASDQE: Move the simulators. [W,S: forward, backward, A,D: left-right, Q,E: up-down] 

       - Simulate hand grip and select objects. (keyboard: Shift+G) 

       - Interact with the Spawner button to spawn objects. (mouse: left click) 

 