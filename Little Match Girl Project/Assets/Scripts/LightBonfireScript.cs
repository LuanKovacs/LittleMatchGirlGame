/* By Ricardo Ticlao III
    Light bonfire script
    14/05/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBonfireScript : MonoBehaviour
{

    public GameObject partFire;
    WinLoseScript wlref;
    bool lit;
    // Start is called before the first frame update
    void Start()
    {
        wlref = GameObject.Find("winTrigger").GetComponent<WinLoseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player" && !lit)
        {
            lit = true;
            partFire.SetActive(true);
            wlref.litBonfires += 1;
        }
    }
}//End
