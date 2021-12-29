using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public Vector3 MoveToPostion; // our mouse position the snowball is going to move to
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPostion * Time.deltaTime); // translate the ball to our move position at a rate of delta time
    }
}
