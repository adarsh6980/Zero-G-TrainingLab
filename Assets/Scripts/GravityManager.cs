using UnityEngine;
using System.Collections.Generic;

public class GravityManager : MonoBehaviour
{
    public static GravityManager Instance { get; private set; }
    
    [SerializeField] private float gravityScale = 0f; // 0 = zero gravity
    [SerializeField] private Vector3 customGravityDirection = Vector3.zero;
    [SerializeField] private float airResistance = 0.99f; // Simulate space vacuum
    
    private List<Rigidbody> affectedBodies = new List<Rigidbody>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Set physics to zero-gravity
        Physics.gravity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        // Apply air resistance to all objects
        foreach (var body in affectedBodies)
        {
            if (body != null)
            {
                // Simulate space vacuum - gradual velocity reduction
                body.velocity *= airResistance;
            }
        }
    }

    public void RegisterBody(Rigidbody body)
    {
        if (!affectedBodies.Contains(body))
            affectedBodies.Add(body);
    }

    public void UnregisterBody(Rigidbody body)
    {
        affectedBodies.Remove(body);
    }

    public Vector3 GetGravityDirection()
    {
        return customGravityDirection;
    }

    public float GetGravityScale()
    {
        return gravityScale;
    }
}
