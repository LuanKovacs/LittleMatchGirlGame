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
            if (gainHP == true && curHP < maxHP)
            {
                curHP = curHP += 1f * Time.deltaTime;
            }

            //drain HP
            if (!gainHP && curHP >= 0)
            {
            curHP = curHP -= 0.1f;
            }
        }

        public void GainHP(bool can)
        {
            gainHP = can;
        }


        public void DamageHP(float hp)
        {

        }


}
