using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Text WelcomeMessage;

    public GameObject InternalCamsPage;
    public GameObject AlarmPage;
    public GameObject LightPage;
    public GameObject ExteriorCamsPage;
    public GameObject MotionSensorPage;
    public GameObject LockdownPage;
    // Start is called before the first frame update
    void Start()
    {
        WelcomeMessage.text = "Welcome back " + ProfileSaver.instance.username;
        InternalCamsPage.SetActive(false);
        AlarmPage.SetActive(false);
        LightPage.SetActive(false);
        ExteriorCamsPage.SetActive(false);
        MotionSensorPage.SetActive(false);
        LockdownPage.SetActive(false);
    }

    public void OpenInternalCams()
    {
        InternalCamsPage.SetActive(true);
    }

    public void OpenAlarm()
    {
        AlarmPage.SetActive(true);
    }
    public void OpenLights()
    {
        LightPage.SetActive(true);
    }
    public void OpenExternalCams()
    {
        ExteriorCamsPage.SetActive(true);
    }
    public void OpenMotionSensor()
    {
        MotionSensorPage.SetActive(true);
    }
    public void OpenLockdown()
    {
        LockdownPage.SetActive(true);
    }
}
