using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingPlatform : MonoBehaviour
{
    public float shakeDuration = 1f; // how long to shake
    public float shakeMagnitude = 0.1f; // how hard it will shake
    public float damping = 1; // how fast it slows
    private Vector3 initialPosition;
    public float fallTime = 5;
    public bool falling;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0 && falling)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude; // the shaking code
            shakeDuration -= Time.deltaTime * damping;
        }
        else if (falling && shakeDuration <= 0) // moving down when we're done shaking
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime);
            fallTime -= Time.deltaTime;
        }

        if(fallTime <= 0 && falling) // reset the platform when the time runs out
        {
            falling = false;
            shakeDuration = 1;
            fallTime = 5;
            transform.position = initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falling = true;
        }
    }
}
