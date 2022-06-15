using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Wander,
    Chase,
    Alert
}

public class MonsterScript : MonoBehaviour
{
    public NavMeshAgent agent; // its navigation
    public Transform player;
    public State state;
    public Vector3 moveDirection;
    public float timer;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if(state == State.Wander)
        {
            if(timer >= 5) // randomly move the monster every 5 seconds
            {
                float newX = Random.Range(transform.position.x - 100, transform.position.x + 100); // find a random X position
                float newZ = Random.Range(transform.position.z - 100, transform.position.z + 100); // find a random Z position
                moveDirection = new Vector3(newX, transform.position.y, newZ); // new move direction
                agent.SetDestination(moveDirection);
                timer = 0;
            }
            timer += Time.deltaTime;
            if(distance <= 100 && player.GetComponent<Player>().exposed == true)
            {
                state = State.Chase; // activate the chase if player is near
            }
        }
        if(state == State.Chase) // the chase is on, the monster will chase after the player
        {
            agent.SetDestination(player.position);
            if (distance > 100 || player.GetComponent<Player>().exposed == false)
                state = State.Wander;
        }
        if(state == State.Alert) // the monster is alerted to where a note was grabbed
        {
            agent.SetDestination(moveDirection); // reuse move direction as the position we gather the note
            agent.speed = 10;
            if (agent.remainingDistance <= 10)
            {
                if (distance > 100)
                {
                    state = State.Wander;
                    agent.speed = 6;
                }
                else
                {
                    state = State.Chase;
                    agent.speed = 6;
                }
            }
        }
    }
}
