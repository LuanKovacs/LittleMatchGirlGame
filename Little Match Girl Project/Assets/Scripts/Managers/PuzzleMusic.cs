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
    public GameObject playerLight;
    public GameObject dirLight;
    int curGoal;
    bool PuzzleComplete;

    void OnEnable()
    {
        Plate1.tag = "PuzzleAnswer";
    }

    private void Awake()
    {
        playerLight = GameObject.Find("PlayerLight");
        dirLight = GameObject.Find("Directional Light");
    }
    // Start is called before the first frame update
    void Start()
    {

        playerLight.SetActive(false);
        dirLight.SetActive(false);

        mainCamera.CanLook(false);
        Plate1.tag = "PuzzleAnswer";
    }

    // Update is called once per frame
    void Update()
    {
        if (curGoal == 1)
        {
            Debug.Log("tag");
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
            playerLight.SetActive(true);
            dirLight.SetActive(true);
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
