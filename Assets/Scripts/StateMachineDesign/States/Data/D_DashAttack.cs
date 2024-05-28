using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDashAttackStateData", menuName = "Data/State Data/Dash Attack State")]
public class D_DashAttack : ScriptableObject
{
    public float attackRadius = 0.5f, attackDamage = 10.0f, dashXSpeed = 20.0f, dashYSpeed = 0.0f;
    public LayerMask whatIsPlayer;
    public AudioClip attackSound;

}
