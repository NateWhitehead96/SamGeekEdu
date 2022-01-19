using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayButton() // do things when we hit play
    {
        SceneManager.LoadScene("SampleScene"); // open sample scene aka play scene
    }

    public void ControlsButton()
    {
        SceneManager.LoadScene("Controls"); // open up the controls
    }

    public void ExitGame()
    {
        Application.Quit(); // this only works in a built version of the game, we can't quit our of the editor
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu"); // open up main menu
    }
}
