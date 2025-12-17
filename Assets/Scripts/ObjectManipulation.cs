using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabPoint;
    private Vector3 lastPosition;
    private bool isGrabbed = false;
    private float throwForceMultiplier = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Grabbable";
    }

    private void Start()
    {
        GravityManager.Instance.RegisterBody(rb);
    }

    public void Grab(Transform hand)
    {
        isGrabbed = true;
        grabPoint = hand;
        lastPosition = transform.position;
        rb.isKinematic = true; // Stop physics while grabbed
    }

    private void Update()
    {
        if (isGrabbed && grabPoint != null)
        {
            // Move object to follow hand
            transform.position = grabPoint.position + grabPoint.forward * 0.3f;
            
            // Rotate with hand
            transform.rotation = grabPoint.rotation;
        }
    }

    public void Release()
    {
        if (isGrabbed)
        {
            isGrabbed = false;
            rb.isKinematic = false;
            
            // Calculate throw velocity
            Vector3 throwVelocity = (transform.position - lastPosition) * throwForceMultiplier;
            rb.velocity = throwVelocity;
        }
    }

    private void OnDestroy()
    {
        if (GravityManager.Instance != null)
        {
            GravityManager.Instance.UnregisterBody(rb);
        }
    }
}
