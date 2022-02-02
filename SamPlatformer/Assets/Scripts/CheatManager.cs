using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour
{
    public InputField inputBox; // the box we can write our codes in
    public string[] cheatCodes; // all of the cheat codes

    public PlayerScript player; // just so we have access to this guy

    public void SubmitCheat()
    {
        if(inputBox.text == cheatCodes[0]) // if the input is the same as our code
        {
            player.devCheats = true; // flip that cheats bool
            gameObject.SetActive(false); // hide the cheat
        }
        else
        {
            inputBox.text = ""; // clear the text box
        }
    }
}
