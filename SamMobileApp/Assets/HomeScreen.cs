using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Text WelcomeMessage;

    public GameObject InternalCamsPage;
    // Start is called before the first frame update
    void Start()
    {
        WelcomeMessage.text = "Welcome back " + ProfileSaver.instance.username;
        InternalCamsPage.SetActive(false);
    }

    public void OpenInternalCams()
    {
        InternalCamsPage.SetActive(true);
    }
}
