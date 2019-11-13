using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject puzzleSetBridge;
    public GameObject ForestChase;
    public GameObject CityChase;
    public GameObject Monster;
    public GameObject ChurchPuzzle;
    public GameObject RuinedChurch;
    public GameObject ChurchTransit;

    public GameObject BrokenChurchLight;
    public GameObject churchSpotlit;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject allLighting;
    Color32 setColor = new Color32(51,66,91, 0);

    public void StartGame()
    {
        CameraMain.GetComponent<CameraTopDown>().enabled = true;
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        Player.GetComponent<Player_Health>().enabled = true;
        Player.GetComponent<Player_Movement>().canMove = true;
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
        StartCoroutine(AnimDelayTime());
    }

    void ChurchTransition()
    {
        GameObject.Find("ChurchFBX_P").SetActive(false);
        churchSpotlit.SetActive(false);
        ChurchTransit.SetActive(false);
        BrokenChurchLight.SetActive(true);
        //GameObject.Find("ChurchLight").SetActive(false);
        RuinedChurch.SetActive(true);
    }

    void ChurchExit()
    {
        GameObject startGrave = GameObject.Find("GraveStart");
        ChurchPuzzle.SetActive(false);
        allLighting.SetActive(true);
        CameraMain.SetActive(true);
        Player.transform.position = startGrave.transform.position;
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
        Animator anim = GameObject.Find("CharacterModel&Rig").GetComponent<Animator>();
        anim.Play("Sit");

        Player.GetComponent<Player_Health>().enabled = true;
        Player.GetComponent<Player_Movement>().enabled = true;

        yield return new WaitForSeconds(3.0f);
        churchSpotlit.SetActive(true);
        ChurchTransit.SetActive(true);
        GameObject.Find("Spot Light (1)").SetActive(false);
        GameObject.Find("ChurchLight").SetActive(false);
        
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
        Player.GetComponent<Player_Health>().PleaseDie();
        yield return new WaitForSeconds(0.5f);

        Player.GetComponent<Player_Health>().enabled = false;

        yield return new WaitForSeconds(3.0f);
        CameraMain.GetComponent<CameraTopDown>().enabled = true;
        GetComponent<RespawnCheckpoint>().Respawn();
        
        Player.transform.rotation = Quaternion.identity;
        Player.GetComponent<Player_Health>().Revive();

        EventManager.TriggerEvent("Reset");

        losePanel.SetActive(false);
        Player.GetComponent<Player_Health>().enabled = true;

    }
}
