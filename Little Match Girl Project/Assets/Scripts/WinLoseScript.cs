/* By Ricardo Ticlao III
    Win/lose condition
    14/05/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScript : MonoBehaviour
{

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject Doors;

    public int litBonfires = 0;
    bool exitOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (litBonfires == 4 && !exitOpen)
        {
            Doors.SetActive(false);
            exitOpen = true;
         //   gameObject.GetComponnet<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            winPanel.SetActive(true);
          //  other.gameObject.GetComponnet<Player_Movement>().enabled = false;
        }
    }


}//End
