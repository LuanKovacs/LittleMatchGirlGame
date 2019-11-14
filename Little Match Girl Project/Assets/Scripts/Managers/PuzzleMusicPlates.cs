using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMusicPlates : MonoBehaviour
{
    PuzzleMusic puzzleManager;
    public string Switch;

    private void Awake()
    {
        puzzleManager = GetComponentInParent<PuzzleMusic>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "PuzzleAnswer")
            {
                gameObject.tag = "Untagged";
                puzzleManager.AddGoal();
                AkSoundEngine.SetSwitch("Puzzle_game", Switch, gameObject);
            }
            else        
            {
                puzzleManager.ResetGoal();
            }
        }
    }

}
