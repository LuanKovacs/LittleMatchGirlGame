using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        int Randomize = Random.Range(1, 3);

        anim.SetInteger("Randomize", Randomize);
    }
}
