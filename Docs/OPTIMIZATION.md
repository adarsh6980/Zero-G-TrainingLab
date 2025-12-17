# VR Optimization Guide

Maintaining 72 FPS (Quest 1) or 90/120 FPS (Quest 2/3) is critical for preventing motion sickness and ensuring immersion.

## General Guidelines

### 1. Geometry & Draw Calls
- **Poly Count**: Keep individual props under 5k tris.
- **Batching**: Use Static Batching for all non-moving station geometry.
- **GPU Instancing**: Use for repeated small objects (screws, tools).

### 2. Lighting
- **Baked Lighting**: Use Baked Global Illumination for the station static geometry. Realtime lighting is expensive.
- **Shadows**: Disable shadows on small dynamic objects if possible, or use "Hard Shadows" only.

### 3. Physics
- **Layer Collision Matrix**: distinct layers for `Hands`, `Interactables`, `Station`. Disable collisions between `Hands` and `Station` to prevent jitter checking.
- **Fixed Timestep**: default 0.02 (50Hz) is usually fine, but ensure complex calculations aren't running every step.

## Hand Tracking Optimization
Hand tracking meshes are deformations.
- Be careful with `SkinnedMeshRenderer` cost.
- Only update physics colliders for the bones that actually matter (fingertips, palm) for interaction.

## Code Optimization (`PerformanceOptimizer.cs`)
- **Object Pooling**: Do not Instantiate/Destroy objects at runtime. Pool everything.
- **Garbage Collection**: Avoid `new` in Update loops. Cache references in `Awake`.
- **LOD Group**: Force lower LODs if framerate drops.
