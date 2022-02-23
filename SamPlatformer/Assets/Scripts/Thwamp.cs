using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwamp : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public float RestingYPosition; // another word for its top Y position
    public bool fellDown; // a trigger bool to know if it's fallen down
    public Transform RaycastPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // make sure rigidbody is accessible
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(RaycastPos.position, Vector3.down, Mathf.Infinity); // firing raycast down and saving that info in hit

        if (hit.collider.gameObject.CompareTag("Player") && fellDown == false)
        {
            rb.gravityScale = 10; // set gravity to a high number so it crashes down
            fellDown = true; // it's fallen
        }
        if (transform.position.y < RestingYPosition && fellDown == true)// if the thwamp fell, let it go back up
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime); // this will move it back up
        }
        if(transform.position.y >= RestingYPosition)
        {
            fellDown = false; // at the resting position, can now fall when player passes
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = 0; // set gravity to 0 to allow thwamp to go back up
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Health--; // lose health when touching the thwamp
        }
    }
}
