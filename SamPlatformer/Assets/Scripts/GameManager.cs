using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int LevelsBeaten;
    public int Lives;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
