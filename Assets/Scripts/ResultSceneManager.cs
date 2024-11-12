using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public Text resultText;

    void Start()
    {
        if (UniqueNumberGenerator.Instance != null)
        {
            string uniqueNumber = UniqueNumberGenerator.Instance.GenerateUniqueNumber();
            resultText.text = "Your Unique Number: " + uniqueNumber;
        }
        else
        {
            resultText.text = "Error: Number generator not found!";
        }
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
