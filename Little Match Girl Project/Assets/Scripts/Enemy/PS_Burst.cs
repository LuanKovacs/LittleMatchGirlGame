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

          Debug.Log("The Crow has Landed!");
            particleFX.SetActive(true);
    }
}
