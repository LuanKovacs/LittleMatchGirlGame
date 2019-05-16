using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float maxHP = 100;
    public float curHP;
    public bool gainHP;
    bool isDead;

    Player_Movement playerMove;
    Rigidbody playerRBref;

    private void Start() 
    {
        curHP = maxHP;
        playerMove = GetComponent<Player_Movement>();
         playerRBref = GetComponentInParent<Rigidbody>();
    }
        
    private void Update() 
    {
        //gain HP
        if (gainHP == true && curHP <= maxHP)
        {
            curHP = curHP += 10.0f * Time.deltaTime;
                
            if(curHP > maxHP)
            {
                curHP = maxHP;
            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP = curHP -= 0.1f * Time.deltaTime;
        }
        if(isDead)
        {
            playerRBref.velocity = Vector3.zero;
            playerMove.canMove = false;
            EventManager.TriggerEvent("Dead");
        }
        else if(curHP <= 0 && !isDead)
        {
            isDead = true;
            //gameObject.tag = "Dead";
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "HP/" + curHP.ToString());
    }

    public void GainHP(bool can)
    {
        gainHP = can;
    }


    public void DamageHP(float damage)
    {
        curHP -= damage;
    }


}
