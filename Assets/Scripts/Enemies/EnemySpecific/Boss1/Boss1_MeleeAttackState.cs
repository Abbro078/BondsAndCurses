using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_MeleeAttackState : MeleeAttackState
{
    private Boss1 boss;
    public Boss1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Boss1 boss) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

        if(boss.getCurrentHealth() <= 50 && !boss.isEnragedAttack())
        {
            stateData.attackDamage*=2;
            boss.setEnragedAttack(true);
        }
        if(isAnimationFinished)
        {
            stateMachine.ChangeState(boss.chargeState);
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
