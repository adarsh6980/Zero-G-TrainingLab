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
   - **Architecture**: **ARM64**.

---

## 🎨 Part 2: Materials Setup

Create these materials in `Assets/Materials/` (Create > Material).

| Material Name | Shader | Properties |
| :--- | :--- | :--- |
| **MetallicComponent** | `URP/Lit` | **Albedo**: Gray (128, 128, 128)<br>**Metallic**: 1.0<br>**Smoothness**: 0.9 |
| **TargetZoneGlow** | `URP/Lit` | **Albedo**: Green (0, 255, 100)<br>**Alpha**: 0.5 (set Surface Type to *Transparent*)<br>**Emission**: Green (Intensity 2.0) |
| **SpaceStation** | `URP/Lit` | **Albedo**: Dark Blue (20, 40, 60)<br>**Metallic**: 0.3<br>**Smoothness**: 0.6 |

---

## 🏗️ Part 3: Complete Scene Hierarchy

Open `Assets/Scenes/ZeroGTrainingLab.unity` and match this hierarchy structure:

```text
Scene: ZeroGTrainingLab
├── GameManager
│   ├── GravityManager.cs
│   ├── PerformanceOptimizer.cs
│   └── Camera Offset / XR Origin (XR Rig)
│
├── Lighting
│   ├── Directional Light (Sun)
│   └── Ambient Settings
│
├── SpaceStation (Parent)
│   ├── Floor (Cube, Scaled 10,1,10)
│   ├── Walls (Cubes)
│   └── Docking Port (Optional Visuals)
│
├── TrainingObjects (Parent)
│   ├── Component_A (Primitive Cube)
│   │   ├── Rigidbody (Mass: 1, Drag: 0.1, AngDrag: 0.05, UseGravity: OFF)
│   │   ├── Box Collider
│   │   └── ObjectManipulation.cs
│   ├── Component_B
│   └── Component_C
│
├── TargetZones (Parent)
│   ├── TargetZone_A (Position: X=5, Y=0, Z=0)
│   ├── TargetZone_B (Position: X=-5, Y=0, Z=0)
│   └── TargetZone_C (Position: X=0, Y=5, Z=0)
│
├── UI (Canvas)
│   └── Canvas
│       ├── ObjectiveText (TextMeshPro)
│       └── TrainingObjective.cs (Attached here or to Manager)
│
└── Environment (Optional)
    └── Starfield (Skybox)
```

---

## 🔧 Part 4: Key Configuration Values

Tune these values in the Inspector for the best experience.

### GameManager (GravityManager)
- **Gravity Scale**: `0` (True Zero-G).
- **Air Resistance**: `0.99` (Simulates thick space vacuum or pressurized module air).

### Managers (PerformanceOptimizer)
- **Target Frame Rate**: `90` (Standard for Quest).

### XR Origin (HandInteractionHandler)
- Locate the object with `HandInteractionHandler` (likely on your Hand prefab or XR Rig).
- **Grab Threshold**: `0.8` (Fingers must be close to pinch).

### Grabbable Objects (ObjectManipulation)
- **Throw Force Multiplier**: `5.0` (Amplifies hand movement for satisfying throws).

### UI / Logic (TrainingObjective)
- **Proximity Threshold**: `0.5` (Accuracy required for placing objects in zones).
