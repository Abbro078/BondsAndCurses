using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f, ledgeCheckDistance = 0.4f, maxAgroDistance = 4.0f, minAgroDistance = 3.0f, closeRangeActionDistance = 1.0f,
        maxHealth = 30.0f, damageHopSpeed = 3.0f, grounCheckRadius = 0.3f, stunResistance = 3.0f, strunRecoveryTime = 2.0f;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject hitParticle;
}
