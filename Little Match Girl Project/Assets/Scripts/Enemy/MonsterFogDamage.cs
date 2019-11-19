using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFogDamage : MonoBehaviour
{
    public Player_Health playerHpRef;
    public float newDrainAmount = 10.0f;

    LightMatchScript matchRef;

    // Start is called before the first frame update
    void Start()
    {
        matchRef = GameObject.Find("Player").GetComponent<LightMatchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            matchRef.MathBlown();
            //playerHpRef.GainHP(false);
            playerHpRef.DrainHp(newDrainAmount);
            //playerHpRef.PleaseDie();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            playerHpRef.ResetDrain();
           // playerHpRef.GainHP(true);
        }
    }
}
