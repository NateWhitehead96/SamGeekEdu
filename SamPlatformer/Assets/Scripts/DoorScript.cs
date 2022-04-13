using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // this will help with loading a level based on it's index
    public bool inDoor; // quick bool to tell us if we're in the door or not
    public bool requiresKey; // a bool to check if we need a key to open the door

    public int nextLevel; // the door knows our current level
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // the level exit doors will require the key now
        if(requiresKey == true)
        {
            if(Input.GetKeyDown(KeyCode.W) && inDoor == true && PlayerScript.hasKey == true)
            {
                if (nextLevel > GameManager.instance.LevelsBeaten)
                {
                    GameManager.instance.LevelsBeaten = nextLevel;
                    PlayerScript.hasKey = false;
                }
                SceneManager.LoadScene(LevelToLoad);
                GameManager.instance.SaveGame(); // save our data when we beat a level regardless of if we've beaten previously
            }
        }
        else // our level doors will just load the level if we have enough levels beaten
        {
            if(Input.GetKeyDown(KeyCode.W) && inDoor == true && GameManager.instance.LevelsBeaten >= LevelToLoad)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
        //if (requiresKey == false)
        //{
        //    if (GameManager.instance.LevelsBeaten < nextLevel) // if the next level is greater than how many we've beaten, then set levels beaten to that, else dont
        //    {
        //        GameManager.instance.LevelsBeaten = nextLevel;
        //    }
        //    if (Input.GetKeyDown(KeyCode.W) && inDoor == true)
        //    {
        //        SceneManager.LoadScene(LevelToLoad);
        //    }
        //}
        //else if(requiresKey == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.W) && inDoor == true && PlayerScript.hasKey == true) // if we're in the door and got the next levels key
        //    {
        //        if(GameManager.instance.LevelsBeaten >= LevelToLoad) // this is used for entering a new level
        //        {
        //            SceneManager.LoadScene(LevelToLoad);
        //            PlayerScript.hasKey = false; // make sure the key gets used up
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) // when we walk into the door, we can go through
    {
        if(collision.gameObject.CompareTag("Player"))
            inDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision) // when we leave, dont allow us to go through
    {
        if (collision.gameObject.CompareTag("Player"))
            inDoor = false;
    }
}
