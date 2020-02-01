using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialState : MovingState
{
    // Start is called before the first frame update
    public override PlayerState HandleInput(PlayerController p)
    {
        // return base.HandleInput(p);
        return null;
    }

    public override PlayerState Update(PlayerController p)
    {
        base.Update(p);
        if (p.body.velocity.y < 0)
        {
            return new FallingState();
        }
        else if (p.body.velocity.y >= 0)
        {
            return new UpwardsAerialState();
        }
        return null;
    }

    public override string GetBaseStateID()
    {
        return "AerialState";
    }

}
