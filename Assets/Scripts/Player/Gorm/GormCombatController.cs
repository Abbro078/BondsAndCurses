using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GormCombatController : MonoBehaviour
{
    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;
    private float lastInputTime; 
    private float lastAttack2 = Mathf.NegativeInfinity;
    private AttackDetails attackDetails;
    private Animator anim;
    private GormController PC;
    private GormStats PS;

    [SerializeField]
    private bool combatEnabled = true;

    [SerializeField]
    private bool secondAttack = false;

    [SerializeField]
    private float inputTimer;

    [SerializeField]
    private float attack1Radius;

    [SerializeField]
    private float attack1Damage;

    [SerializeField]
    private float attack2Radius;

    [SerializeField]
    private float attack2Damage;

    [SerializeField]
    private float stunDamageAmount;

    [SerializeField]
    private float attack2Cooldown = 1.0f;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private Transform attack2HitBoxPos;

    [SerializeField]
    private LayerMask WhatIsDamageable;
    private static string logFilePath = "game_log.txt";

    

    private void Start()
    {
        isFirstAttack = true;
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<GormController>();  
        PS = GetComponent<GormStats>();
    }
    private void Update() 
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(combatEnabled)
            {
                Debug.Log("hyaaaaa");
                gotInput = true;
                lastInputTime = Time.time;
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            if(Time.time >= (attack2Cooldown + lastAttack2))
            {
                Attack2();
            }
        }
    }

    private void Attack2()
    {
        if(isSecondAttackAvailable())
        {
            if(!isAttacking)
            {
                lastAttack2 = Time.time;
                Debug.Log("hoooaaaaa");
                isAttacking = true;
                anim.SetBool("attack2", true);
                anim.SetBool("isAttacking", isAttacking);
            }
        }
    }



    private void CheckAttacks()
    {
        if(gotInput)
        {
            if(!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack); 
                anim.SetBool("isAttacking", isAttacking);
            }
        }
        if(Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, WhatIsDamageable);

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach(Collider2D collider in detectedObjects)
        {
            if (collider.transform.parent.CompareTag("Enemy"))
            {
                collider.transform.parent.SendMessage("Damage", attackDetails);
            }        
        }

    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }




    private void CheckAttack2HitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack2HitBoxPos.position, attack2Radius, WhatIsDamageable);

        attackDetails.damageAmount = attack2Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach(Collider2D collider in detectedObjects)
        {
            if(collider.transform.parent != null)
            {
                if (collider.transform.parent.CompareTag("Enemy"))
                {
                    collider.transform.parent.SendMessage("Damage", attackDetails);
                }
                else if (collider.transform.parent.CompareTag("BreakableWall"))
                {
                    collider.transform.parent.SendMessage("Damage2", attackDetails);
                }
            }
        }

    }

    private void FinishAttack2()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack2", false);
    }

    private void Damage(AttackDetails attackDetails)
    {
        if(!PC.GetDashStatus())
        {
            int direction;
            
            PS.DecreaseHealth(attackDetails.damageAmount);

            if(attackDetails.position.x < transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            PS.updateHealth();
            PC.Knockback(direction);    
        }
    }

    private bool isSecondAttackAvailable()
    {
        if (PlayerPrefs.GetInt("HasAbility", 0) == 1)
        {
            secondAttack=true;
            return true;
        }
        else 
        {
            secondAttack=false;
            return false;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);    
        Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);    

    }

}
