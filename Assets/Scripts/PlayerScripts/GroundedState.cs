using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : MovingState
{
    public override PlayerState HandleInput(PlayerController p)
    {
        if (!p.RayCastGround())
        {
            return new FallingState();
        }
        else if (p.iJumpReleased)
        {
            return new JumpingState(p.iJumpPressDuration * p.JUMPSQUATFORCE);
        }
        return base.HandleInput(p);

    }

    public override PlayerState Update(PlayerController p)
    {
        return base.Update(p);
    }

    public override string GetBaseStateID()
    {
        return "GroundedState";
    }
}
