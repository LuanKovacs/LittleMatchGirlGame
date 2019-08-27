using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventScript : MonoBehaviour
{

    public string callEvent;

    private void OnEnable()
    {
        EventManager.StartListening("Reset", Reset);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Reset", Reset);
    }

    private void Reset()
    {
        gameObject.SetActive(true);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent(callEvent);
            gameObject.SetActive(false);
        }
        else
        {

        }
    }

    public void CallEvent()
    {
        EventManager.TriggerEvent(callEvent);
        gameObject.SetActive(false);
    }
}
