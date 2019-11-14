
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
    public GameObject citytrigger;
    public GameObject foresttrigger;

    Player_Movement playerMove;
    Rigidbody playerRBref;
    
    

    public void Revive() 
    {
        curDrainHP = maxDrainHP;
        curHP = maxHP;
        isDead = false;
        playerRBref.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        playerMove.canMove = true;

        GameObject Player = GameObject.Find("Player");
        GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();
        anim.Play("Idle");//Tianna!!!!

    }

    private void Start()
    {
        GameObject Fire = GameObject.Find("Fire_Bonfire");
        GameObject Fire2 = GameObject.Find("Fire_Bonfire (1)");

        float FireVol = 40;
        float HeartbeatVol = 0;
        //GameObject playerSound = GameObject.Find("player_Sound");
        AkSoundEngine.SetRTPCValue("Heart_beat", HeartbeatVol);
        AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol, Fire);
        AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol, Fire2);

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
            float FireVol = 40;
            curHP = curHP += 10.0f * Time.deltaTime;
            HealthPanel.CrossFadeAlpha(-curHP, 100, false);//Tianna!!!!

            GameObject Fire = GameObject.Find("Fire_Bonfire");
            GameObject Fire2 = GameObject.Find("Fire_Bonfire (1)");
            AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol, Fire);
            AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol, Fire2);
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
        if(curHP <= 10)//Death anim play
        {
            float HeartbeatVol = 10;
            //GameObject playerSound = GameObject.Find("player_Sound");

            AkSoundEngine.SetRTPCValue("Heart_beat", HeartbeatVol);
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

            GameObject forestEvent = GameObject.Find("ForestMonsterChase");
            GameObject cityEvent = GameObject.Find("CityMonsterChase");
            GameObject camera = GameObject.Find("Main Camera");
            Animator camAnim = camera.GetComponent<Animator>();
            
            if (forestEvent != null)//Tianna!!!!
            {
                forestEvent.SetActive(false);
                foresttrigger.SetActive(true);
                camAnim.enabled = false;

            }
            if (cityEvent != null)//Tianna!!!!
            {
                cityEvent.SetActive(false);
                citytrigger.SetActive(true);
                camAnim.enabled = false;
            }

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

