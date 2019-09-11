using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayer : MonoBehaviour
{
   public void sceneLoader()
    {
        int currentSIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSIndex + 1);
    }

    public void goToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
