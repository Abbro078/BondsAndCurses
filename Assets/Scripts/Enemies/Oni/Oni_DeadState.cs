using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni_DeadState : DeadState
{
    private Oni oni;
    public Oni_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Oni oni) : base(entity, stateMachine, animBoolName, stateData)
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
