using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject snowball;                            // this will be a refrence to our snowball prefab

    public bool shooting; // if we're shooting or not

    public float shootSpeed; // shooting cooldown, rate of fire

    public float snowballSize; // how big the snowball is

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shooting == false || Input.GetMouseButton(1) && shooting == false) // this is left click input and we're not currently shooting
        {
            StartCoroutine(FireSnowball()); // coroutine that will help with our shooting cooldown
        }
    }

    IEnumerator FireSnowball()
    {
        shooting = true;
        GameObject newSnowball = Instantiate(snowball, transform.position, Quaternion.identity); // creating a new snowball
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // find our mouse position
        Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse position
        newSnowball.GetComponent<SnowballScript>().MoveToPostion = new Vector3(shootDirection.x, shootDirection.y); // applying movement to our snowball
        newSnowball.GetComponent<SnowballScript>().size = snowballSize; // set the size of the snowball
        yield return new WaitForSeconds(shootSpeed);
        shooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            // local variable, a variable only used inside a function
            Pickup pickup = collision.gameObject.GetComponent<Pickup>();
            if(pickup.type == Type.IncreaseShootSpeed)
            {
                shootSpeed -= 0.1f; // lower our shoot cooldown
            }
            if(pickup.type == Type.IncreaseSnowballSize)
            {
                snowballSize += 0.1f; // increase the snowball size
            }
            if(pickup.type == Type.AddHealth)
            {
                ScoringSystem.Lives++; // increase lives by one
            }

            Destroy(collision.gameObject); // destroy the powerup
        }
    }

}
