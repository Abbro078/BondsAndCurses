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
    
    public HealthBar healthBar; 
    public ManaBar manaBar;

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
        Destroy(gameObject);

        //after 3 seconds 
        // GM.RestartScene();
        // StartCoroutine(RestartSceneAfterDelay(3f));
        
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }


    private IEnumerator RestartSceneAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the RestartScene method from the GameManager
        GM.RestartScene();
    }
}
