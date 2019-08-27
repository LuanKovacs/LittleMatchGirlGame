using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.StartListening("BridgePuzzle", BridgePuzzle);
        EventManager.StartListening("UnlockMatches", UnlockMatches);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
        EventManager.StopListening("UnlockMatches", UnlockMatches);
    }

    public GameObject Player;
    public GameObject puzzleSetBridge;
    
    void UnlockMatches()
    {
        LightMatchScript lightMatch = Player.GetComponent<LightMatchScript>();
        lightMatch.enabled = true;
    }

    void BridgePuzzle()
    {
        puzzleSetBridge.SetActive(true);
    }
}
