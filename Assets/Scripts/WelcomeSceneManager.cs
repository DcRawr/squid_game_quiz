using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeSceneManager : MonoBehaviour
{
    public Button enterButton; // Reference to the button in the scene
    public Button clearButton; // Reference to the Clear button

    void Start()
    {
        // Set the OnClick listener for the button programmatically
        enterButton.onClick.AddListener(OnEnterButtonClicked);

        // Set the OnClick listener for the button programdmatically
        clearButton.onClick.AddListener(ResetGenerator);

        // Initially hide the Clear button
        clearButton.gameObject.SetActive(false);


        // Check if the list is full and update the button visibility
        UpdateClearButtonVisibility();
    }
    // Function to reset the number generator (clear the list of generated numbers)
    private void ResetGenerator()
    {
        if (UniqueNumberGenerator.Instance != null)
        {
            UniqueNumberGenerator.Instance.ResetGenerator();
            // Optionally, hide the button after resetting
            clearButton.gameObject.SetActive(false);
        }
    }

    public void UpdateClearButtonVisibility()
    {
        // Show the Clear button if numberIsFull is true
        if (UniqueNumberGenerator.Instance != null && UniqueNumberGenerator.Instance.numberIsFull)
        {
            clearButton.gameObject.SetActive(true);
        }
        else
        {
            clearButton.gameObject.SetActive(false);
        }
    }

    // Method called when the button is clicked
    private void OnEnterButtonClicked()
    {
        SceneManager.LoadScene("QuestionnaireScene");
    }
}
