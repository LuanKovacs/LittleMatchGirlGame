﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnTrigger : MonoBehaviour
{
    

    Animator anim;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim = GetComponent<Animator>();
            anim.Play("ButtonDown");

            GameObject Player = GameObject.Find("Player");
            
          
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim = GetComponent<Animator>();
            anim.Play("ButtonUp");
        }
    }
}
