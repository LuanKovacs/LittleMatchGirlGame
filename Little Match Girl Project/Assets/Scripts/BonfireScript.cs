/*  By:Ricardo III Ticlao
    Bonfire Heal Script
    09/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{
    Player_Health playerhpRef;

    private void Start()
    {
        playerhpRef = GetComponent<Player_Health>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Health>().GainHP(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
         if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Health>().GainHP(false);
        }
    }
}//End
