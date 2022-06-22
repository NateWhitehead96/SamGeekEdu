using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0); // load menu
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1); // load the level
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
