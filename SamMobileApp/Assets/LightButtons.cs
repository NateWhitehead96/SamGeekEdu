using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightButtons : MonoBehaviour
{
    public Image image;

    public Color off; // red or something
    public Color on; // green or yellow

    public bool switched;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = off; // to show the lights are off by defualt
    }

    public void LightSwitch()
    {
        if(switched == true)
        {
            switched = false;
            image.color = off;
        }
        else
        {
            switched = true;
            image.color = on;
        }
    }
}
