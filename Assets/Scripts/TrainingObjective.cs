using UnityEngine;
using UnityEngine.Events;

namespace ZeroGTrainingLab
{
    /// <summary>
    /// Simple objective system: Checks if specific objects are brought to a target zone or connected.
    /// </summary>
    public class TrainingObjective : MonoBehaviour
    {
        [Header("Objective Settings")]
        [Tooltip("The tag of the object needed to complete the task.")]
        public string targetObjectTag = "ComponentA";
        
        [Tooltip("The trigger zone where the assembly needs to happen.")]
        public Collider assemblyZone;

        [Header("Feedback")]
        public UnityEvent onTaskCompleted;
        public UnityEvent onIncorrectObject;
        
        private bool isCompleted = false;

        private void OnTriggerEnter(Collider other)
        {
            if (isCompleted) return;

            // Check if the object entering the zone is the correct component
            if (other.CompareTag(targetObjectTag))
            {
                // Verify it's not being held? (Optional: require release)
                // For now, just validation of position
                CompleteTask();
            }
            else if (other.GetComponent<ObjectManipulation>() != null)
            {
                // If it's a movable object but wrong one
                onIncorrectObject?.Invoke();
            }
        }

        private void CompleteTask()
        {
            isCompleted = true;
            Debug.Log("Training Objective Complete: Component Assembled!");
            onTaskCompleted?.Invoke();
            
            // Visual flair: Snap object to center, lock it, play sound, etc.
        }

        // Allow resetting for training loops
        public void ResetObjective()
        {
            isCompleted = false;
        }
    }
}
