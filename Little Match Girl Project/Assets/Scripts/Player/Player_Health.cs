
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

    public void Revive() 
    {
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
        //GameObject Fire = GameObject.Find("Fire_Bonfire");
        //GameObject Fire2 = GameObject.Find("Fire_Bonfire (1)");

        //float FireVol = 10;
        float HeartbeatVol = 60;
        //GameObject playerSound = GameObject.Find("player_Sound");
        AkSoundEngine.PostEvent("Heart_beat_02", gameObject);
        AkSoundEngine.SetRTPCValue("Heart_beat_02", HeartbeatVol);
        //AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
        //AkSoundEngine.PostEvent("Fire_crackling", gameObject);
        //AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
        GameObject playerSound = GameObject.Find("player_Sound");
        //AkSoundEngine.PostEvent("Heart_beat", playerSound);

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
            // HealthPanel.CrossFadeAlpha(-curHP, 100, false);//Tianna!!!!
            //HealthPanel.alpha = 0;
            //GameObject Fire = GameObject.Find("Fire_Bonfire");
            //GameObject Fire2 = GameObject.Find("Fire_Bonfire (1)");
            //AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
           // AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
            //HealthPanel.alpha -= Time.deltaTime / curHP;
            if (curHP >= maxHP)
            {
                curHP = maxHP;
               // HealthPanel.canvasRenderer.SetAlpha(0.0f);//Tianna!!!!
                HealthPanel.alpha = 0.0f;

            }
        }

        //drain HP
        if (gainHP == false && curHP >= 0)
        {
            curHP -= curDrainHP * Time.deltaTime;
            //HealthPanel.CrossFadeAlpha(1, curHP, true);//Tianna!!!!
            //HealthPanel.canvasRenderer.SetAlpha(curHP / 1000);
            //HealthPanel.alpha += Time.deltaTime / curHP;
            HealthPanel.alpha += (curDrainHP / 100) * Time.deltaTime;
        }

        if (curHP <= 60)
        {

        }

        if (curHP <= 10)//Death anim play
        {
            curDrainHP = 1.5f;
            //float HeartbeatVol = 60;
            //GameObject playerSound = GameObject.Find("player_Sound");
            //AkSoundEngine.SetRTPCValue("Heart_beat", HeartbeatVol);
            Debug.Log("it Worked?");
            playerMove.canMove = false;
            GameObject Player = GameObject.Find("Player");
            GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
            Animator anim = PlayerModel.GetComponent<Animator>();
            anim.Play("Death");//Tianna!!!!
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

