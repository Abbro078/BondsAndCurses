using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_PlayerDetectedState : PlayerDetectedState
{
    protected Oni oni;
    public Oni_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Oni oni) : base(entity, stateMachine, animBoolName, stateData)
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

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(oni.meleeAttackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(oni.chargeState);
        }
        else if(!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(oni.lookForPlayerState);
        }
        else if(!isDetectingLedge)
        {
            entity.Flip();
            stateMachine.ChangeState(oni.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
