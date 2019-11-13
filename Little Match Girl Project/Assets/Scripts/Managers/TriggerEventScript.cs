using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventScript : MonoBehaviour
{

    public string callEvent;

    Collider colRef;

    private void OnEnable()
    {
        EventManager.StartListening("Reset", Reset);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Reset", Reset);
    }

    private void Start()
    {
        colRef = GetComponent<Collider>();
    }

    private void Reset()
    {
       // gameObject.SetActive(true);
        colRef.enabled = true;

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent(callEvent);
           // gameObject.SetActive(false);
            colRef.enabled = false;

           if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                   child.gameObject.SetActive(false);
                }
            }
        }
        else
        {

        }
    }

    public void CallEvent()
    {
        print(callEvent);
        EventManager.TriggerEvent(callEvent);
       // gameObject.SetActive(false);
        colRef.enabled = false;

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
               child.gameObject.SetActive(false);
            }
        }
    }
}
