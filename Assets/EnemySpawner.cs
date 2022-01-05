using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float bounds; // the top and bottom boundary of our game
    public GameObject Enemy; // the prefab enemy to spawn

    public float timer; // our current time
    public float SpawnTime = 2; // time it take to spawn

    public int NumberOfEnemies; // how many enemies to spawn for per wave

    // Start is called before the first frame update
    void Start()
    {
        ScoringSystem.Waves = 1;
        NumberOfEnemies = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= SpawnTime && NumberOfEnemies > 0) // spawn the enemy
        {
            float randomY = Random.Range(-bounds, bounds); // this is a random number inside our bounds
            GameObject newEnemy = Instantiate(Enemy, new Vector3(transform.position.x, randomY), Quaternion.identity); // spawning the enemy
            newEnemy.GetComponent<EnemyScript>().moveSpeed = Random.Range(1, ScoringSystem.Waves + 1); // randomly set the enemy move speed
            timer = 0; // reset timer
            NumberOfEnemies--;
            if(NumberOfEnemies <= 0) // when we run our of enemies to spawn start the next wave
            {
                StartCoroutine(NewWave());
            }
        }
        timer += Time.deltaTime; // increment timer
    }

    IEnumerator NewWave()
    {
        yield return new WaitForSeconds(5);
        ScoringSystem.Waves++;
        NumberOfEnemies += ScoringSystem.Waves * 3;
        SpawnTime -= 0.2f;
    }
}
