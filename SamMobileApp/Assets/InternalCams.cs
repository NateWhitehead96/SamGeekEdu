using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalCams : MonoBehaviour
{
    public Image mainCamera;
    // button images
    public Image cam1;
    public Image cam2;

    public Image tempImage = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchImagesCam1()
    {
        tempImage.sprite = cam1.sprite;
        cam1.sprite = mainCamera.sprite;
        mainCamera.sprite = tempImage.sprite;
    }
    public void SwitchImagesCam2()
    {
        tempImage.sprite = cam2.sprite;
        cam2.sprite = mainCamera.sprite;
        mainCamera.sprite = tempImage.sprite;
    }
    public void ReturnToHome()
    {
        gameObject.SetActive(false);
    }
}
