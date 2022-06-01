using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float rotationSpeed; // how fast it rotates
    public int Direction = 1; // direction of the bob
    public float top, bot; // top and  bot bounds for bobbing up and down
    // Start is called before the first frame update
    void Start()
    {
        top = transform.position.y + 0.2f;
        bot = transform.position.y - 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + Direction * Time.deltaTime, transform.position.z);
        if(transform.position.y > top)
        {
            Direction = -1;
        }
        if(transform.position.y < bot)
        {
            Direction = 1;
        }
    }
}
