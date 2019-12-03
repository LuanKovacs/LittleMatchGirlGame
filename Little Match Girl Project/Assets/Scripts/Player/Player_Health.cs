
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Tianna!!!!

public class Player_Health : MonoBehaviour
{

    public float maxHP = 100;
    public float curHP;
    public bool gainHP;
    public float maxGainHP, curGainHP;
    public float maxDrainHP, curDrainHP;
    public bool isDead;
    public CanvasGroup HealthPanel;//Tianna!!!!
    public CanvasGroup losePanel;//Tianna!!!!
    public GameObject matchTUT;

    Player_Movement playerMove;
    Rigidbody playerRBref;  
    public float maxHeartVol;

    public float HeartbeatVol = 0;
    public float BreathingVol = 5;

    GameObject EnemySound;
    

    public void Revive() 
    {
        EnemySound = GameObject.Find("Monster");

        AkSoundEngine.StopAll(EnemySound);

        HeartbeatVol = 0f;
        curGainHP = maxGainHP;
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        gainHP = false;
        isDead = false;
        HealthPanel.alpha = 0.0f;
        losePanel.alpha = 0.0f;
        playerRBref.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        playerMove.canMove = true;

        GameObject Player = GameObject.Find("Player");
        GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();
        anim.Play("Idle");//Tianna!!!!
    }

    private void Start()
    {
      
      //HeartbeatVol = maxHeartVol;
        
   
        AkSoundEngine.PostEvent("Girl_breathing", gameObject);
        // AkSoundEngine.SetRTPCValue("Girl_breathing", BreathingVol);

        //AkSoundEngine.SetRTPCValue("Heart_beat_volume", HeartbeatVol);
        AkSoundEngine.PostEvent("Heart_beat_02", gameObject);
        


        matchTUT.GetComponent<CanvasGroup>().alpha = 0;
        //matchTUT.canvasRenderer.SetAlpha(0f);
        curGainHP = maxGainHP;
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        //HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!

        playerMove = GetComponent<Player_Movement>();
        playerRBref = GetComponentInParent<Rigidbody>();

    }

    private void Update()
    {
       
       

        //gain HP
        if (gainHP == true && curHP < maxHP)
        {
            //float FireVol = 10;
            curHP = curHP += curGainHP * Time.deltaTime;
            HealthPanel.alpha -= (curGainHP / 100) * Time.deltaTime;
            HeartbeatVol -= (17/maxHeartVol) * Time.deltaTime;
             AkSoundEngine.SetRTPCValue("Heart_beat_volume", HeartbeatVol);
            // HealthPanel.CrossFadeAlpha(-curHP, 100, false);//Tianna!!!!
            //HealthPanel.alpha = 0;
            //GameObject Fire = GameObject.Find("Fire_Bonfire");
            //GameObject Fire2 = GameObject.Find("Fire_Bonfire (1)");
            //AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
           // AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
            //HealthPanel.alpha -= Time.deltaTime / curHP;
            if (curHP >= maxHP)
            {
                HeartbeatVol = 0;
                AkSoundEngine.SetRTPCValue("Heart_beat_volume", HeartbeatVol);

                curHP = maxHP;
               // HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
                HealthPanel.alpha = 0.0f;

            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP -= curDrainHP * Time.deltaTime;
            HeartbeatVol += (17/maxHeartVol) * Time.deltaTime;
            AkSoundEngine.SetRTPCValue("Heart_beat_volume", HeartbeatVol);
            //HealthPanel.CrossFadeAlpha(1, curHP, true);//Tianna!!!!
            //HealthPanel.canvasRenderer.SetAlpha(curHP / 1000);
            //HealthPanel.alpha += Time.deltaTime / curHP;
            //********** */
            HealthPanel.alpha += (curDrainHP / 100) * Time.deltaTime;
        }

        if (curHP <= 60)
        {

        }

        if (curHP <= 10)//Death anim play
        {
            curDrainHP = 1.5f;
 
            Debug.Log("it Worked?");
            playerMove.canMove = false;
            GameObject Player = GameObject.Find("Player");
            GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
            Animator anim = PlayerModel.GetComponent<Animator>();
            anim.Play("Death");//Tianna!!!!

             //AkSoundEngine.SetRTPCValue("Heart_beat_volume", HeartbeatVol);
        }
        else
        {
            GameObject Player = GameObject.Find("Player");
            GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
            Animator anim = PlayerModel.GetComponent<Animator>();
           // anim.Play("Entry");//Tianna!!!!
        }

        if (isDead)
        {
            HeartbeatVol = maxHeartVol;
            //playerRBref.velocity = Vector3.zero;
            playerRBref.constraints = RigidbodyConstraints.None;
            playerRBref.AddTorque(transform.right * 5 * 5);
            playerMove.canMove = false;
            EventManager.TriggerEvent("PlayerDeath");
        }

        if (curHP <= 0 && !isDead)
        {
            HealthPanel.alpha = 1.0f;
            //HealthPanel.canvasRenderer.SetAlpha(1.0f);//Tianna!!!!
            isDead = true;
            //gameObject.tag = "Dead";
        }

        /*LightMatchScript lightMatch = gameObject.GetComponent<LightMatchScript>();
        if(lightMatch.enabled)
        {
            healthTUT.SetActive(true);
        }*/
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
/*
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "HP/" + curHP.ToString());
    }
*/
}

