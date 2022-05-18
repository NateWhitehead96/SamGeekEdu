using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmSystem : MonoBehaviour
{
    public Text displayText;
    bool armed;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Alarm System: Disarmed";
    }

    public void ReturnToHome()
    {
        gameObject.SetActive(false);
    }
    public void ArmAlarm()
    {
        if (armed) // if it was armed
        {
            displayText.text = "Alarm System: Disarmed";
            armed = false;
        }
        else if (armed == false)
        {
            displayText.text = "Alarm System: Armed";
            armed = true;
        }
    }
}
