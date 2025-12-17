# Blender to Unity Asset Pipeline

## 1. Modeling for mobile VR
- **Scale**: 1 Unit = 1 Meter.
- **Orientation**: Blender Z-up -> Unity Y-up. (Check "Apply Transform" in Blender export).
- **Origin Points**: Set origin to the center of mass for physics objects (critical for correct rotation in zero-G).

## 2. Texturing
- **PBR Workflow**: Use Standard Shader or URP Lit.
- **Texture Packing**: Pack Metallic, Smoothness, and Occlusion into a single texture map (R=Metallic, G=Occlusion, B=unused, A=Smoothness) to save memory samplers.
- **Resolution**: Max 1024x1024 for medium props. 256x256 for small items.

## 3. Export Settings (FBX)
- **Apply Scalings**: FBX All.
- **Forward**: -Z Forward.
- **Up**: Y Up.
- **Bake Animation**: Uncheck if static.

## 4. Unity Import
- **Materials**: Extract Materials if you need to edit them, otherwise keep embedded for tidiness.
- **Rig**: Set Animation Type to None for static props.
- **Collider**: Create custom simple box/capsule colliders in Blender with `UCX_` prefix for automatic collider generation, or add box colliders in Unity. Mesh Colliders are too expensive for mobile VR physics.
