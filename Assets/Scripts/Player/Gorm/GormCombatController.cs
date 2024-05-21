using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GormCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;
    public bool secondAttack = false;

    private float lastInputTime, lastAttack2 = Mathf.NegativeInfinity;
    private AttackDetails attackDetails;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage, attack2Radius, attack2Damage, stunDamageAmount, attack2Cooldown = 1.0f;
    [SerializeField]
    private Transform attack1HitBoxPos, attack2HitBoxPos;
    [SerializeField]
    private LayerMask WhatIsDamageable;   

    private Animator anim;

    private GormController PC;

    private PlayerStats PS;


    private void Start()
    {
        isFirstAttack = true;
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<GormController>();  
        PS = GetComponent<PlayerStats>();
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
        if (PlayerPrefs.GetInt("HasAbility", 0) == 1)
        {
            secondAttack=true;
        }
        if(secondAttack)
        {
            if(!isAttacking)
            {
                lastAttack2 = Time.time;
                Debug.Log("hoooaaaaa");
                isAttacking = true;
                //isFirstAttack = !isFirstAttack;                          //TODO: this was commented because we only have one attack for now
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

            PS.healthBar.SetHealth(PS.getCurrentHealth());
            PC.Knockback(direction);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);    
        Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);    

    }
}
