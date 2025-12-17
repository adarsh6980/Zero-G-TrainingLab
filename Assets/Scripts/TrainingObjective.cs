using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TrainingObjective : MonoBehaviour
{
    [System.Serializable]
    public class Objective
    {
        public string objectiveName;
        public string description;
        public GameObject[] targetObjects;
        public Vector3[] targetPositions;
        public float proximityThreshold = 0.5f;
        public bool isComplete = false;
    }

    [SerializeField] private List<Objective> objectives = new List<Objective>();
    [SerializeField] private TextMeshProUGUI objectiveDisplay;
    
    private int currentObjectiveIndex = 0;
    private int completedObjectives = 0;

    private void Start()
    {
        UpdateObjectiveDisplay();
    }

    private void FixedUpdate()
    {
        if (currentObjectiveIndex < objectives.Count)
        {
            CheckObjectiveCompletion();
        }
    }

    private void CheckObjectiveCompletion()
    {
        Objective current = objectives[currentObjectiveIndex];
        
        // Check if all target objects are near their target positions
        bool allCorrect = true;
        for (int i = 0; i < current.targetObjects.Length; i++)
        {
            float distance = Vector3.Distance(
                current.targetObjects[i].transform.position,
                current.targetPositions[i]
            );
            
            if (distance > current.proximityThreshold)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect && !current.isComplete)
        {
            current.isComplete = true;
            CompletedObjective();
        }
    }

    private void CompletedObjective()
    {
        completedObjectives++;
        Debug.Log($"Objective {completedObjectives} completed!");
        
        if (completedObjectives < objectives.Count)
        {
            currentObjectiveIndex++;
            UpdateObjectiveDisplay();
        }
        else
        {
            AllObjectivesComplete();
        }
    }

    private void UpdateObjectiveDisplay()
    {
        if (currentObjectiveIndex < objectives.Count && objectiveDisplay != null)
        {
            Objective current = objectives[currentObjectiveIndex];
            objectiveDisplay.text = $"<b>{current.objectiveName}</b>\n{current.description}";
        }
    }

    private void AllObjectivesComplete()
    {
        if (objectiveDisplay != null)
        {
            objectiveDisplay.text = "Training Complete!\nExcellent work!";
        }
        Debug.Log("All training objectives completed!");
    }
}
