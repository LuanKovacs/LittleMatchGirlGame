/*  By:Ricardo III Ticlao
    Bonfire Heal Script
    09/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{
    GameObject Player;
    Player_Health playerHP;
    LightMatchScript playerMatch;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMatch = Player.GetComponent<LightMatchScript>();
        playerHP = Player.GetComponent<Player_Health>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Player_Health>().GainHP(true);
            //other.gameObject.GetComponent<LightMatchScript>().GainMatch();

            playerHP.GainHP(true);
            playerMatch.GainMatch();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        playerHP.GainHP(true);
    }

    void OnTriggerExit(Collider other)
    {
         if(other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Player_Health>().GainHP(false);

            if (!playerMatch.isLit)
            {
                playerHP.GainHP(false);
            }
        }
    }

}//End
