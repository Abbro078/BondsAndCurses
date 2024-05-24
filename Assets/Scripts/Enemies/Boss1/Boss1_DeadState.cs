using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_DeadState : DeadState
{
    private Boss1 boss;
    public Boss1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Boss1 boss) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.boss = boss;
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
