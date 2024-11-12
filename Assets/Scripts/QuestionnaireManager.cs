using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionnaireManager : MonoBehaviour
{
    public void OnSubmitButtonClicked()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
