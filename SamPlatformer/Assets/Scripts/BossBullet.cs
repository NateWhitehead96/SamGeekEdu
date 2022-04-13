using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Transform player;
    public Vector3 playerPos;
    public int movespeed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>().transform; // find player
        playerPos = player.position; // whatever position player is in when this is spawned will be it's destination
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, movespeed * Time.deltaTime); // move toward player
        if(transform.position == playerPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerScript>().HurtPlayer();
            Destroy(gameObject);
        }
    }
}
