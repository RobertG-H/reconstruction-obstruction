using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : GroundedState
{

    private float currHorz;
    public override PlayerState HandleInput(PlayerController p)
    {
        // p.CheckFlip(p.iHorz);
        //currHorz = p.iHorz;
        //Pass to GroundedState
        if (p.iHorz == 0)
        {
            return new IdleState();
        }
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        Debug.Log("walkingstate");
        return base.Update(p);
        // p.anim.SetFloat("walkingSpeed", p.body.velocity.x/p.MAXSPEEDX);
    }
    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("walking", true);
    }
}
