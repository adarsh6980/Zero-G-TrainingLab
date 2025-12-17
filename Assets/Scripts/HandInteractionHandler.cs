using UnityEngine;
using UnityEngine.XR.Hands;

public class HandInteractionHandler : MonoBehaviour
{
    [SerializeField] private XRHandTrackingEvents handTrackingEvents;
    [SerializeField] private float grabThreshold = 0.8f;
    
    private XRHand hand;
    private bool isGrabbing = false;
    private GameObject currentGrabbedObject = null;

    private void OnEnable()
    {
        if (handTrackingEvents != null)
        {
            handTrackingEvents.handJointsUpdated += OnHandJointsUpdated;
        }
    }

    private void OnDisable()
    {
        if (handTrackingEvents != null)
        {
            handTrackingEvents.handJointsUpdated -= OnHandJointsUpdated;
        }
    }

    private void OnHandJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        // Detect grab gesture by checking finger pinch
        if (DetectGrabGesture())
        {
            if (!isGrabbing)
            {
                HandleGrabStart();
                isGrabbing = true;
            }
        }
        else
        {
            if (isGrabbing)
            {
                HandleGrabEnd();
                isGrabbing = false;
            }
        }
    }

    private bool DetectGrabGesture()
    {
        // Simple grab detection: if thumb and index finger are close
        // You can expand this with more sophisticated gesture detection
        return true; // Placeholder - implement actual gesture detection
    }

    private void HandleGrabStart()
    {
        // Raycast from hand to find grabbable objects
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                currentGrabbedObject = hit.collider.gameObject;
                ObjectManipulation manipulation = currentGrabbedObject.GetComponent<ObjectManipulation>();
                if (manipulation != null)
                {
                    manipulation.Grab(transform);
                }
            }
        }
    }

    private void HandleGrabEnd()
    {
        if (currentGrabbedObject != null)
        {
            ObjectManipulation manipulation = currentGrabbedObject.GetComponent<ObjectManipulation>();
            if (manipulation != null)
            {
                manipulation.Release();
            }
            currentGrabbedObject = null;
        }
    }
}
