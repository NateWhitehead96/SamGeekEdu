using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type // what type of pickup it will be
{
    IncreaseShootSpeed,
    IncreaseSnowballSize,
    AddHealth
}

public class Pickup : MonoBehaviour
{
    public Type type; // type this pick up will be
    public float moveSpeed;

    private SpriteRenderer sprite; // a reference to the sprite of the pickup

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // making sure the sprite is the powerup sprite
        int x = Random.Range(0, 3);
        if (x == 0) // our type is this first type, shoot speed up
        {
            type = Type.IncreaseShootSpeed; // type = increase shoot speed
            sprite.color = Color.green; // change color to green
        }
        if(x == 1) // our type is the 2nd type
        {
            type = Type.IncreaseSnowballSize;
            sprite.color = Color.blue;
        }
        if(x == 2) // our type is the 3rd type
        {
            type = Type.AddHealth;
            sprite.color = Color.magenta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move the powerup to the left
        if (transform.position.x < -10) // when the powerup moves too far left, destroy
        {
            Destroy(gameObject);
        }
    }
}
