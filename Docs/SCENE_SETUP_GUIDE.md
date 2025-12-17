# ZeroGTrainingLab Scene & Project Setup Guide

Follow this guide to configure your Unity project, scene hierarchy, and visuals.

## ⚙️ Part 1: Project & XR Settings

### 1. XR Plugin Management
1. Go to **Edit > Project Settings > XR Plug-in Management**.
2. **Android Tab** (for Quest):
   - Check **OpenXR**.
   - Check **Meta XR Core SDK**.
   - Under **OpenXR > Features**:
     - Enable **Hand Interaction Profiles**.
     - Enable **Meta Hand Tracking Aims**.
3. **PC Tab** (for Development):
   - Check **OpenXR**.

### 2. Player Settings
1. Go to **Edit > Project Settings > Player > Android Tab**.
2. **Other Settings**:
   - **Graphics API**: Ensure **OpenGL ES 3.0** is first (or Vulkan if using recent Quest updates, but GLES3 is safer).
   - **Identification > Package Name**: `com.yourname.zerogtraining` (Change `yourname` to your name).
   - **Minimum API Level**: Android 12 (API level 31).

---

## 🎨 Part 2: Materials Setup

Create these materials in `Assets/Materials/` (Create > Material).

| Material Name | Shader | Properties |
| :--- | :--- | :--- |
| **MetallicComponent** | `URP/Lit` | **Albedo**: Gray (128, 128, 128)<br>**Metallic**: 1.0<br>**Smoothness**: 0.9 |
| **TargetZoneGlow** | `URP/Lit` | **Albedo**: Green (0, 255, 100)<br>**Alpha**: 0.5 (set Surface Type to *Transparent*)<br>**Emission**: Green (Intensity 2.0) |
| **SpaceStation** | `URP/Lit` | **Albedo**: Dark Blue (20, 40, 60)<br>**Metallic**: 0.3<br>**Smoothness**: 0.6 |

---

## 🏗️ Part 3: Scene Hierarchy Setup

Open `Assets/Scenes/ZeroGTrainingLab.unity` and create the following structure:

### 1. Global Managers
Create an empty GameObject named `GameManager`.
- Attach **`GravityManager.cs`**.
- Attach **`PerformanceOptimizer.cs`**.

### 2. Lighting
- **Directional Light**:
  - **Color**: Slightly Blue (Space feel).
  - **Intensity**: 1.2.
  - **Shadow Type**: Hard Shadows.

### 3. Environment
Create an empty GameObject named `SpaceStation`.
- **Tag**: Untagged.
- **Components**:
  - Add **Box Collider** (Size: 10, 1, 10) -> *Floor reference*.
  - Add **Mesh Renderer** (optional visual floor) -> Material: `SpaceStation`.

### 4. Interactive Objects (TrainingComponents)
Create 2-3 primitive objects (Cube, Cylinder). For each:
- **Tag**: `Grabbable` (You may need to Add Tag).
- **Material**: `MetallicComponent`.
- **Components**:
  - **Rigidbody**:
    - Mass: `1`.
    - Drag: `0.1`.
    - Angular Drag: `0.05`.
    - Use Gravity: **Unchecked** (OFF).
    - Collision Detection: **Continuous**.
  - **Box/Capsule Collider**.
  - **`ObjectManipulation.cs`**.

### 5. Objectives (TargetZones)
Create empty GameObjects positioned where you want the "Drop Zone".
- **Visuals**: Add a child Sphere/Cube with `TargetZoneGlow` material.
- **Components**:
  - **Collider**: Is Trigger **Checked**.

### 6. UI Overlay
1. Right-click > UI > Canvas.
2. **Canvas Scaler**: Scale with Screen Size.
3. Add **TextMeshPro - Text (UI)**.
   - Position: Top-Center.
   - Attach **`TrainingObjective.cs`** to the Canvas or a dedicated UI Manager object.
   - Assign the Text element to the script's `Objective Display` field.

---

## ✅ Checklist
- [ ] XR Plug-in Management is configured for OpenXR.
- [ ] Materials are created and assigned.
- [ ] `GameManager` exists with `GravityManager` script.
- [ ] `Grabbable` objects have Rigidbodies with `Use Gravity: False`.
