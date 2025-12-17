using UnityEngine;
using UnityEngine.Events;

namespace ZeroGTrainingLab
{
    /// <summary>
    /// Abstract base for handling hand interactions.
    /// Intended to be used with XR Hands or Oculus Integration.
    /// </summary>
    public class HandInteractionHandler : MonoBehaviour
    {
        [Header("Interaction Settings")]
        public float grabRadius = 0.1f;
        public LayerMask interactableLayer;
        public Transform pinchPoint; // Assign the index finger tip or pinch center

        [Header("Events")]
        public UnityEvent<GameObject> onObjectGrabbed;
        public UnityEvent<GameObject> onObjectReleased;

        private GameObject currentHeldObject = null;
        private bool isPinching = false;

        private void Update()
        {
            CheckHandInput();
        }

        private void CheckHandInput()
        {
            // Placeholder: Replace with actual XR Hands SDK data access
            // float pinchStrength = HandTrackingSubsystem.GetPinchStrength();
            float pinchStrength = 0f; // Mock value

            bool currentlyPinching = pinchStrength > 0.8f;

            if (currentlyPinching && !isPinching)
            {
                AttemptGrab();
            }
            else if (!currentlyPinching && isPinching)
            {
                ReleaseObject();
            }

            isPinching = currentlyPinching;

            if (currentHeldObject != null)
            {
                // Move object to hand position (simple follow)
                // In a real scenario, use velocity-based movement or rigid body joints
                currentHeldObject.transform.position = pinchPoint.position;
                currentHeldObject.transform.rotation = pinchPoint.rotation;
            }
        }

        private void AttemptGrab()
        {
            Collider[] hits = Physics.OverlapSphere(pinchPoint.position, grabRadius, interactableLayer);
            if (hits.Length > 0)
            {
                // Grab the closest one (simple logic)
                currentHeldObject = hits[0].gameObject;
                
                var manipulatable = currentHeldObject.GetComponent<ObjectManipulation>();
                if (manipulatable != null)
                {
                    manipulatable.OnGrab();
                }

                onObjectGrabbed?.Invoke(currentHeldObject);
            }
        }

        private void ReleaseObject()
        {
            if (currentHeldObject != null)
            {
                var manipulatable = currentHeldObject.GetComponent<ObjectManipulation>();
                if (manipulatable != null)
                {
                    // Calculate throw velocity based on recent hand motion (omitted for brevity)
                    Vector3 throwVelocity = Vector3.forward; // Placeholder
                    Vector3 throwAngularVelocity = Vector3.zero;
                    
                    manipulatable.OnRelease(throwVelocity, throwAngularVelocity);
                }

                onObjectReleased?.Invoke(currentHeldObject);
                currentHeldObject = null;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (pinchPoint != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(pinchPoint.position, grabRadius);
            }
        }
    }
}
