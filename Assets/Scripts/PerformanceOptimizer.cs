using UnityEngine;
using UnityEngine.XR;

public class PerformanceOptimizer : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 90; // VR target
    [SerializeField] private bool enableDynamicResolution = true;
    [SerializeField] private float targetGPULoad = 0.8f;

    private void Start()
    {
        // Set target frame rate for VR
        Application.targetFrameRate = targetFrameRate;
        
        // Enable VSync for smooth hand tracking
        QualitySettings.vSyncCount = 1;
        
        // Optimize physics for VR
        Time.fixedDeltaTime = 1f / targetFrameRate;
        Physics.defaultSolverIterations = 4;
        Physics.defaultSolverVelocityIterations = 1;
    }

    private void LateUpdate()
    {
        // Monitor performance
        MonitorPerformance();
    }

    private void MonitorPerformance()
    {
        // Log frame timing for optimization
        if (Time.frameCount % 300 == 0) // Check every 5 seconds at 60fps
        {
            float fps = 1f / Time.deltaTime;
            Debug.Log($"Current FPS: {fps:F1}");
        }
    }

    public void OptimizeForHandTracking()
    {
        // Reduce physics calculation overhead
        Physics.gravity = Vector3.zero;
        
        // Limit rigidbodies active at once
        Rigidbody[] bodies = FindObjectsOfType<Rigidbody>();
        foreach (var body in bodies)
        {
            if (!body.isKinematic)
            {
                body.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
