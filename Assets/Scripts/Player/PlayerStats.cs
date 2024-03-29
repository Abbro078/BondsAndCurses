using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject deathCunckParticle, deathBloodParticle;

    private float currentHealth;

    private GameManager GM;

    private void Start() 
    {
        currentHealth =  maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();    
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
        Destroy(gameObject);
    }
}