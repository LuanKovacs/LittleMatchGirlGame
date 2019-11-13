using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimLightMatch : MonoBehaviour
{
    LightMatchScript matchScriptRef;

    // Start is called before the first frame update
    void Start()
    {
        matchScriptRef = GetComponentInParent<LightMatchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightMatch()
    {
        if (matchScriptRef.isLit == true)
        {
            matchScriptRef.StartCoroutine("LightMatchSeq");
        }
    }

}
