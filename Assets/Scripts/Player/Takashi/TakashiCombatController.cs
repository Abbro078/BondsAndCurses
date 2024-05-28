using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakashiCombatController : MonoBehaviour
{


    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;

    private float lastInputTime;

    private Animator anim;

    private TakashiController PC;

    private TakashiStats PS;

    private AttackDetails attackDetails;

    [SerializeField]
    private bool combatEnabled = true;

    [SerializeField]
    private float inputTimer;

    [SerializeField]
    private float attack1Radius;

    [SerializeField]
    private float attack1Damage;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private LayerMask WhatIsDamageable;   

    [SerializeField]
    private AudioClip swingSound;

    


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
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack); 
                anim.SetBool("isAttacking", isAttacking);
                AudioSource.PlayClipAtPoint(swingSound, transform.position, 0.5f);
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

        foreach(Collider2D collider in detectedObjects)
        {
            if(collider.transform.parent != null)
            {
                if (collider.transform.parent.CompareTag("Enemy"))
                {
                    collider.transform.parent.SendMessage("Damage", attackDetails);
                }            
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

            PS.updateHealth();
            PC.Knockback(direction);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
