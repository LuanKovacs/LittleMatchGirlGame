using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMusic : MonoBehaviour
{
    public GameObject Plate1;
    public GameObject Plate2;
    public GameObject Plate3;
    public int goal = 3;
    public GameObject Bridge;

    public CameraTopDown mainCamera;
    public GameObject direcLight;
    int curGoal;
    bool PuzzleComplete;

    void OnEnable()
    {
        Plate1.tag = "PuzzleAnswer";
    }
    // Start is called before the first frame update
    void Start()
    {
        direcLight.SetActive(false);
        mainCamera.CanLook(false);
        Plate1.tag = "PuzzleAnswer";
    }

    // Update is called once per frame
    void Update()
    {
        if (curGoal == 1)
        {
            Plate2.tag = "PuzzleAnswer";
        }

        if (curGoal == 2)
        {
            Plate3.tag = "PuzzleAnswer";
        }

        if (curGoal == goal && !PuzzleComplete)
        {      
            ResetGoal();
            mainCamera.CanLook(true);
            direcLight.SetActive(true);
            Bridge.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void AddGoal()
    {
        print("AddGoal");
        curGoal++;
    }

    public void ResetGoal()
    {
        PuzzleComplete = false;
        if (curGoal > 0)
        {
            Plate1.tag = "PuzzleAnswer";
            print("RestGoal");
            curGoal = 0;
        }
    }
}
