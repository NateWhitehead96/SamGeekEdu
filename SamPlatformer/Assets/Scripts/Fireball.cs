using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 MoveToPosition;
    public float elapsedTime; // how long has it been on screen
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPosition * Time.deltaTime);
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 5)
        {
            Destroy(gameObject); // this is to make sure we delete the fire balls after some time
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // for now just destroy the projectile
    }
}
