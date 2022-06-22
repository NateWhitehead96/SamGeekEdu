using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteIndicator : MonoBehaviour
{
    public Image indicator; // the circle on our UI that will change color
    public Text distanceTracker; // will tell the player the distance
    public List<Note> notes; // a list of all of our notes
    public Transform player; // also need player position
    Note nearestNote; // have something store our nearest note
    public float nearestDistance = float.MaxValue; // and something that knows how far it is
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        nearestDistance = float.MaxValue;
        foreach (Note note in notes) // loop through all notes
        {
            float distance = Vector3.Distance(note.transform.position, player.position); // calculate distance from note to player
            if(distance < nearestDistance) // whichever note is the closests
            {
                nearestDistance = distance; // we set our nearest dist to be our distance
                nearestNote = note; // set our note as well, might not be needed we need to check
            }
        }
        if(nearestDistance >= 400)
        {
            indicator.color = Color.blue;
        }
        if(nearestDistance > 100 && nearestDistance < 400)
        {
            indicator.color = Color.green;
        }
        if(nearestDistance > 50 && nearestDistance < 100)
        {
            indicator.color = Color.yellow;
        }
        if(nearestDistance <= 50)
        {
            indicator.color = Color.red;
        }
        distanceTracker.text = nearestDistance.ToString("F2"); // shows up to 2 decimal places
    }
}
