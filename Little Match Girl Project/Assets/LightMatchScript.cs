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
    public int matchCount = 1;
    public bool isLit;
    public float maxMatchTime = 30f;

    private void Update() 
    {
        if (!isLit && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("LightMatch");
            print("Space");
        }
    }

    IEnumerator LightMatch()
    {
        
        isLit = true;
        match.SetActive(true);

        yield return new WaitForSeconds(maxMatchTime);

        isLit = false;
        match.SetActive(false);

        print("Test");
    }


}//End
