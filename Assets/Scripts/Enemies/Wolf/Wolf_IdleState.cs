using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_IdleState : IdleState
{
    private Wolf wolf;
    public Wolf_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isIdleTimeOver)
        {
            stateMachine.ChangeState(wolf.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
