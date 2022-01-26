using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public Vector3 MoveToPostion; // our mouse position the snowball is going to move to

    public float size; // size of the snowball
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, 1); // setting the size of the snowball
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPostion * Time.deltaTime); // translate the ball to our move position at a rate of delta time

        if(transform.position.x > 12 || transform.position.y > 6 || transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
