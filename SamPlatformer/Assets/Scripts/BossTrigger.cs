using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject Wall, Wall2; // another way to declare variables of the same type in 1 line
    public GameObject BossHealth;
    // Start is called before the first frame update
    void Start()
    {
        Wall.SetActive(false);
        Wall2.SetActive(false);
        BossHealth.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Wall.SetActive(true);
            Wall2.SetActive(true);
            BossHealth.SetActive(true);
            Destroy(gameObject); // destroy this trigger box
        }
    }
}
