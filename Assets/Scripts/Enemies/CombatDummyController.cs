using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackSpeedX, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathToeque;
    private float currentHealth, knockbackStart;

    [SerializeField]
    private GameObject hitParticle;
    [SerializeField]
    private bool applyKnockback, knockback;

    private PlayerController pc;
    private GameObject aliveGO, brokenTopGO, brokenBotGO;
    private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
    private Animator aliveAnim;

    private int playerFacingDirection;
    private bool playerOnLeft;

    private void Start() 
    {
        currentHealth = maxHealth;

        //pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGO = transform.Find("Alive").gameObject;
        brokenTopGO = transform.Find("Broken Top").gameObject;
        brokenBotGO = transform.Find("Broken Bottom").gameObject;
        
        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        rbBrokenBot = brokenBotGO.GetComponent<Rigidbody2D>();
        rbBrokenTop = brokenTopGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
        brokenBotGO.SetActive(false);
        brokenTopGO.SetActive(false);
    }

    private void Update() 
    {
        CheckKnockback();    
    }

    private void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
        //playerFacingDirection = pc.GetFacingDirection();

        if(attackDetails.position.x > aliveGO.transform.position.x)
        {
            playerFacingDirection = -1;
        }
        else
        {
            playerFacingDirection = 1;
        }


        Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        if(playerFacingDirection == 1)
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }
        
        aliveAnim.SetBool("playerOnLeft", playerOnLeft);
        aliveAnim.SetTrigger("damage");
        
        if(applyKnockback && currentHealth > 0.0f)
        {
            Knockback();
        }

        if(currentHealth <= 0.0f)
        {
            Die();
        }   
    }

    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
    }

    private void CheckKnockback()
    {
        if(Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }

    private void Die()
    {
        aliveGO.SetActive(false);
        brokenBotGO.SetActive(true);
        brokenTopGO.SetActive(true);

        brokenTopGO.transform.position = aliveGO.transform.position;
        brokenBotGO.transform.position = aliveGO.transform.position;

        rbBrokenBot.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
        rbBrokenTop.velocity = new Vector2(knockbackDeathSpeedX * playerFacingDirection, knockbackDeathSpeedY);
        rbBrokenTop.AddTorque(deathToeque * -playerFacingDirection, ForceMode2D.Impulse);
    }
}
