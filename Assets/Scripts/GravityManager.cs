using UnityEngine;
using System.Collections.Generic;

namespace ZeroGTrainingLab
{
    /// <summary>
    /// Manages the physics state for zero-gravity simulation.
    /// Disables global gravity and applies micro-drag and drift to registered objects.
    /// </summary>
    public class GravityManager : MonoBehaviour
    {
        [Header("Zero-G Settings")]
        [Tooltip("Linear drag applied to emulate air resistance in the station.")]
        public float microGravityDrag = 0.1f;
        
        [Tooltip("Angular drag applied to emulate air resistance.")]
        public float microGravityAngularDrag = 0.05f;

        [Tooltip("Simulates slight ventilation currents or station rotation.")]
        public float ambientDriftForce = 0.02f;

        private List<Rigidbody> floatingObjects = new List<Rigidbody>();

        private void Awake()
        {
            // Disable global gravity for the scene
            Physics.gravity = Vector3.zero;
        }

        public void RegisterObject(Rigidbody rb)
        {
            if (!floatingObjects.Contains(rb))
            {
                floatingObjects.Add(rb);
                rb.useGravity = false;
                rb.drag = microGravityDrag;
                rb.angularDrag = microGravityAngularDrag;
            }
        }

        public void UnregisterObject(Rigidbody rb)
        {
            if (floatingObjects.Contains(rb))
            {
                floatingObjects.Remove(rb);
            }
        }

        private void FixedUpdate()
        {
            // Apply ambient drift
            foreach (var rb in floatingObjects)
            {
                if (!rb.isKinematic)
                {
                    // Random small torque for natural floating feel
                    rb.AddTorque(Random.insideUnitSphere * ambientDriftForce * Time.fixedDeltaTime, ForceMode.Impulse);
                }
            }
        }
    }
}
