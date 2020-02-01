using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundedState
{

    public override PlayerState HandleInput(PlayerController p)
    {
        //Do nothing
        //Pass to GroundedState
        if (Mathf.Abs(p.iHorz) > 0)
        {
            return new WalkingState();
        }
        else
        {
            return base.HandleInput(p);
        }
    }

    public override PlayerState Update(PlayerController p)
    {
        Debug.Log("IdleState");

        if (Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
        {
            p.body.AddForce(new Vector2(Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
        }
        else
        {
            p.Stop();
        }
        return base.Update(p);
    }

    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("idle", true);
    }
}
