using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_MoveState : MoveState
{
    private Wolf wolf;
    public Wolf_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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
        
        if(isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(wolf.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            wolf.idleState.setFlipAfterIdle(true);
            stateMachine.ChangeState(wolf.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
