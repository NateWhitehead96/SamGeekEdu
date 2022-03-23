using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image HeartOne;
    public Image HeartTwo;
    public Image HeartThree;

    public Text ScoreText;
    public Text LivesText;

    public Sprite EmptyHeart;
    public Sprite FullHeart;

    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>(); // makes sure the player is our reference
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameManager.instance.coins.ToString(); // constantly update our score
        LivesText.text = GameManager.instance.Lives.ToString();
        if(player.Health == 3)
        {
            HeartThree.sprite = FullHeart;
            HeartTwo.sprite = FullHeart;
            HeartOne.sprite = FullHeart;
        }
        if(player.Health == 2)
        {
            HeartThree.sprite = EmptyHeart;
            HeartTwo.sprite = FullHeart;
            HeartOne.sprite = FullHeart;
        }
        if(player.Health == 1)
        {
            HeartThree.sprite = EmptyHeart;
            HeartTwo.sprite = EmptyHeart;
            HeartOne.sprite = FullHeart;
        }
        if(player.Health == 0)
        {
            HeartThree.sprite = EmptyHeart;
            HeartTwo.sprite = EmptyHeart;
            HeartOne.sprite = EmptyHeart;
        }
        
    }
}
