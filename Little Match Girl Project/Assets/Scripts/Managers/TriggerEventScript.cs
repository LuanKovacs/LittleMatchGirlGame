using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventScript : MonoBehaviour
{

    public string callEvent;
    public bool triggered;
    Collider colRef;
    Player_Health playerHPref;

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
        playerHPref = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        colRef = GetComponent<Collider>();
    }

    private void Reset()
    {
       // gameObject.SetActive(true);
        colRef.enabled = true;
        triggered = false;
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
        triggered = true;
        if (other.gameObject.tag == "Player" && !playerHPref.isDead)
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
           else
            {
               // gameObject.SetActive(false);
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
