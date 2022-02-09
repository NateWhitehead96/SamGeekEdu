using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float moveSpeed;
    public int direction = -1; // of course helps with direction
    public float leftBounds;
    public float rightBounds;

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y);
        if(transform.position.x < leftBounds)
        {
            direction = 1;
            sprite.flipX = true;
        }
        if(transform.position.x > rightBounds)
        {
            direction = -1;
            sprite.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Health--;
        }
    }
}
