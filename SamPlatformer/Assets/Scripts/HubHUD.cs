using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubHUD : MonoBehaviour
{
    public Text lives;
    public Text coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = GameManager.instance.Lives.ToString();
        coins.text = GameManager.instance.coins.ToString();
    }
}
