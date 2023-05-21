using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void StartGame()
    {
        // Load the "SampleScene" level
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
