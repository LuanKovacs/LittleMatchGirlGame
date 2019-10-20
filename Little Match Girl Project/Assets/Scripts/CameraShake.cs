using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float time;

    public bool shakeCamera;
    [Range(0f, 1f)]
    public float duration;
    [Range(0f, 1f)]
    public float magnitude;
    
   // public Animator enemyAnimator;

    public IEnumerator Shake(float duration, float magnitude)
    {
        

        //if(enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Roar"))
       // { 
            Vector3 originalPos = transform.localPosition;

            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
       // }
    }
}
