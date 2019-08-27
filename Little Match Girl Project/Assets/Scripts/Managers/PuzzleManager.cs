using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.StartListening("BridgePuzzle", BridgePuzzle);
       // EventManager.StartListening("UnClampCamera", UnClampCamera);
    }

    private void OnDisable()
    {
        EventManager.StopListening("BridgePuzzle", BridgePuzzle);
       // EventManager.StopListening("UnClampCamera", UnClampCamera);
    }

    public GameObject puzzleSetBridge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BridgePuzzle()
    {
        puzzleSetBridge.SetActive(true);
    }
}
