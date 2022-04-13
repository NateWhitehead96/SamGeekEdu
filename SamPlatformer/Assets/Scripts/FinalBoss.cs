using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBoss : MonoBehaviour
{
    public int health;
    public int moveSpeed;
    public GameObject Bullet;
    public Transform shootPos;
    public Slider HealthBar;
    public Transform player; // help with distance of player
    public float distanceToPlayer; // how far the player is from the boss
    private Animator anim;

    public float timer;

    public GameObject FinalDoor;
    public GameObject Key;
    private void Awake()
    {
        HealthBar.maxValue = health;
        HealthBar.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking", true);
        Key.SetActive(false);
        FinalDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar.gameObject.activeInHierarchy)
        {
            HealthBar.value = health;
        }
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= 4) // player is too close
        {
            if (transform.position.x > player.position.x) // boss is to the right of the player
            {
                transform.position = new Vector3( 170, transform.position.y); // move boss to the left
            }
            if(transform.position.x < player.position.x)
            {
                transform.position = new Vector3(170, transform.position.y); // move boss to the right
            }
        }
        else if(distanceToPlayer < 10) // to help boss stay roughly 20 units from player
        {
            
            if (transform.position.x > player.position.x) // boss to the right
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                transform.localScale = new Vector3(5, 5); // flip the boss
            }
            if (transform.position.x < player.position.x) // boss to the left
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                transform.localScale = new Vector3(-5, 5); // flip the boss
            }
        }

        if(distanceToPlayer < 20)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                Instantiate(Bullet, shootPos.position, shootPos.rotation);
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fireball>())
        {
            health--;
            if(health <= 0)
            {
                Destroy(HealthBar.transform.parent.gameObject); // to kill the boss healthbar
                Key.SetActive(true);
                FinalDoor.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
