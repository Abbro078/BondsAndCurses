using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_MeleeAttackState : MeleeAttackState
{
    private Oni oni;
    public Oni_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Oni oni) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.oni = oni;
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
                stateMachine.ChangeState(oni.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(oni.lookForPlayerState);
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
