using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public GameObject target;
    public float damage = 30;

    bool canDamage;
    Enemy_AI enemyRef;
    Player_Health playerHPref;

    private void Awake() 
    {
        enemyRef = GetComponentInParent<Enemy_AI>();
        playerHPref = target.GetComponentInParent<Player_Health>();
    }

    void OnEnable()
    {
        canDamage = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (target)
        {
            SendDamage();
        }
    }

    void SendDamage()
    {
        if(canDamage == true)
        {
            canDamage = false;
            playerHPref.DamageHP(damage);
        }
    }


}
