using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.StartListening("BridgePuzzle", BridgePuzzle);
        EventManager.StartListening("UnlockMatches", UnlockMatches);

        EventManager.StartListening("DarkRoomStart", DarkRoomStart);
        EventManager.StartListening("DarkRoomEnd", DarkRoomEnd);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
        EventManager.StopListening("UnlockMatches", UnlockMatches);

        EventManager.StopListening("DarkRoomStart", DarkRoomStart);
        EventManager.StopListening("DarkRoomEnd", DarkRoomEnd);
    }

    public GameObject Player;
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
}
