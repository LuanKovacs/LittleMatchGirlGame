﻿/* Third Person Camera Script
 * Ricardo III Ticlao
 * 04/06/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ThirdPerson : MonoBehaviour
{

    public Transform player;
//    public Transform target;
    
    public bool canFollow = true;
    public bool canLockOn;
    public float smoothMove = 5f;
    public float smoothLook = 5f;
  
    Vector3 cameraOffsetFromTarget;
    Quaternion newRot;
    Vector3 relPos;

    // Use this for initialization
    void Start()
    { //Built in function which is run once when the script is enabled or before any Update function
        if (canFollow == true)
        {
            cameraOffsetFromTarget = transform.position - player.position;
        }
    }

    public void CanLook(bool PlayerDied)
    {
        canFollow = PlayerDied;
    }

    void LateUpdate()
    { //LateUpdate = end of frame, good for camera control
        if (canFollow == true)
        {
            Vector3 targetCamPos = player.position + cameraOffsetFromTarget;
            transform.position = targetCamPos;
            //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothMove * Time.deltaTime);
            //Smooth follow target
            //Lerp = smoothing movement or move in percentages each time

            Quaternion wantedRotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.time * smoothLook);
            //Smooth look at 
        }
    }

    /*    private void Update()
        {
            if (canLockOn == true && target == null)
            {
                GetNewTarget();
            } 
            else
            {
                relPos = target.position - transform.position;
                newRot = Quaternion.LookRotation(relPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.time * smoothLook);
            }

        }

        void GetNewTarget()
        {

            GameObject[] possibleTargets;
            possibleTargets = GameObject.FindGameObjectsWithTag("Enemy");


            if (possibleTargets.Length > 0)
            {
                Vector3 closestTarget = possibleTargets[0].transform.position;
                float closestDistance = (possibleTargets[0].transform.position - player.position).sqrMagnitude;
                for (int i = 0; i < possibleTargets.Length; i++)
                {
                    Vector3 offset = possibleTargets[i].transform.position - player.position;
                    float sqrLen = offset.sqrMagnitude;
                    if (sqrLen < closestDistance)
                        closestTarget = possibleTargets[i].transform.position;
                        closestDistance = sqrLen;

                        target = possibleTargets[i].transform;
                    }
                }
            }
    */
}//End
