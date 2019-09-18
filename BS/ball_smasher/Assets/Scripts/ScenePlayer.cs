using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayer : MonoBehaviour
{
    // configuration variable
    gameState loseStae;

    private void Start()
    {
        loseStae = FindObjectOfType<gameState>();
    }

    public void sceneLoader()
    {
        int currentSIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSIndex + 1);
    }

    public void goToStartMenu()
    {
        loseStae.resetGame();
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
