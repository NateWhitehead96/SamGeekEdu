using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int moveSpeed; // tells us how fast the enemy can move
    public Animator animator; // a reference to our animator
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // makes sure our animator is the animator on the gameobject
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move the enemy to the left
        if(transform.position.x < -10) // when we move too far left kill enemy
        {
            ScoringSystem.Lives--; // lose 1 life when an enemy gets by us
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            // we gain score
            ScoringSystem.Score += 5;
            Destroy(collision.gameObject); // destroy the snowball
            StartCoroutine(DyingAnimation());
        }
    }

    IEnumerator DyingAnimation()
    {
        animator.SetBool("isDying", true); // setting our animation state to isdying true
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // remove collider so enemies and snowballs can pass
        moveSpeed = 0; // make sure the enemy doesnt move
        yield return new WaitForSeconds(2); // wait some time before destroying the enemy gameobject
        Destroy(gameObject);
    }
}
