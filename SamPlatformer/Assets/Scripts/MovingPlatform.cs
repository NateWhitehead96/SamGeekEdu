using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public int direction;
    public float rightBound;
    public float leftBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y);

        if(transform.position.x > rightBound)
        {
            direction = -1;
        }
        if(transform.position.x < leftBound)
        {
            direction = 1;
        }
    }
}
