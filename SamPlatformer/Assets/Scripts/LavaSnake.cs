using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSnake : MonoBehaviour
{
    public float moveSpeed;
    public float topBounds;
    public float botBounds;

    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime);

        if(transform.position.y > topBounds)
        {
            direction = -1;
        }
        if(transform.position.y < botBounds)
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
}
