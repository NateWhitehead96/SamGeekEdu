using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public int direction = 1; // the direction the coin goes

    public float topBound; // how high up 
    public float botBound; // how low it can go
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        topBound = transform.position.y + 2f; // make sure the top bounds is only 0.5 pixels higher
        botBound = transform.position.y - 2f; // make sure the bottom bounds is only 0.5 pixels lower
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + direction * Time.deltaTime); // moving the coin up or down

        if (transform.position.y > topBound)
        {
            direction = -1;
        }
        if (transform.position.y < botBound)
        {
            direction = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().HurtPlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fireball>())
        {
            health--;
            Destroy(collision.gameObject);
            if(health <= 0)
                Destroy(gameObject);
        }
    }
}
