using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartGame()
    {
        // Load the "SampleScene" level
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
