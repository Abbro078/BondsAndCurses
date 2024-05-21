using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_ChargeState : ChargeState
{
    private Oni oni;
    public Oni_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Oni oni) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(oni.lookForPlayerState);
        }
        else if(isChargeTimeOver || !isPlayerInMinAgroRange)
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
}
