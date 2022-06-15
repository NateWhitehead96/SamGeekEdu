using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject Monster;
    public Transform[] spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        int randLocation = Random.Range(0, spawnLocation.Length);
        Instantiate(Monster, spawnLocation[randLocation].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
