using System.Collections;
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
    public GameObject MemoryMusic;
    public GameObject BackgroundMusic;
    public GameObject BadChurchMusic;

    public GameObject sitTrigger;
    public GameObject BrokenChurchLight;
    public GameObject churchSpotlit;
    public GameObject winPanel;
    public GameObject losePanel;
    public CanvasGroup LosePanelGroup;//Tianna!!!!
    public GameObject allLighting;
    public GameObject FinalDoors;

    public object result;
    //public GameObject BGmusic;
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
        BackgroundMusic.SetActive(true);
        yield return new WaitForSeconds(1);
        EventManager.TriggerEvent("GameStart");
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
        AkSoundEngine.PostEvent("Stop_General", BackgroundMusic);
        AkSoundEngine.PostEvent("Blizzard_creature", BackgroundMusic);
        AkSoundEngine.PostEvent("Play_Chase", BackgroundMusic);
    }

    void BeginCityChase()
    {
        CityChase.SetActive(true);
        AkSoundEngine.PostEvent("Stop_City", BackgroundMusic);
        AkSoundEngine.PostEvent("Blizzard_creature", BackgroundMusic);
        AkSoundEngine.PostEvent("Play_Chase", BackgroundMusic);
    }

    void EndChase()
    {
        AkSoundEngine.PostEvent("Play_General", BackgroundMusic);
        AkSoundEngine.PostEvent("Stop_Blizzard_creature", BackgroundMusic);
        AkSoundEngine.PostEvent("Stop_Chase", BackgroundMusic);
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
        //AkSoundEngine.PostEvent("Play_Intense_Church", MemoryMusic);

        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);
    }

    void ChurchMemory()
    {
      

        matchRef.MathBlown();
     

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
        AkSoundEngine.PostEvent("Church_bell", sound);
        BadChurchMusic.SetActive(true);
        
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
        GameObject CityMusic = GameObject.Find("CityMusic");
        GameObject Player = GameObject.Find("Player");
        GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();
        //StartCoroutine(MoveToFinalAnim());
        //anim.GetBool("moving") = false;
        AkSoundEngine.SetRTPCValue("Foostep_volume", 0f);
        AkSoundEngine.StopAll(Player);
        AkSoundEngine.PostEvent("Stop_City", CityMusic);
        AkSoundEngine.PostEvent("Play_Musicbox", gameObject);
        anim.Play("FinalDeath");
        Player_Movement canmove = Player.GetComponent<Player_Movement>();
        canmove.canMove = false;
        losePanel.SetActive(true);
        LosePanelGroup.alpha += (0.999f) * Time.deltaTime * 3f;
        FinalDoors.SetActive(true);
        StartCoroutine(DefaultWin());
   
        //********Tianna
        // FinalDoors.SetActive(true);
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
        GameObject.Find("GoodChurchMusic").SetActive(false);
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
        //yield return new WaitForSeconds(2.0f);
        
        yield return new WaitForSeconds(10.0f);
        AkSoundEngine.PostEvent("Stop_Musicbox", gameObject);
        SceneManager.LoadScene("New LMG");

    }
    IEnumerator DeathState()
    {
        losePanel.SetActive(true);
        LosePanelGroup.alpha += (0.999f) * Time.deltaTime * 2f;//********Tianna
        playerHpRef.PleaseDie();
        yield return new WaitForSeconds(0.5f);

        playerHpRef.enabled = false;
        GetComponent<RespawnCheckpoint>().Respawn();

        yield return new WaitForSeconds(3.0f);
        Player.transform.rotation = Quaternion.identity;
        playerHpRef.Revive();
        playerHpRef.enabled = true;

        EventManager.TriggerEvent("Reset");

        losePanel.SetActive(false);
        CameraMain.GetComponent<CameraTopDown>().enabled = true;

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

    IEnumerator MoveToFinalAnim()
    {
        Debug.Log("coroutine is playing!!");

        Player_Movement canmove = Player.GetComponent<Player_Movement>();

        canmove.canMove = false;
        Vector3 currentPos = transform.position;
        Transform tarPos = GameObject.FindWithTag("FinalPos").transform;

        //GameObject Player = GameObject.Find("Player");
        GameObject PlayerModel = Player.transform.Find("CharacterModel&Rig").gameObject;
        Animator anim = PlayerModel.GetComponent<Animator>();

        anim.SetFloat("Speed", 8);//Anim play walk

        if (currentPos != tarPos.position && !canmove.canMove)
        {
            Debug.Log("hasPassed");
            transform.LookAt(tarPos);
            transform.position = Vector3.MoveTowards(currentPos, tarPos.position, 5 * Time.deltaTime);
            yield return new WaitForSeconds(5.0f);
        }
        else
        {
            
        }

        //yield return result;
    }
}
