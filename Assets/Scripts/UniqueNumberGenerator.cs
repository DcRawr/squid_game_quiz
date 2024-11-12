using System.Collections.Generic;
using UnityEngine;

public class UniqueNumberGenerator : MonoBehaviour
{
    private HashSet<int> generatedNumbers = new HashSet<int>();  // To store unique numbers
    private const int MinValue = 2;
    private const int MaxValue = 5;
    private const int ExcludedNumber = 456;

    // Singleton instance for easy access across scenes
    public static UniqueNumberGenerator Instance;

    public bool numberIsFull = false;

    void Awake()
    {
        // Singleton pattern to keep one instance alive across all scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to generate a unique 3-digit number excluding 456
    public string GenerateUniqueNumber()
    {
        if (generatedNumbers.Count >= (MaxValue - MinValue)) // Check if all unique numbers have been used
        {
            numberIsFull = true;

            // Call UpdateClearButtonVisibility if WelcomeSceneManager is active
            var welcomeManager = FindObjectOfType<WelcomeSceneManager>();
            if (welcomeManager != null)
            {
                welcomeManager.UpdateClearButtonVisibility();
            }

            return "All numbers used!";  // Return a message if no more numbers are available
        }

        int newNumber;
        do
        {
            newNumber = Random.Range(MinValue, MaxValue + 1);
        }
        while (newNumber == ExcludedNumber || generatedNumbers.Contains(newNumber));  // Retry until unique and not 456

        generatedNumbers.Add(newNumber);  // Add to the set of generated numbers
        return newNumber.ToString("D3");  // Format as three digits (e.g., "002")
    }

    // Optional: Reset method if you want to allow starting over without duplicates
    public void ResetGenerator()
    {
        generatedNumbers.Clear();  // Clears the list of generated numbers
        numberIsFull = false;      // Resets the full state flag
        Debug.Log("Number generator has been reset.");
    }
}
