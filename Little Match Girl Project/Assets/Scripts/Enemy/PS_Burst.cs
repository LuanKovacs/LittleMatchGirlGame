using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Burst : MonoBehaviour
{
    public GameObject particleFX;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)//***Tianna!!***
    {
        GameObject targetPos = GameObject.Find("MonsterTargetPos");
        GameObject enemRig = GameObject.Find("enemyrig 1");
        GameObject monFog = GameObject.Find("MontersFogHurtBox");
        GameObject psFog = GameObject.Find("PS_Fog");

        Debug.Log("The Crow has Landed!");
              particleFX.SetActive(true);

              targetPos.SetActive(false);
              enemRig.SetActive(false);
              monFog.SetActive(false);
              psFog.SetActive(false);

    }
}
