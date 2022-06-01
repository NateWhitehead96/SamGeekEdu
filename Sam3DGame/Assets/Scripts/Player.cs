using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool jumping;
    public Rigidbody rb;

    public float horizontalSpeed;
    public float verticalSpeed;
    public float xRotation;
    public float yRotation;

    public Vector3 forwardDirection; // a new vector3 to know our forward vector

    public bool exposed; // player is in the light
    public Transform restart;

    public GameObject flashLight;
    public int notesCollected; // how many notes we collect
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // lock our cursor to the middle of the screen
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // handle all of the moving
        RotatePlayer(); // handle all rotations
        Jump(); // handle jumping

        if (Input.GetMouseButtonDown(0))
        {
            if (flashLight.activeInHierarchy)
            {
                flashLight.SetActive(false);
            }
            else
            {
                flashLight.SetActive(true);
            }
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // gets any horizontal inputs (A, D, left/right arrows, left stick gamepad)
        float vertical = Input.GetAxisRaw("Vertical"); // gets any vertical input
        forwardDirection = (transform.forward * vertical) + (transform.right * horizontal);
        transform.position += forwardDirection * (moveSpeed * Time.deltaTime);
    }
    void RotatePlayer()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        yRotation = mouseX * horizontalSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y");
        xRotation = mouseY * verticalSpeed * Time.deltaTime;

        Vector3 playerRotation = transform.rotation.eulerAngles; // current rotation
        playerRotation.y += yRotation; // applying the y rotation
        playerRotation.x -= xRotation; // applying the x rotation
        transform.rotation = Quaternion.Euler(playerRotation); // setting the new roation to our players
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            exposed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            exposed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false;

        if (collision.gameObject.GetComponent<PatrolEnemy>())
        {
            transform.position = restart.position;
        }
        if (collision.gameObject.GetComponent<Note>())
        {
            notesCollected++;
            Destroy(collision.gameObject);
        }
    }
}
