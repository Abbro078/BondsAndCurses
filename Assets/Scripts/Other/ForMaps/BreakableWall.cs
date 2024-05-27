using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject wallBreakParticle;

    private void Damage2(AttackDetails attackDetails)
    {
        Break();
    }
    
    private void Break()
    {
        Vector3 particlePosition = new Vector3 (-38f, -4.5f, 0);
        Instantiate(wallBreakParticle, particlePosition, wallBreakParticle.transform.rotation);
        Destroy(gameObject);
    }

}
