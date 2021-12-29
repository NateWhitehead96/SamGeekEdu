using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject snowball; // this will be a refrence to our snowball prefab
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // this is left click input
        {
            GameObject newSnowball = Instantiate(snowball, transform.position, Quaternion.identity); // creating a new snowball
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // find our mouse position
            Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse position
            newSnowball.GetComponent<SnowballScript>().MoveToPostion = new Vector3(shootDirection.x, shootDirection.y); // applying movement to our snowball
        }
    }
}
