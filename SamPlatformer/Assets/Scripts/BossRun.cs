using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator anim;
    bool playerTrigger;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrigger)
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime); // move it to the right, the boss area
            if(transform.position.x >= 155)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.flipX = true; // make it face the other way
            anim.SetBool("walking", true);
            playerTrigger = true;
        }
    }
}
