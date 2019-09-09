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
    public GameObject Monster;
    public GameObject puzzleSetBridge;

    Color32 setColor = new Color32(51,66,91, 0);

    void UnlockMatches()
    {
        LightMatchScript lightMatch = Player.GetComponent<LightMatchScript>();
        lightMatch.enabled = true;
        EventManager.StopListening("UnlockMatches", UnlockMatches);
    }

    void BridgePuzzle()
    {
        puzzleSetBridge.SetActive(true);
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
    }
    
    void BeginChase()
    {
        Monster.SetActive(true);
    }

    void EndChase()
    {
        Monster.SetActive(false);
    }

    void DarkRoomStart()
    {
        GameObject Forest = GameObject.Find("Terrain_Forest");
        GameObject startDark = GameObject.Find("DarkroomCheckPoint");
        GameObject dirLight = GameObject.Find("Directional Light Night");

        Player.transform.position = startDark.transform.position;
        dirLight.SetActive(false);
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
