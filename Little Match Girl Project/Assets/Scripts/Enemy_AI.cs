/* By: Ricardo III Ticlao
 * Enemy Behaviour
 * 09/04/2019
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    public GameObject target;
    public float maxEnemyHP;
    public float curEnemyHP;
    public float atkDmanage;
    public GameObject hurtBox;
    public Transform head;
    public float turnSpeed = 3f;

    public bool chasePlayer;
    public bool atkPlayer;
    float distance;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
       
        curEnemyHP = maxEnemyHP;
    }

    void SightDetection()
    {

    }

    public void Attack()
    {
        
    }

    void LookAt()
    {
        Quaternion wantedRotation = Quaternion.LookRotation(target.transform.position - head.position);
        Quaternion lerpedRotation = Quaternion.Lerp(head.rotation, wantedRotation, turnSpeed * Time.deltaTime);

        float x = lerpedRotation.eulerAngles.x;

        if (x > 0f && x < 270f)
        {
            x = 0f;
        }
        else if (x > 270f && x < 360f)
        {
            x = Mathf.Clamp(x, 270, 360);
        }

        head.rotation = Quaternion.Euler(0, lerpedRotation.eulerAngles.y, 0);
    }

}//End
