using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Entity
{
    public Wolf_IdleState idleState{get; private set;}
    public Wolf_MoveState moveState{get; private set;}
    public Wolf_PlayerDetectedState playerDetectedState{get; private set;}
    public Wolf_ChargeState chargeState{get; private set;}
    public Wolf_LookForPlayerState lookForPlayerState{get; private set;}
    public Wolf_DashAttackState dashAttackState{get; private set;}
    public Wolf_DeadState deadState{get; private set;}

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_DashAttack dashAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform dashAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new Wolf_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Wolf_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState  = new Wolf_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new Wolf_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new Wolf_LookForPlayerState (this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        dashAttackState = new Wolf_DashAttackState (this, stateMachine, "meleeAttack", dashAttackPosition, dashAttackStateData, this);
        deadState = new Wolf_DeadState (this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(dashAttackPosition.position, dashAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if(isDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }
}
