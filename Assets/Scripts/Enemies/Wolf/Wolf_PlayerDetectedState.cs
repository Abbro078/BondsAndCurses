using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_PlayerDetectedState : PlayerDetectedState
{
    protected Wolf wolf;
    public Wolf_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(wolf.dashAttackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(wolf.chargeState);
        }
        else if(!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(wolf.lookForPlayerState);
        }
        else if(!isDetectingLedge)
        {
            entity.Flip();
            stateMachine.ChangeState(wolf.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
