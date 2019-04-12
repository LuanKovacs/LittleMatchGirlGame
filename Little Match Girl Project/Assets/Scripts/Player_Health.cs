using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float maxHP = 100;
    public float curHP;
    public bool gainHP;

    private void Start() 
    {
        curHP = maxHP;

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
