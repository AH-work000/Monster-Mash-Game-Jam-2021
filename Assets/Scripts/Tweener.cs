using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

            if (activeTween != null)
            {
                timer += Time.deltaTime;
            
                float dist = Vector3.Distance(activeTween.EndPos, activeTween.Target.position);

                float ratio = timer / activeTween.Duration;

                if (dist > 0.1f)
                {
                    activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, ratio);
                }
                else if (dist <= 0.1f)
                {
                    activeTween.Target.position = activeTween.EndPos;
                    activeTween = null;
                    timer = 0;
                }
            }

    }
    
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            
        }
    }
}
