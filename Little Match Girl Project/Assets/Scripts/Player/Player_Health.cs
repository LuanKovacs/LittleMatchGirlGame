
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Tianna!!!!

public class Player_Health : MonoBehaviour
{
    public float maxHP = 100;
    public float curHP;
    public bool gainHP;
    public float drainHP = 0.1f;
    bool isDead;
    public Image Ice;//Tianna!!!!

    Player_Movement playerMove;
    Rigidbody playerRBref;

    private void Start() 
    {
        curHP = maxHP;
        Ice.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
        playerMove = GetComponent<Player_Movement>();
        playerRBref = GetComponentInParent<Rigidbody>();
    }
        
    private void Update() 
    {
        //gain HP
        if (gainHP == true && curHP <= maxHP)
        {
            curHP = curHP += 10.0f * Time.deltaTime;
            Ice.CrossFadeAlpha(-curHP,140 , false);//Tianna!!!!

            if (curHP > maxHP)
            {
                curHP = maxHP;
                Ice.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP = curHP -= drainHP * Time.deltaTime;
            Ice.CrossFadeAlpha(1, curHP, false);//Tianna!!!!
        }
        if(isDead)
        {
            playerRBref.velocity = Vector3.zero;
            playerMove.canMove = false;
            EventManager.TriggerEvent("Dead");
        }
        else if(curHP <= 0 && !isDead)
        {
            Ice.canvasRenderer.SetAlpha(1.0f);//Tianna!!!!
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
