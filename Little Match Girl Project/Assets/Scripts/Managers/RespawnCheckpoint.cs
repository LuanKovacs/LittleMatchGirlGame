/* By: Ricardo III Ticlao
   Respawn Player At Closest Unclocked Checkpoint
   3/10/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
    public Transform Player;
    public GameObject[] checkpoints;

    private void Awake() 
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoints");
    }

    private void Update() 
    {
        //Testing Respawn
        /* if (Input.GetKeyDown(KeyCode.T))
        {
            Respawn();
        }
        */
    }

    public void Respawn()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoints");
        StartCoroutine(StartRespawn());
    }

    IEnumerator StartRespawn()
    {
        yield return new WaitForSeconds(1);
        FindCheckpoint();
        yield break;
    }

    void FindCheckpoint()
    {
        Transform respawnTarget = null;
        Vector3 curPos = Player.position;
        float closestDistSqr = Mathf.Infinity;
        foreach (GameObject checkP in checkpoints)
        {
            if (checkP.activeSelf == true)
            { 
                print("Foreach");
                Vector3 dirToTarget = checkP.transform.position - curPos;
                float distSqrToTarget = dirToTarget.sqrMagnitude;
                if (distSqrToTarget < closestDistSqr)
                {
                    closestDistSqr = distSqrToTarget;
                    respawnTarget = checkP.transform;
                
                    Player.position = checkP.transform.position;//Teleport player
                    print("Respawn");
                }
            }
        }
    }

}//End
