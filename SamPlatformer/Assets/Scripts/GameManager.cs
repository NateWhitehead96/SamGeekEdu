using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int LevelsBeaten;
    public int Lives;
    public int coins;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject); // if we already have a game manager, then destroy the one in the scene
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // makes sure the game manager goes between scene
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadGame(); // load our save data on game start
    }

    // Update is called once per frame
    void Update()
    {
        if(Lives < 0)
        {
            Lives = 1;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SaveGame() // save the important data for our game
    {
        PlayerPrefs.SetInt("LevelsBeaten", LevelsBeaten); // save all of our levels we've completed
        PlayerPrefs.SetInt("Lives", Lives); // save whatever lives total we're at
        PlayerPrefs.SetInt("Coins", coins); // save our coin total
    }

    public void LoadGame() // load all of our game data
    {
        if (PlayerPrefs.HasKey("LevelsBeaten")) // check to see if we have save data
        {
            LevelsBeaten = PlayerPrefs.GetInt("LevelsBeaten"); // set our levels beaten from our save
            Lives = PlayerPrefs.GetInt("Lives"); // set lives
            coins = PlayerPrefs.GetInt("Coins"); // set coins
        }
    }
    public void RestartGame()
    {
        PlayerPrefs.DeleteAll(); // wipe all data
    }
}
