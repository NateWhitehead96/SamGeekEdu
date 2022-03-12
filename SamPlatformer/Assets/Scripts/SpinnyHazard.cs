using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyHazard : MonoBehaviour
{
    public int direction = 1; // the direction the coin goes

    public float topBound; // how high up 
    public float botBound; // how low it can go

    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // rotate the hazard around the z axis (forward is (0,0,1))

        transform.position = new Vector3(transform.position.x, transform.position.y + direction * Time.deltaTime);

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
            collision.gameObject.GetComponent<PlayerScript>().HurtPlayer();
        }
    }
}
