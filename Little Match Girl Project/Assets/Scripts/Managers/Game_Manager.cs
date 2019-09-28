using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.StartListening("BridgePuzzle", BridgePuzzle);
        EventManager.StartListening("UnlockMatches", UnlockMatches);
        EventManager.StartListening("BeginChase", BeginChase);
        EventManager.StartListening("EndChase", EndChase);

        EventManager.StartListening("DarkRoomStart", DarkRoomStart);
        EventManager.StartListening("DarkRoomEnd", DarkRoomEnd);
        
        EventManager.StartListening("PlayerDeath", PlayerDeath);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
        EventManager.StopListening("UnlockMatches", UnlockMatches);
        EventManager.StopListening("BeginChase", BeginChase);
        EventManager.StartListening("EndChase", EndChase);

        EventManager.StopListening("DarkRoomStart", DarkRoomStart);
        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);

        EventManager.StopListening("PlayerDeath", PlayerDeath);
    }

    public GameObject Player;
    public GameObject CameraMain;
    public GameObject puzzleSetBridge;
    public GameObject ForestMonsterChase;

    Color32 setColor = new Color32(51,66,91, 0);

    public void StartGame()
    {
        CameraMain.GetComponent<CameraTopDown>().enabled = true;
        StartCoroutine("GameStart");
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        Player.GetComponent<Player_Health>().enabled = true;
        Player.GetComponent<Player_Movement>().enabled = true;
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
        ForestMonsterChase.SetActive(true);
    }

    void EndChase()
    {
        ForestMonsterChase.SetActive(false);
    }

    void DarkRoomStart()
    {
        GameObject Forest = GameObject.Find("Terrain_Forest");
        GameObject startDark = GameObject.Find("DarkroomCheckPoint");
        GameObject dirLight = GameObject.Find("Directional Light");
        //GameObject dirLightN = GameObject.Find("Directional Light Night");
        GameObject playerLight = GameObject.Find("PlayerLight");

        Player.transform.position = startDark.transform.position;
        playerLight.SetActive(false);
        dirLight.SetActive(false);
        //dirLightN.SetActive(true);
        Forest.SetActive(false); //not permitted it says...
        //Destroy(Forest);
        RenderSettings.ambientLight = Color.black;

        EventManager.StopListening("DarkRoomStart", DarkRoomStart);
    }

    void DarkRoomEnd()
    {
        RenderSettings.ambientLight = setColor;
        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);
    }

    void PlayerDeath()
    {
        CameraMain.GetComponent<CameraTopDown>().enabled = false;
        StartCoroutine("DeathState");
    }

    IEnumerator DeathState()
    {
        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<Player_Health>().PleaseDie();
    }
}
