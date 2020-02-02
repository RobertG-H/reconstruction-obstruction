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
        else if (p.iArcPressed)
        {
            return new ChargingState();
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
