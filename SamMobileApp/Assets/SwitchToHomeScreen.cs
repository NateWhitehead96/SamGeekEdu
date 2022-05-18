using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; // for access to the director
using UnityEngine.SceneManagement; // to move between scenes
using UnityEngine.UI;

public class SwitchToHomeScreen : MonoBehaviour
{
    public PlayableDirector director; // this is the director to our timeline animation to fade the Logo
    public InputField username;
    public InputField password;

    public string[] usernames;
    public string[] passwords;

    public GameObject[] LoginStuff; // we want to show and hide all of the login stuff
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LoginStuff.Length; i++) // loop through the username/password/logo to hide those things
        {
            LoginStuff[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing) // when the director's timeline is done playing
        {
            for (int i = 0; i < LoginStuff.Length; i++)
            {
                LoginStuff[i].SetActive(true);
            }
        }
        
         
    }

    public void SubmitCredentials()
    {
        for (int i = 0; i < usernames.Length; i++)
        {
            if(username.text == usernames[i] && password.text == passwords[i]) // username and password match
            {
                print("You logged in");
                ProfileSaver.instance.username = usernames[i]; // save the username we logged in with
                SceneManager.LoadScene(1);
            }
            //else // things dont match
            //{
            //    username.text = "";
            //    password.text = "";
            //}
        }
    }
}           
