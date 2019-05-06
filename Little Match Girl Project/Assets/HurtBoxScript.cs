using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public GameObject target;
    public float damage = 30;
    public float atkDelay = 1f;
    public float knockbackForce = 500f;

    bool canDamage;
    Enemy_AI enemyRef;
    Player_Health playerHPref;
    Rigidbody playerRBref;
    Vector3 knockbackDir;

    private void Awake() 
    {
        enemyRef = GetComponentInParent<Enemy_AI>();
        playerHPref = target.GetComponentInParent<Player_Health>();
        playerRBref = target.GetComponentInParent<Rigidbody>();
        canDamage = true;
    }

    void OnEnable()
    {
//      canDamage = true;
    }

    private void OnTriggerStay(Collider other) 
    {
        if (target && canDamage == true)
        {
            //  SendDamage();
            StartCoroutine("SendDamage");
        }
        else { }
    }

    IEnumerator SendDamage()
    {
        knockbackDir = target.transform.position - transform.position;

        if(canDamage == true)
        {
            canDamage = false;
            playerHPref.DamageHP(damage);

            playerRBref.AddForce(knockbackDir.normalized * knockbackForce);

            //gameObject.SetActive(false
            yield return new WaitForSeconds(atkDelay);
            canDamage = true;
            yield break;
        }
    }


}
