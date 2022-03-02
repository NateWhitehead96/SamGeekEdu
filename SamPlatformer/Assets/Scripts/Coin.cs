using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int direction = 1; // the direction the coin goes

    public float topBound; // how high up 
    public float botBound; // how low it can go
    // Start is called before the first frame update
    void Start()
    {
        topBound = transform.position.y + 0.5f; // make sure the top bounds is only 0.5 pixels higher
        botBound = transform.position.y - 0.5f; // make sure the bottom bounds is only 0.5 pixels lower
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + direction * Time.deltaTime); // moving the coin up or down

        if(transform.position.y > topBound)
        {
            direction = -1;
        }
        if(transform.position.y < botBound)
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.coinSound.Play(); // play the coin sound
            collision.gameObject.GetComponent<PlayerScript>().Score++; // add to our score when we collect the coin
            Destroy(gameObject); // destroy the coin
            // add points later
        }
    }
}
