using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public GameObject target;
    public float damage = 30;
    public float knockbackForce = 500f;

    Enemy_AI enemyRef;
    Player_Health playerHPref;
    Player_Movement playerMoveRef;
    Rigidbody playerRBref;
    Vector3 knockbackDir;

    private void Awake() 
    {
        enemyRef = GetComponentInParent<Enemy_AI>();
        playerHPref = target.GetComponentInParent<Player_Health>();
        playerRBref = target.GetComponentInParent<Rigidbody>();
        playerMoveRef = target.GetComponent<Player_Movement>();

    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
             print("testTrigger");
              SendDamage();
        }
        else { }
    }

    void SendDamage()
    {
        knockbackDir = target.transform.position - transform.position;

        print("test");

        playerHPref.DamageHP(damage);
        
        playerRBref.AddForce(knockbackDir.normalized * knockbackForce);
        gameObject.SetActive(false);

    }


}
