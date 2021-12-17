using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private float lerpTime = 0.3f;
    private Animator anim;
    private GameObject hero;

    private Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        tweener = GetComponent<Tweener>();
        anim = hero.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || 
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("hero_run");

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("hero_jump");
            JumpUp();
        }
        else
        {
            anim.SetTrigger("hero_idle");
        }
    }

    private void JumpUp()
    {
            Vector3 newPos = hero.transform.position;
            newPos.y += 1.0f;
            if (tweener != null)
            {
                tweener.AddTween(hero.transform, hero.transform.position, newPos, lerpTime);
            }
    }
}
