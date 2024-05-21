using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_DashAttackState : DashAttackState
{
    private Wolf wolf;
    public Wolf_DashAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_DashAttack stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.wolf = wolf;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(wolf.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(wolf.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

}
