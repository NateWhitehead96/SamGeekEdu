using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow : MonoBehaviour
{
    public Vector3 offSet; // the offset position from the player
    public Transform player;
    public bool collected;
    public DoorScript exitDoor; // to use up the key when we touch the door
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            Vector3 followPosition = player.position + offSet;
            transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime);
            if (exitDoor.inDoor)
            {
                Destroy(gameObject); // delete key when we get inside of the exit door
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            collected = true;
        }
    }
}
