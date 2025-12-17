using UnityEngine;

namespace ZeroGTrainingLab
{
    [RequireComponent(typeof(Rigidbody))]
    public class ObjectManipulation : MonoBehaviour
    {
        private Rigidbody rb;
        private GravityManager gravityManager;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            gravityManager = FindObjectOfType<GravityManager>(); // Simple dependency injection
            
            // Ensure object starts floating
            if (gravityManager != null)
            {
                gravityManager.RegisterObject(rb);
            }
        }

        public void OnGrab()
        {
            // When grabbed, physics should not control position - the hand does.
            // set isKinematic to true for direct transform control
            rb.isKinematic = true;
        }

        public void OnRelease(Vector3 velocity, Vector3 angularVelocity)
        {
            // Re-enable physics
            rb.isKinematic = false;

            // Apply thrown forces
            rb.velocity = velocity;
            rb.angularVelocity = angularVelocity;

            // Ensure gravity manager is still aware (it should be, but just in case)
            if (gravityManager != null)
            {
                gravityManager.RegisterObject(rb);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Optional: Haptic feedback hook could go here
            // Debug.Log($"Interactable collided with {collision.gameObject.name} with impact {collision.impulse.magnitude}");
        }
    }
}
