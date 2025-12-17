# Zero-Gravity Physics Implementation

In **ZeroGTrainingLab**, we simulate a microgravity environment. Standard Unity physics assumes a constant downward force (-9.81 m/s²). We continuously counteract this or disable global gravity to achieve "floating" behavior.

## Core Concepts

### 1. Disabling Global Gravity
We set `Physics.gravity = Vector3.zero` or specific Rigidbody components use `useGravity = false`.

### 2. Micro-Drag (Air Resistance)
In a space station environment, there is air, so objects don't float forever without stopping. We apply a very low drag coefficient to simulate air resistance.
- **Linear Drag**: ~0.1
- **Angular Drag**: ~0.05

### 3. Hand-Imparted Velocity (Throwing)
When an object is thrown, the velocity isn't just the instant velocity of release. It's often better calculated from a weighted average of the last few frames of hand movement to smooth out tracking jitter.
- **Formula**: `Velocity = (CurrentPos - PrevPos) / DeltaTime`
- **Smoothing**: buffer the last 5 frames of velocity and average them on release.

### 4. Collisions
Objects bounce with realistic restitution. We use Physic Materials with:
- **Bounciness**: 0.6 (slightly elastic)
- **Friction**: 0.2 (low friction on tech surfaces)

## Implementation Details (`GravityManager.cs`)

The `GravityManager` can optionally apply a slight "drift" force to all objects to simulate station rotation or ventilation currents, adding life to the scene.

```csharp
void FixedUpdate() {
    foreach (var rb in floatingObjects) {
        // Apply tiny random torque for zero-G drift
        rb.AddTorque(Random.insideUnitSphere * driftTorqueAmount);
    }
}
```
