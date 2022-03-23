using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour
{
    public bool triggered; // whether the thing was hit or not
    public Sprite pressedSprite;
    public Sprite unpressedSprite;
    private SpriteRenderer sprite;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            timer += Time.deltaTime;
            if(timer >= 4)
            {
                triggered = false;
                timer = 0;
                sprite.sprite = unpressedSprite;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggered = true;
            sprite.sprite = pressedSprite;
        }
    }
}
