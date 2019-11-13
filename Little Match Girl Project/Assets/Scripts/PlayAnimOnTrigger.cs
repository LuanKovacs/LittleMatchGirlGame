using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnTrigger : MonoBehaviour
{
    public string sound;

    Animator anim;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim = GetComponent<Animator>();
            anim.Play("ButtonDown");
            AkSoundEngine.SetSwitch("Puzzle_game", sound, gameObject);
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
