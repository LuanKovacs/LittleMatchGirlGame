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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            partFire.SetActive(true);
        }
    }
}//End
