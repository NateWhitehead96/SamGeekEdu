using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour // holds all the different button input for pause, main menu, and lose/win screen
{
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void HubWorld()
    {
        GameManager.instance.SaveGame();
        SceneManager.LoadScene("HubWorld");
    }
    public void MainMenu()
    {
        GameManager.instance.SaveGame();
        print("Going to main menu :)");
    }
    public void ExitGame()
    {
        GameManager.instance.SaveGame();
        Application.Quit();
    }
    public void GameOver()
    {
        GameManager.instance.Lives = 3; // reset lives back
        GameManager.instance.coins = 0; // reset coins
        GameManager.instance.LevelsBeaten = 1; // reset progress
        GameManager.instance.SaveGame(); // save these stats
        SceneManager.LoadScene("HubWorld"); // load hub
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("HubWorld");
    }
}
