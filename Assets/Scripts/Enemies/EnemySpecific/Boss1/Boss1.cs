using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Entity
{
    public Boss1_IdleState idleState{get; private set;}
    public Boss1_ChargeState chargeState{get; private set;}
    public Boss1_MeleeAttackState meleeAttackState{get; private set;}
    public Boss1_DeadState deadState{get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    private bool enragedSpeed = false, enragedAttack = false;
    public float originalSpeed, originalAttack;

    public override void Start()
    {
        base.Start();

        idleState = new Boss1_IdleState(this, stateMachine, "idle", idleStateData, this);
        chargeState = new Boss1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        meleeAttackState = new Boss1_MeleeAttackState (this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new Boss1_DeadState (this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(chargeState);

        chargeStateData.chargeSpeed = 4.5f;
        meleeAttackStateData.attackDamage = 10f;

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if(isDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public bool isEnragedSpeed()
    {
        return enragedSpeed;
    }
    public bool isEnragedAttack()
    {
        return enragedAttack;
    }

    public void setEnragedSpeed(bool enraged)
    {
        this.enragedSpeed = enraged;
    }
    public void setEnragedAttack(bool enraged)
    {
        this.enragedAttack = enraged;
    }
}
