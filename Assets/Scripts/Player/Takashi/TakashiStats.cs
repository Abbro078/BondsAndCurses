using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakashiStats : MonoBehaviour
{
    private float currentHealth;

    private GameManager GM;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject deathCunckParticle;
    [SerializeField]
    private GameObject deathBloodParticle;

    [SerializeField]
    private HealthBar healthBar;
    
    [SerializeField]
    private ManaBar manaBar; 

    [SerializeField]
    private AudioClip deathSound;
    
    private void Start() 
    {
        currentHealth =  maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthBar.SetMaxHealth(maxHealth);    
        manaBar.SetMaxMana(50);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathCunckParticle, transform.position, deathCunckParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public void updateHealth()
    {
        healthBar.SetHealth(currentHealth);
    }
}
