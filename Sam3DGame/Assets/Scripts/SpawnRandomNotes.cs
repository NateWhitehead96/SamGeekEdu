using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomNotes : MonoBehaviour
{
    public List<GameObject> places;
    public GameObject Note;

    // Start is called before the first frame update
    void Start()
    {
        //places = new List<GameObject>();

        for (int i = 0; i < 5; i++) // spawn 5 notes
        {
            int pick = Random.Range(0, places.Count); // pick a random spot from our list
            Instantiate(Note, places[pick].transform.position, places[pick].transform.rotation); // spawn note
            places.RemoveAt(pick); // remove the spot
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
