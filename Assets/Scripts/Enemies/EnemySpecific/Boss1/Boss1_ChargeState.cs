using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Boss1_ChargeState : ChargeState
{
    private Boss1 boss;
    private Transform player;
    public Boss1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Boss1 boss) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.boss = boss;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(boss.getCurrentHealth() < 50 && !boss.isEnraged())
        {
            stateData.chargeSpeed*=2;
            boss.setEnraged(true);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Vector2 target = new Vector2(player.position.x, boss.rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(boss.rb.position, target, stateData.chargeSpeed * Time.fixedDeltaTime);
        boss.rb.MovePosition(newPos);

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(boss.meleeAttackState);
        }
        // else if(!isDetectingLedge || isDetectingWall)
        // {
        //     stateMachine.ChangeState(boss.lookForPlayerState);
        // }
        // else if(isChargeTimeOver || !isPlayerInMinAgroRange)
        // {
        //     if(isPlayerInMinAgroRange)
        //     {
        //         stateMachine.ChangeState(boss.playerDetectedState);
        //     }
        //     else 
        //     {
        //         stateMachine.ChangeState(boss.lookForPlayerState);
        //     }
        // }
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
