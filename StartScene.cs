using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene
{
    public void StartGame()
    {
        // Load the "SampleScene" level
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsPage()
    {
        //Load the Settings Scene
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
