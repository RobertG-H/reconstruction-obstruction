using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AerialState
{
    public override PlayerState HandleInput(PlayerController p)
    {
        //Do nothing
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        Debug.Log("Falling");
        if (p.RayCastGround())
        {
            if (Mathf.Abs(p.iHorz) > 0)
            {
                return new WalkingState();
            }
            else
            {
                return new IdleState();
            }
        }

        return base.Update(p);
    }

    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("falling", true);
    }
}
