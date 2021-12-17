using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    private float lerpTime = 0.3f;
    private Animator anim;
    private GameObject hero;
    private bool flag = true;
    
    private Vector2 velocity;
    private Vector2 movement;
    
    public float walkSpeed = 1000.0f;

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
        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || 
            Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            anim.SetTrigger("hero_run");
            flag = true;
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            anim.SetTrigger("hero_jump");
            JumpUp();
            flag = true;
        }
        else
        {
            if (flag)
            {
                anim.SetTrigger("hero_idle");
                flag = false;
            }
        }
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        hero.transform.Translate(movement* walkSpeed * Time.deltaTime*5.0f, Space.World);
    }

    private void JumpUp()
    {
            Vector3 newPos = hero.transform.position;
            newPos.y += 5.0f;
            if (tweener != null)
            {
                tweener.AddTween(hero.transform, hero.transform.position, newPos, lerpTime);
            }
    }
}
