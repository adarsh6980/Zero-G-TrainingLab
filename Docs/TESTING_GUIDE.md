# Testing & Verification Guide

## 🖥️ Editor Testing (XR Simulator)
To test hand interactions without a headset:

1. **Install XR Device Simulator**:
   - Ensure `XR Interaction Toolkit` is installed.
   - Go to `Assets/Samples/XR Interaction Toolkit/[Version]/XR Device Simulator` (Import sample if needed via Package Manager).
   - Alternatively, enable it via **Window > Analysis > XR Interaction Debugger** or **Window > XR > XR Device Simulator** (Unity 2023+).

2. **Setup in Scene**:
   - If not automatically handled by the XR Origin, drag the `XR Device Simulator` prefab into your scene.

3. **Controls (Standard)**:
   - **Move Hand**: `Left Shift` / `Space` + Mouse.
   - **Rotate Hand**: `Right Click` + Mouse.
   - **Grab (Grip)**: `G` / `Mouse Buttons`.
   - **Pinch (Trigger)**: `Left Click`.

---

## 📦 Build & Deployment

### 1. For Meta Quest (Standalone)
**Target**: Run natively on the headset.

1. **Build Settings**:
   - Platform: **Android**.
   - Texture Compression: **ASTC**.
   - Architecture: **ARM64** (Critical for Quest).
2. **Scenes in Build**:
   - Add `Assets/Scenes/ZeroGTrainingLab.unity`.
3. **Deploy**:
   - Connect Quest via USB (Developer Mode enabled).
   - Click **Build And Run**.

### 2. For PC VR (Link / AirLink / Simulation)
**Target**: Run on computer, view in headset via Link or Monitor.

1. **Build Settings**:
   - Platform: **PC, Mac & Linux Standalone**.
   - Target Platform: **Windows** (Architecture: x64).
2. **Deploy**:
   - Click **Build And Run**.

---

## ✅ Verification Checklist
- [ ] **Hand Tracking**: Do hands appear and track fingers correctly?
- [ ] **Zero-G Physics**: Do objects float when released?
- [ ] **Interaction**: Can you grab objects with a pinch gesture?
- [ ] **Performance**: Is the framerate smooth? (Target: 72/90 FPS).

## 🐞 Troubleshooting
- **Black Screen**: Check OpenXR Render Mode (Single Pass Instanced vs Multi-pass).
- **No Hands**: Ensure "Meta Hand Tracking Aims" is enabled in XR Plug-in Management.
