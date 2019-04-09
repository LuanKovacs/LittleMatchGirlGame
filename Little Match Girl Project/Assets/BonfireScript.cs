using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Health>().can = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
         if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Health>().can = false;
        }
    }
}
