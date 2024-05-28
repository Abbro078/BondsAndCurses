using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBreakableWall : MonoBehaviour
{
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject wallBreakParticle;

    [SerializeField]
    private Collider2D collider2D;
    private void Start() 
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.gameObject.tag = "BreakableWall";

    }
    private void Damage2(AttackDetails attackDetails)
    {
        Debug.Log("fromCombat");
        Break();
    }

    private void Break()
    {
        Debug.Log("fromCombat");
        Vector3 particlePosition = new Vector3 (-38f, -4.5f, 0);
        Instantiate(wallBreakParticle, particlePosition, wallBreakParticle.transform.rotation);
        wall.SetActive(false);
        gameObject.SetActive(false);
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Vector3 particlePosition = new Vector3 (-38f, -4.5f, 0);
    //         Instantiate(wallBreakParticle, particlePosition, wallBreakParticle.transform.rotation);
    //         wall.SetActive(false);
    //         gameObject.SetActive(false);
    //     }
    // }
}
