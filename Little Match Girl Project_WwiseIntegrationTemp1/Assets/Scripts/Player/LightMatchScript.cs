/* By: Ricardo Ticlao III
    Player light match
    30/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMatchScript : MonoBehaviour
{
    public GameObject match;
    public int maxMatches = 3;
    public int curMatches = 0;
    public bool isLit;
    public float maxMatchTime = 30f;

    private void Update() 
    {
        if (!isLit && Input.GetKeyDown(KeyCode.Space) && curMatches >= 1)
        {
            if (curMatches > 0)
            {
                curMatches -= 1;
            }
            StartCoroutine("LightMatch");
            print("Space");
        }
    }

    IEnumerator LightMatch()
    {
        
        isLit = true;
        match.SetActive(true);
        GetComponent<Player_Health>().GainHP(true);
        yield return new WaitForSeconds(maxMatchTime);
        isLit = false;
        match.SetActive(false);
        GetComponent<Player_Health>().GainHP(false);
        print("Test");
    }

    public void GainMatch()
    {
        curMatches = maxMatches;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 20), "Matches/" + curMatches.ToString());
    }
}//End
