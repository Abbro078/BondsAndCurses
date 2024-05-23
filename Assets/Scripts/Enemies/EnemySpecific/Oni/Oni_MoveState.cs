using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_MoveState : MoveState
{
    private Oni oni;
    public Oni_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Oni oni) : base(entity, stateMachine, animBoolName, stateData)
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
        
        if(isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(oni.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            oni.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(oni.idleState);
        }
        else if(entity.isDamaged == true)
        {
            stateMachine.ChangeState(oni.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
