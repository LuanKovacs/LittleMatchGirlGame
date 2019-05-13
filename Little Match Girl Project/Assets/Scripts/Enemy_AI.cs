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
    public float atkDamage;
    public GameObject hurtBox;
//    public Transform head;
    public float turnSpeed = 3f;

    public bool chasePlayer;
    public bool atkPlayer;
    public float atkDelay = 1f;
    float distance;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
       
        curEnemyHP = maxEnemyHP;
    }

    void SightDetection()
    {

    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance <= 3f && !atkPlayer)
        {
            print("testAtk");
            StartCoroutine("Attack");
        } else {}
    }

    IEnumerator Attack()
    {

        atkPlayer = true;
        hurtBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        hurtBox.SetActive(false);
        yield return new WaitForSeconds(atkDelay);     
        atkPlayer = false;
        yield break;
        
    }


/*    void LookAt()
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
*/

}//End
