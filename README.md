# ZeroGTrainingLab 🚀

A zero-gravity interactive training/puzzle scenario where users manipulate objects in weightlessness using hand tracking. This project demonstrates advanced VR mechanics, physics, and optimization techniques.

## 🌟 Key Features

- **Zero-Gravity Physics**: Objects float, rotate, and collide with realistic separation and drag in a microgravity environment.
- **Hand Tracking Integration**: Full hand tracking support using XR Hands and Meta SDK for intuitive grabbing, throwing, and manipulation.
- **Interactive Training Task**: "Assemble a component" objective to test fine motor skills in zero-G.
- **Optimized for VR**: High-performance implementation targeting standalone VR headsets.
- **Futuristic Aesthetics**: Custom 3D assets and UI designed for a sci-fi space station setting.

## 📂 Project Structure

```
ZeroGTrainingLab/
├── README.md               # You are here
├── Assets/
│   ├── Scripts/            # C# Logic (Gravity, Interaction, Game Flow)
│   ├── 3D Models/          # Blender Assets
│   ├── Materials/          # Visuals
│   ├── Prefabs/            # Reusable Objects
│   └── Scenes/             # ZeroGTrainingLab.unity
├── Docs/
│   ├── ARCHITECTURE.md     # System Design
│   ├── PHYSICS.md          # Gravity Implementation Details
│   ├── OPTIMIZATION.md     # VR Performance Tips
│   └── BLENDER_ASSET_PIPELINE.md # Asset Workflow
└── ProjectSettings/
```

## 🛠️ Setup & Requirements

1. **Unity Version**: 2022 LTS or 2023+
2. **Rendering Pipeline**: Universal Render Pipeline (URP) - Recommended for standalone VR performance.
3. **Target Platform**:
    - **Development**: PC Standalone (Windows/Mac)
    - **Deployment**: Android (Meta Quest 3/Pro/2)
4. **Packages**:
    Open the **Unity Package Manager** (`Window > Package Manager`), click list icon + `Add package by name` (or find in Unity Registry) and install:
    - **XR Plugin Management** (should be auto-installed by others, or check Project Settings)
    - **OpenXR Plugin** (Cross-platform VR support)
    - **Meta XR Core SDK** (For hand tracking on Quest)
    - **XR Interaction Toolkit** (`com.unity.xr.interaction.toolkit`)
    - **XR Hands** (`com.unity.xr.hands`)
    - **TextMesh Pro** (Usually pre-installed)

## 🚀 Getting Started

1. **Create New Project**:
    - Open Unity Hub.
    - Click "New Project".
    - Select **3D (URP)** template.
    - Name it `ZeroGTrainingLab`.
2. **Setup File Structure**:
    - Copy the `Assets` and `Docs` folders from this repository into your new Unity project's root folder.
3. **Configure XR**:
    - Go to `Edit > Project Settings > XR Plug-in Management`.
    - Enable **OpenXR** (and Meta Quest Support feature group) for Android.
    - Enable **OpenXR** (or Mock HMD) for PC Standalone.
4. **Open Scene**:
    - Open `Assets/Scenes/ZeroGTrainingLab.unity`.
    - Hit Play to test with simulated hands.

## 🤝 Contributing

Contributions are welcome! Please review the [Architecture Guide](Docs/ARCHITECTURE.md) before submitting a PR.
