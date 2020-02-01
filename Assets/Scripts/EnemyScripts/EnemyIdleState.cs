using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override EnemyState HandleInput(EnemyController enemy)
    {
        //Do nothing
        //Pass to GroundedState
        enemy.CheckFlip();
        if (Mathf.Abs(enemy.iHorz) > 0)
        {
            return new EnemyWalkingState();
        }
        else
        {
            return base.HandleInput(enemy);
        }
    }

    public override EnemyState Update(EnemyController enemy)
    {
        // Debug.Log("Idle");
        // if (Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
        // {
        //     p.body.AddForce(new Vector2(Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
        // }
        // else
        // {
        //     p.Stop();
        // }
        return base.Update(enemy);
    }

    public override void StateEnter(EnemyController enemy)
    {
        enemy.Stop();
        // p.ResetStates();
        // p.anim.SetBool("idle", true);
    }
}
