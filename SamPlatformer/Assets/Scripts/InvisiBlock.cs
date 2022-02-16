using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiBlock : MonoBehaviour
{
    public SpriteRenderer sprite; // to help us turn the box invisible
    public BoxCollider2D box; // to help with "ground" collisions

    public float timer;
    public float ToggleVisibiltyTime = 3;
    public bool invisible; // to tell us when it's invisible
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // keep timer going up
        if (timer >= ToggleVisibiltyTime)
        {
            if (invisible == true) // if the box is invisible
            {
                invisible = false; // flip the box to visible
                sprite.enabled = true; // set both the image and collider to true
                box.enabled = true;
            }
            else if (invisible == false) // if the box is visible
            {
                invisible = true; // flip the box to be invisible
                sprite.enabled = false; // set both image and collider to false
                box.enabled = false;
            }

            timer = 0; // reset timer
        }
    }
}
