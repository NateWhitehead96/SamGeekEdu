using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnake : MonoBehaviour
{
    public float moveSpeed;
    public float topBounds;
    public float botBounds;

    public int direction;

    public float[] XPositions; // x positions the lava snake can pop up in

    public BossButton[] buttons; // to know if the buttons have been pressed or not
    int numPressed; // how many buttons have been pressed
    public GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime);

        if (transform.position.y > topBounds)
        {
            direction = -1;
        }
        if (transform.position.y < botBounds)
        {
            direction = 1;
            int newXPos = Random.Range(0, XPositions.Length);
            transform.position = new Vector3(XPositions[newXPos], transform.position.y); // set our new x position
        }
        if (AreButtonsAllPressed())
        {
            bridge.SetActive(true);
            Destroy(gameObject);
        }
    }

    bool AreButtonsAllPressed() // a function that will be tru or false, based on if the buttons are pressed
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].triggered)
            {
                numPressed++;
            }
            else
            {
                numPressed = 0;
                return false;
            }
        }
        if (numPressed >= 4)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().HurtPlayer();
        }
    }
}
