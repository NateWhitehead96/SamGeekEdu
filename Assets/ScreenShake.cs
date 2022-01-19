using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration; // how long the shake will be
    public float shakeMagnitude; // how aggresive the shake will be
    public float damping; // slowing down the shake
    public Vector3 initalPosition; // start pos of the camera
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0) // we can still shake, then do the shaking
        {
            transform.localPosition = initalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * damping;
        }
        if( shakeDuration <= 0) // if we're done shaking, the reset position
        {
            transform.position = initalPosition;
        }
    }
}
