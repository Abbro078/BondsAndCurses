using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_LookForPlayerState : LookForPlayerState
{
    private Wolf wolf;
    public Wolf_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isAllTurnsDone)
        {
            stateMachine.ChangeState(wolf.moveState);
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
