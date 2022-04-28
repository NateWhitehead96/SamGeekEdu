using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public PatrolEnemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<PatrolEnemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() && other.GetComponent<Player>().exposed == true) // if the player is inside of los and in light
        {
            enemy.playerDetected = true; // flip this bool to make enemy follow player
            print("Seeing player");
            //enemy.agent.ResetPath(); // stop going to where its going
            enemy.agent.SetDestination(other.transform.position); // make sure it follows player
        }
    }
}
