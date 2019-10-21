
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
    public float curDrainHP;
    public bool isDead;
    public Image HealthPanel;//Tianna!!!!
    public GameObject matchTUT;

    Player_Movement playerMove;
    Rigidbody playerRBref;

    public void Revive() 
    {
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        isDead = false;
        playerRBref.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        playerMove.canMove = true;
    }

    private void Start()
    {
        matchTUT.GetComponent<CanvasGroup>().alpha = 0;
        //matchTUT.canvasRenderer.SetAlpha(0f);
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        //HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
        playerMove = GetComponent<Player_Movement>();
        playerRBref = GetComponentInParent<Rigidbody>();

    }

    private void Update()
    {
       
        //gain HP
        if (gainHP == true && curHP <= maxHP)
        {
            curHP = curHP += 10.0f * Time.deltaTime;
            HealthPanel.CrossFadeAlpha(-curHP, 100, false);//Tianna!!!!
            //HealthPanel.alpha -= Time.deltaTime / curHP;
            if (curHP > maxHP)
            {
                curHP = maxHP;
                HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
                //HealthPanel.alpha = 0.0f;
            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP = curHP -= curDrainHP * Time.deltaTime;
            HealthPanel.CrossFadeAlpha(1, curHP, true);//Tianna!!!!
            //HealthPanel.alpha += Time.deltaTime / curHP;

        }

        if (isDead)
        {
            //playerRBref.velocity = Vector3.zero;
            playerRBref.constraints = RigidbodyConstraints.None;
            playerRBref.AddTorque(transform.right * 5 * 5);
            playerMove.canMove = false;
            EventManager.TriggerEvent("PlayerDeath");
        }

        if (curHP <= 0 && !isDead)
        {
            //HealthPanel.alpha = 1.0f;
            HealthPanel.canvasRenderer.SetAlpha(1.0f);//Tianna!!!!
            isDead = true;
            //gameObject.tag = "Dead";
        }

        /*LightMatchScript lightMatch = gameObject.GetComponent<LightMatchScript>();
        if(lightMatch.enabled)
        {
            healthTUT.SetActive(true);
        }*/
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
        print("TestNewDrain");
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
        //curHP = 0.0f;
        isDead = true;
    
    }


}

