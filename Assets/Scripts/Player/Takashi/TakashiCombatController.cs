using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakashiCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;

    private float lastInputTime;
    private AttackDetails attackDetails;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage; //, stunDamageAmount;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask WhatIsDamageable;   

    private Animator anim;

    private TakashiController PC;

    private TakashiStats PS;


    private void Start()
    {
        isFirstAttack = true;
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<TakashiController>();  
        PS = GetComponent<TakashiStats>();
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
    }



    private void CheckAttacks()
    {
        if(gotInput)
        {
            if(!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                //isFirstAttack = !isFirstAttack;                          //TODO: this was commented because we only have one attack for now
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
        //attackDetails.stunDamageAmount = stunDamageAmount;

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

            PS.healthBar.SetHealth(PS.getCurrentHealth());
            PC.Knockback(direction);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);    
        //Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);    

    }
}
