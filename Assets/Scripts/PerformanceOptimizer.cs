using UnityEngine;
using UnityEngine.Rendering;

namespace ZeroGTrainingLab
{
    /// <summary>
    /// Basic dynamic resolution / quality scaler for VR.
    /// Targeted at maintaining steady framerates on mobile chipsets.
    /// </summary>
    public class PerformanceOptimizer : MonoBehaviour
    {
        [Header("Targets")]
        public float targetFPS = 72.0f;
        public float checkInterval = 2.0f; // Check every 2 seconds

        private float timer;
        private int qualityLevel;

        private void Start()
        {
            // Ensure we start at a reasonable level
            qualityLevel = QualitySettings.GetQualityLevel();
            
            // Quest 2/3 supports 120Hz in some modes, try to request it
            // Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(90f); 
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > checkInterval)
            {
                CheckPerformance();
                timer = 0;
            }
        }

        private void CheckPerformance()
        {
            float currentFPS = 1.0f / Time.smoothDeltaTime;

            if (currentFPS < targetFPS - 5)
            {
                DecreaseQuality();
            }
            // Logic to increase quality could go here, but usually safer to stick to stable low
        }

        private void DecreaseQuality()
        {
            if (qualityLevel > 0)
            {
                qualityLevel--;
                QualitySettings.SetQualityLevel(qualityLevel);
                Debug.Log($"Performance drop detected. Lowering quality to level {qualityLevel}");
            }
            else
            {
                // Already at lowest connection, try reducing render scale
                // XRSettings.eyeTextureResolutionScale *= 0.9f; 
            }
        }
    }
}
