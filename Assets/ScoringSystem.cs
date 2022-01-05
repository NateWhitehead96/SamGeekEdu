using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    // refrences to our text object
    public Text LivesText;
    public Text ScoreText;
    public Text WaveText;

    // static key word allows us to get these variables in other classes without a reference
    // our game's main score variables
    public static int Lives;
    public static int Score;
    public static int Waves;
    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
        WaveText.text = " Wave: " + Waves;
    }
}
