using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sprite; // help us flip direction
    public Rigidbody2D rb; // be our rigibody variable
    public Animator animator; // the animation controller

    public int moveSpeed; // how fast we go
    public float jumpForce; // how high we can jump

    public bool jumping; // to help with transitioning to jump animation
    public bool walking; // to help with transitioning to walking animation
    public bool climbing; // to help with transitioning to climing animation

    public Transform Checkpoint; // the respawn point

    // HUD variables
    public int Health = 3; // how much health we have
    public int Score; // our total score every level

    // cheat code stuff
    public GameObject CheatCanavs; // access to cheat canvas
    public bool devCheats; // dev cheats

    public static bool hasKey; // this bool tells us if we have the key from the level

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // makes sure our sprite is the sprite of this gameobject
        rb = GetComponent<Rigidbody2D>(); // make sure our rigibody is set
        animator = GetComponent<Animator>(); // make sure our animator is this game objects
        CheatCanavs.SetActive(false); // when we play always have cheat canvas hidden
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D)) // moving right
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = false; // make sure we're facing right
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.D)) // release the key
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.A)) // moving left
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = true; // make sure we're facing left
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.A)) // release the key
        {
            walking = false;
        }

        animator.SetBool("isWalking", walking); // handle transition to walking animation
        animator.SetBool("isJumping", jumping); // handle transition to jumping animation

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false) // when we hit space and we aren't currently jumping then jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); // jump
            if (devCheats) // if we have cheats on jumping will always be false
            {
                jumping = false;
            }
            else
            {
                jumping = true;
            }
        }

        if(Input.GetKey(KeyCode.W) && climbing == true) // climbing up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) && climbing == true) // climbing down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.BackQuote)) // when we hit the squiggly line
        {
            if (CheatCanavs.activeInHierarchy) // it's on the screen
            {
                CheatCanavs.SetActive(false); // set to false
            }
            else // else we set it to true, active
            {
                CheatCanavs.SetActive(true);
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head")) // head of any enemy we kill it
        {
            Destroy(collision.transform.parent.gameObject); // destroying the spider
        }
        if (collision.gameObject.CompareTag("Deathplane"))
        {
            transform.position = Checkpoint.position; // reset our position to the checkpoint
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true; // flip key bool
            Destroy(collision.gameObject); // destroy key from game
        }
        if (collision.gameObject.CompareTag("Ladder")) // when we hop on the ladder
        {
            climbing = true;
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) // jumping off the ladder
        {
            climbing = false;
            rb.gravityScale = 1;
        }
    }
}
