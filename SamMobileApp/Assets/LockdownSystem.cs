using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockdownSystem : MonoBehaviour
{
    public GameObject popup;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    public void ActivateLockdown()
    {
        displayText.text = "All systems are locked down, and the police are on the way.";
    }

    public void ShowPopup()
    {
        popup.SetActive(true);
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }

    public void ReturnToHome()
    {
        gameObject.SetActive(false);
    }
}
