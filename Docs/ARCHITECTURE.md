# Architecture Overview

This document outlines the system architecture for **ZeroGTrainingLab**. The project follows a modular, component-based architecture to ensure maintainability and separation of concerns.

## Core Systems

### 1. Physics System (GravityManager)
- **Responsibility**: Manages the global gravity settings and individual object physics behavior in a microgravity environment.
- **Key Components**: `GravityManager.cs`
- **Interaction**: Applies forces to `Rigidbody` components on every `FixedUpdate`.

### 2. Interaction System (HandInteractionHandler, ObjectManipulation)
- **Responsibility**: Handles user input via hand tracking to grab, throw, and manipulate objects.
- **Key Components**: `HandInteractionHandler.cs`, `ObjectManipulation.cs`
- **Interaction**: detecting proximity, calculating throw velocity based on hand movement history.

### 3. Game Flow & Objective System (TrainingObjective)
- **Responsibility**: Manages the user's task (component assembly), tracks progress, and provides feedback.
- **Key Components**: `TrainingObjective.cs`
- **Interaction**: Listens for "assembly events" (e.g., two objects connecting) and updates the UI.

### 4. Performance System (PerformanceOptimizer)
- **Responsibility**: Monitors frame rate and dynamically adjusts quality settings (LOD bias, particle counts) to maintain a steady 72/90 FPS.
- **Key Components**: `PerformanceOptimizer.cs`

## Data Flow

1. **Input**: User moves hands → XR Hands SDK detects pose.
2. **Interaction**: `HandInteractionHandler` translates pose to interaction events (Grab, Release).
3. **Physics**: `ObjectManipulation` takes control of the object (isKinematic = true while held).
4. **Release**: On release, `ObjectManipulation` calculates velocity vector from recent hand positions and hands control back to `GravityManager` (isKinematic = false).
5. **Simulation**: `GravityManager` applies micro-drag and gentle rotation dampening.
6. **Objective**: If object collisions match verify criteria, `TrainingObjective` marks step complete.

## Directory Structure Strategy
- **Scripts** are flat for now but can be sub-foldered by system (`Physics`, `Interaction`, `UI`) if the project grows.
- **Prefabs** act as the primary configuration points for objects.
- **Interfaces** are used where components need to communicate without tight coupling (e.g., `IGrabbable`).
