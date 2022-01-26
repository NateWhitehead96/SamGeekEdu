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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // destroy the coin
            // add points later
        }
    }
}
