using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_ChargeState : ChargeState
{
    private Wolf wolf;
    public Wolf_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(wolf.lookForPlayerState);
        }
        else if(isChargeTimeOver || !isPlayerInMinAgroRange)
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
}
