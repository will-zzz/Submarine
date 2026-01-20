using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    [Header("Depth Settings")]
    public float currentDepth = 50f;
    public float minSafeDepth = 20f;
    public float maxSafeDepth = 80f;
    
    [Header("Descent Logic")]
    public float baseDescentRate = 1.0f; // Natural sinking speed
    private bool isEnginePaused = false;

    void Update()
    {
        if (!isEnginePaused)
        {
            // Calculate a random descent rate for "chaos"
            float randomFlax = Random.Range(0.5f, 2.0f);
            currentDepth += baseDescentRate * randomFlax * Time.deltaTime;
        }

        CheckSafetyLimits();
        DisplayStats();
    }

    void CheckSafetyLimits()
    {
        if (currentDepth < minSafeDepth || currentDepth > maxSafeDepth)
        {
            Debug.LogWarning("WARNING: OUTSIDE SAFE RANGE! STRUCTURAL INTEGRITY AT RISK!");
        }
    }

    // Logic for Button 1: Sudden Drop
    public void TriggerSuddenDrop(float amount)
    {
        currentDepth += amount;
        Debug.Log($"Submarine dropped by {amount} meters!");
    }

    // Logic for Button 2: Toggle Pause
    public void ToggleEnginePause()
    {
        isEnginePaused = !isEnginePaused;
        string status = isEnginePaused ? "HALTED" : "RESUMED";
        Debug.Log($"Submarine engines {status}.");
    }

    void DisplayStats()
    {
        // Simple console output for now as requested
        Debug.Log($"SAFE RANGE: {minSafeDepth}m - {maxSafeDepth}m | CURRENT DEPTH: {currentDepth:F2}m");
    }
}