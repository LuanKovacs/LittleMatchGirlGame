using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFogDamage : MonoBehaviour
{
    public Player_Health playerHpRef;
    public float newDrainAmount = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHpRef.DrainHp(newDrainAmount);
            //playerHpRef.PleaseDie();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            playerHpRef.ResetDrain();           
        }
    }
}
