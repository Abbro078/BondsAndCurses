using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_DeadState : DeadState
{
    private Wolf wolf;
    public Wolf_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Wolf wolf) : base(entity, stateMachine, animBoolName, stateData)
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
