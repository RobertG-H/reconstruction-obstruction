using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingState : EnemyState
{
    private float currHorz;
    public override EnemyState HandleInput(EnemyController enemy)
    {
        // enemy.CheckFlip();
        if (enemy.iHorz == 0)
        {
            return new EnemyIdleState();
        }
        return null;
    }

    public override EnemyState Update(EnemyController enemy)
    {
        if (enemy.RayCastDirection())
        {
            return new EnemyIdleState();
        }

        if (Mathf.Abs(enemy.iHorz) > 0)
        {

            enemy.body.velocity = new Vector2(enemy.MAXSPEEDX * enemy.iHorz, 0);

        }
        else
        {
            enemy.Stop();
        }
        // enemy.anim.SetFloat("speed", Mathf.Sign(enemy.body.velocity.x));
        return null;
        // return base.Update(enemy);

    }
    public override void StateEnter(EnemyController enemy)
    {
        enemy.ResetStates();
        enemy.anim.SetBool("walking", true);
    }
}