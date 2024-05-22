using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject wallBreakParticle;
    public float maxHealth;
    private float currentHealth;

  

    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
       
    }

    private void Damage2(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;

        if(currentHealth <= 0.0f)
        {
            Break();
        }

        
    }
    
    private void Break()
    {
        Instantiate(wallBreakParticle, transform.position, wallBreakParticle.transform.rotation);
        Destroy(gameObject);
    }
}
