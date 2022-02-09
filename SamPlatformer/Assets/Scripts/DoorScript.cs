using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for switching between scenes

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // this will help with loading a level based on it's index
    public bool inDoor; // quick bool to tell us if we're in the door or not
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && inDoor == true)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
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
