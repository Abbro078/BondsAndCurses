using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni : Entity
{
    public Oni_IdleState idleState{get; private set;}
    public Oni_MoveState moveState{get; private set;}
    public Oni_PlayerDetectedState playerDetectedState{get; private set;}
    public Oni_ChargeState chargeState{get; private set;}
    public Oni_LookForPlayerState lookForPlayerState{get; private set;}
    public Oni_MeleeAttackState meleeAttackState{get; private set;}
    public Oni_DeadState deadState{get; private set;}

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
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new Oni_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Oni_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState  = new Oni_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new Oni_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new Oni_LookForPlayerState (this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new Oni_MeleeAttackState (this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new Oni_DeadState (this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);

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
}