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
            enemy.body.AddForce(enemy.transform.right * Mathf.Sign(enemy.iHorz) * enemy.ACCELX);
            if (Mathf.Abs(enemy.body.velocity.x) > enemy.MAXSPEEDX)
            {
                enemy.body.velocity = new Vector2(enemy.MAXSPEEDX * Mathf.Sign(enemy.body.velocity.x), enemy.body.velocity.y);
            }
        }
        else
        {
            if (Mathf.Abs(enemy.body.velocity.x) <= enemy.SLOWDOWNTHRES && Mathf.Abs(enemy.body.velocity.x) > enemy.STOPTHRESH)
            {
                enemy.body.AddForce(new Vector2(Mathf.Sign(enemy.body.velocity.x), 0) * -enemy.ACCELSLOWDOWN);
            }
            else
            {
                enemy.Stop();
            }
        }
        enemy.anim.SetFloat("speed", Mathf.Sign(enemy.body.velocity.x));
        return null;
        // return base.Update(enemy);

    }
    public override void StateEnter(EnemyController enemy)
    {
        enemy.ResetStates();
        //enemy.anim.SetBool("walking", true);
    }
}