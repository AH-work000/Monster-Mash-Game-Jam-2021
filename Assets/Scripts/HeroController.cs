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
    private bool flag = false;
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag3 = false;
    private bool flag4 = false;
    private bool flag5 = false;
    
    
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
        if (Keyboard.current.aKey.isPressed || Keyboard.current.sKey.isPressed || 
            Keyboard.current.wKey.isPressed || Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed
            || Keyboard.current.leftArrowKey.isPressed)
        {
            if (!flag1)
            {
                anim.SetTrigger("hero_run");
                flag = false;
                flag1 = true;
                flag2 = false;
                flag3 = false;
                flag4 = false;
                flag5 = false;
            }
        }
        else if (Keyboard.current.spaceKey.isPressed)
        {
            if (!flag2)
            {
                anim.SetTrigger("hero_jump");
                JumpUp();
                flag = false;
                flag1 = false;
                flag2 = true;
                flag3 = false;
                flag4 = false;
                flag5 = false;
            }
        }
        else if (Keyboard.current.lKey.isPressed)
        {
            anim.SetTrigger("hero_slide");
            flag = false;
            flag1 = false;
            flag2 = false;
            flag3 = false;
            flag4 = true;
            flag5 = false;
        }
        else if (Keyboard.current.mKey.isPressed)
        {
            anim.SetTrigger("hero_death");
            flag = false;
            flag1 = false;
            flag2 = false;
            flag3 = false;
            flag4 = false;
            flag5 = true;
        }
        else if (Keyboard.current.kKey.isPressed)
        {
            if (!flag3)
            {
                anim.SetTrigger("hero_air_attack");
                flag = false;
                flag1 = false;
                flag2 = false;
                flag3 = true;
                flag4 = false;
                flag5 = false;
            }
        }
        else
        {
            if (!flag)
            {
                anim.SetTrigger("hero_idle");
                flag = true;
                flag1 = false;
                flag2 = false;
                flag3 = false;
                flag4 = false;
                flag5 = false;
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
