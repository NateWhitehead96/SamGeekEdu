using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
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
        transform.position = new Vector3(transform.position.x, transform.position.y + 1 * direction * Time.deltaTime);

        if(transform.position.y > topBounds)
        {
            direction = -1;
        }
        if(transform.position.y < botBounds)
        {
            direction = 1;
        }
    }
}
