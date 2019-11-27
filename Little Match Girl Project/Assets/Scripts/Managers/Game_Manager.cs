﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.StartListening("BridgePuzzle", BridgePuzzle);
        EventManager.StartListening("UnlockMatches", UnlockMatches);
        EventManager.StartListening("BeginChase", BeginChase);
        EventManager.StartListening("EndChase", EndChase);
        EventManager.StartListening("BeginCityChase", BeginCityChase);
        EventManager.StartListening("EndCityChase", EndChase);

        EventManager.StartListening("DarkRoomStart", DarkRoomStart);
        EventManager.StartListening("DarkRoomEnd", DarkRoomEnd);

        EventManager.StartListening("ChurchMemory", ChurchMemory);
        EventManager.StartListening("ChurchTransition", ChurchTransition);
        EventManager.StartListening("ChurchExit", ChurchExit);
        EventManager.StartListening("FinalCutScene", FinalCutScene);

        EventManager.StartListening("PlayerDeath", PlayerDeath);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
        EventManager.StopListening("UnlockMatches", UnlockMatches);
        EventManager.StopListening("BeginChase", BeginChase);
        EventManager.StartListening("EndChase", EndChase);
        EventManager.StartListening("BeginCityChase", BeginCityChase);
        EventManager.StartListening("EndCityChase", EndChase);

        EventManager.StopListening("DarkRoomStart", DarkRoomStart);
        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);

        EventManager.StopListening("ChurchMemory", ChurchMemory);
        EventManager.StopListening("ChurchTransition", ChurchTransition);
        EventManager.StopListening("ChurchExit", ChurchExit);
        EventManager.StopListening("FinalCutScene", FinalCutScene);

        EventManager.StopListening("PlayerDeath", PlayerDeath);
    }

    public GameObject Player;
    public GameObject CameraMain;
    public GameObject blizzard;
    public GameObject puzzleSetBridge;
    public GameObject ForestChase;
    public GameObject CityChase;
    public GameObject Monster;
    public GameObject ChurchPuzzle;
    public GameObject RuinedChurch;
    public GameObject ChurchTransit;

   
    public GameObject sitTrigger;
    public GameObject BrokenChurchLight;
    public GameObject churchSpotlit;
    public GameObject winPanel;
    public GameObject losePanel;
    public CanvasGroup LosePanelGroup;//Tianna!!!!
    public GameObject allLighting;
    public GameObject Gmusic;
    Color32 setColor = new Color32(51,66,91, 0);

    
    Player_Health playerHpRef;
    Player_Movement playerMove;
    LightMatchScript matchRef;

    private void Awake()
    {
        LosePanelGroup.alpha = 0.0f;
        playerHpRef = Player.GetComponent<Player_Health>();
        playerMove = Player.GetComponent<Player_Movement>();
        matchRef = Player.GetComponent<LightMatchScript>();
    }

    public void StartGame()
    {       
        CameraMain.GetComponent<CameraTopDown>().enabled = true;
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        Gmusic.SetActive(true);
        yield return new WaitForSeconds(1);
        playerHpRef.enabled = true;
        playerMove.canMove = true;
        
    }

    void UnlockMatches()
    {
        LightMatchScript lightMatch = Player.GetComponent<LightMatchScript>();
        lightMatch.enabled = true;
        EventManager.StopListening("UnlockMatches", UnlockMatches);
        print("Test");
    }

    void BridgePuzzle()
    {
        GameObject sound = GameObject.Find("Spotlight_Sound");

        AkSoundEngine.PostEvent("Spotlight_effect", sound);
        puzzleSetBridge.SetActive(true);
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
    }
    
    void BeginChase()
    {
        ForestChase.SetActive(true);
    }

    void BeginCityChase()
    {
        CityChase.SetActive(true);
    }

    void EndChase()
    {
        //ForestMonsterChase.SetActive(false);
        //Disable Monster
        //Play Burst Particles
        //^^All of this happens in the "PS_Burst" script^^
    }

    void DarkRoomStart()
    {
        blizzard.SetActive(false);
        Transform Forest = GameObject.Find("Terrain_Forest").transform;
        GameObject startDark = GameObject.Find("DarkroomCheckPoint");
       // GameObject dirLight = GameObject.Find("Directional Light");
        //GameObject dirLightN = GameObject.Find("Directional Light Night");
       // GameObject playerLight = GameObject.Find("PlayerLight");

        Player.transform.position = startDark.transform.position;
       // playerLight.SetActive(false);
        //dirLight.SetActive(false);
        allLighting.SetActive(false);
        //dirLightN.SetActive(true);

        //make matches longer
        playerHpRef.curDrainHP = 0.0f;
        matchRef.curMatchTime = 160.0f;

        //Forest.SetActive(false); //not permitted it says...
        //Destroy(Forest);
        //Cull forest area
        foreach (Transform child in Forest)
        {
             child.gameObject.SetActive(false);
        }

        RenderSettings.fog = false;//turn off global fog

        RenderSettings.ambientLight = Color.black;

        EventManager.StopListening("DarkRoomStart", DarkRoomStart);
    }

    void DarkRoomEnd()
    {
        GameObject startChurch = GameObject.Find("ChurchStart");
        RenderSettings.fog = true;//turn on global fog
        RenderSettings.ambientLight = setColor;

        ChurchPuzzle.SetActive(true);
        CameraMain.SetActive(false);

        Player.transform.position = startChurch.transform.position;

        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);
    }

    void ChurchMemory()
    {
        matchRef.MathBlown();
        AkSoundEngine.PostEvent("Play_Memories", gameObject);
        StartCoroutine(AnimDelayTime());
    }

    void ChurchTransition()
    {

        GameObject sound = GameObject.Find("ChurchBell_Sound");
        GameObject.Find("ChurchFBX_P").SetActive(false);
        churchSpotlit.SetActive(false);
        ChurchTransit.SetActive(false);
        BrokenChurchLight.SetActive(true);
        //GameObject.Find("ChurchLight").SetActive(false);
        RuinedChurch.SetActive(true);
        AkSoundEngine.PostEvent("Stop_Memories", gameObject);
        AkSoundEngine.PostEvent("Church_bell", sound);
    }

    void ChurchExit()
    {
        blizzard.SetActive(true);
        GameObject startGrave = GameObject.Find("GraveStart");
        playerHpRef.curDrainHP = playerHpRef.maxDrainHP;
        ChurchPuzzle.SetActive(false);
        allLighting.SetActive(true);
        CameraMain.SetActive(true);
        Player.transform.position = startGrave.transform.position;

        matchRef.curMatchTime = matchRef.maxMatchTime;
        print("Test");
    }

    void PlayerDeath()
    {
        CameraMain.GetComponent<CameraTopDown>().enabled = false;
        StartCoroutine(DeathState());
    }

    void FinalCutScene()//Tianna!!!!
    {
        GameObject Player = GameObject.Find("Player");
        GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();
        anim.Play("");

        StartCoroutine(DefaultWin());
    }

    IEnumerator AnimDelayTime()//Tianna!!!!
    {

        GameObject sit = GameObject.Find("Church Sit");
        GameObject sound = GameObject.Find("Spotlight_Sound (1)");
        Animator anim = GameObject.Find("CharacterModel&Rig").GetComponent<Animator>();
        yield return new WaitForSeconds(0.1f);
        Player.GetComponent<Rigidbody>().Sleep();
        playerMove.canMove = false;

        anim.Play("Sit");
        Player.transform.position = sit.transform.position;
        Player.transform.rotation = sit.transform.rotation;

        /*
        if (matchRef.isLit == true)
        {
            matchRef.isLit = false;
            yield return new WaitForSeconds(0.5f);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Sit");
            }             
        }
        else
        {
            anim.Play("Sit");
        }
        */
        yield return new WaitForSeconds(3.0f);

        AkSoundEngine.PostEvent("Spotlight_effect", sound);
        churchSpotlit.SetActive(true);
        ChurchTransit.SetActive(true);
        GameObject.Find("Spot Light (1)").SetActive(false);
        GameObject.Find("ChurchLight").SetActive(false);
        Player.GetComponent<Rigidbody>().WakeUp();
        playerMove.canMove = true;

        anim.Play("Idle");
        //  if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
        // {
        //   anim.Play("Idle");
        //}

    }

    IEnumerator DefaultWin()//Tianna!!!!
    {
        
        winPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("New LMG");

    }
    IEnumerator DeathState()
    {
        losePanel.SetActive(true);
        LosePanelGroup.alpha += (0.999f) * Time.deltaTime * 2f;//********Tianna
        playerHpRef.PleaseDie();
        yield return new WaitForSeconds(0.5f);

        playerHpRef.enabled = false;

        yield return new WaitForSeconds(3.0f);
        CameraMain.GetComponent<CameraTopDown>().enabled = true;

        playerHpRef.Revive();
        playerHpRef.enabled = true;
        GetComponent<RespawnCheckpoint>().Respawn();
        Player.transform.rotation = Quaternion.identity;

        EventManager.TriggerEvent("Reset");

        losePanel.SetActive(false);

        GameObject foresttrigger = GameObject.Find("EventTrigger BeginChase");
        GameObject citytrigger = GameObject.Find("EventTrigger BeginCityChase");
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
}
