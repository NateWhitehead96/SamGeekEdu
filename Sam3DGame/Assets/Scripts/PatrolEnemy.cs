using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // grant us access to move around the level using AI navigation
    public Transform[] patrolPoints;
    public int pointCounter; // keep track of the point we're on
    bool reachedCheckpoint;
    public bool playerDetected;
    //public Transform raycastPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerDetected)
            agent.SetDestination(patrolPoints[pointCounter].position); // set and move the AI to this position
        if (playerDetected)
        {
            agent.SetDestination(FindObjectOfType<Player>().transform.position); // to be fixed, but makes enemy follow player if detected
            if (agent.remainingDistance >= 50 && playerDetected == true)
            {
                playerDetected = false;
            }
        }
        if (agent.remainingDistance <= 0 && reachedCheckpoint == false && playerDetected == false)
        {
            StartCoroutine(MoveToNextPoint());
        }

        //RaycastHit hit;
        //if(Physics.Raycast(raycastPos.position, transform.forward, out hit, Mathf.Infinity))
        //{
        //    Debug.DrawRay(raycastPos.position, transform.forward, Color.red);
        //    if (hit.collider.GetComponent<Player>())
        //    {
        //        playerDetected = true;
        //    }
        //}
    }

    IEnumerator MoveToNextPoint()
    {
        reachedCheckpoint = true;
        pointCounter++;
        if (pointCounter >= patrolPoints.Length)
        {
            pointCounter = 0;
        }
        yield return new WaitForSeconds(1);
        reachedCheckpoint = false;
    }
}
