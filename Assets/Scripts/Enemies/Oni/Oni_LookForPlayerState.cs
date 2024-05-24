using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_LookForPlayerState : LookForPlayerState
{
    private Oni oni;
    public Oni_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Oni oni) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isAllTurnsDone)
        {
            stateMachine.ChangeState(oni.moveState);
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
