using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMusicPlates : MonoBehaviour
{
    PuzzleMusic puzzleManager;

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
        if (gameObject.tag == "PuzzleAnswer" && other.tag == "Player")
        {
            gameObject.tag = "Untagged";
            puzzleManager.AddGoal();
        }
        else
        {
            puzzleManager.ResetGoal();
        }
    }

}
