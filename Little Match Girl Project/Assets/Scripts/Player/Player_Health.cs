
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Tianna!!!!

public class Player_Health : MonoBehaviour
{
    public float maxHP = 100;
    public float curHP;
    public bool gainHP;
    public float maxDrainHP;
    float curDrainHP;
    bool isDead;
    public Image HealthPanel;//Tianna!!!!
    public GameObject healthTUT;

    Player_Movement playerMove;
    Rigidbody playerRBref;

    private void Start()
    {
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
        healthTUT.SetActive(false);
        //healthTUT.canvasRenderer.SetAlpha(0.0f);
        //HealthPanel.alpha = 0.0f;
        playerMove = GetComponent<Player_Movement>();
        playerRBref = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        curDrainHP = maxDrainHP;
        //gain HP
        if (gainHP == true && curHP <= maxHP)
        {
            curHP = curHP += 10.0f * Time.deltaTime;
            HealthPanel.CrossFadeAlpha(-curHP, 100, false);//Tianna!!!!
            //HealthPanel.alpha = curHP / 100;
            if (curHP > maxHP)
            {
                curHP = maxHP;
                HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
                                                          // HealthPanel.alpha = 0.0f;
            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP = curHP -= curDrainHP * Time.deltaTime;
            HealthPanel.CrossFadeAlpha(1, curHP, true);//Tianna!!!!
            //HealthPanel.alpha = curHP;
            if (curHP <= 70)
            {
                //Debug.Log("Fade In");
                healthTUT.SetActive(true);
                //healthTUT.canvasRenderer.SetAlpha(1f);
                //healthTUT.CrossFadeAlpha(1, 20, true);

            }
            if (curHP >= 70)
            {
                //Debug.Log("Fade Out");
                healthTUT.SetActive(false);
                //healthTUT.canvasRenderer.SetAlpha(0.0f);
                //healthTUT.CrossFadeAlpha(0, 20, true);
            }
        }
        if (isDead)
        {
            //playerRBref.velocity = Vector3.zero;
            playerRBref.constraints = RigidbodyConstraints.None;
            playerRBref.AddTorque(transform.right * 5 * 5);
            playerMove.canMove = false;
            EventManager.TriggerEvent("Dead");
        }
        else if (curHP <= 0 && !isDead)
        {
            // HealthPanel.alpha = 1.0f;
            HealthPanel.canvasRenderer.SetAlpha(1.0f);//Tianna!!!!
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

    public void DrainHp(float newDrain)
    {
        curDrainHP = newDrain;
    }

    public void ResetDrain()
    {
        curDrainHP = maxDrainHP;
    }

    public void DamageHP(float damage)
    {
        curHP -= damage;
    }

    public void PleaseDie()
    {
        if (!isDead)
            isDead = true;
    }


}

