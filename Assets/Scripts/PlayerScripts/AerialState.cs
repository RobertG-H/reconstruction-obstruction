using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialState : PlayerState
{
    // Start is called before the first frame update
    public override PlayerState HandleInput(PlayerController p)
    {
        // return base.HandleInput(p);
        if (p.iGroundPoundPressed)
        {
            return new GroundPoundState();
        }
        return null;
    }

    public override PlayerState Update(PlayerController p)
    {
        if (Mathf.Abs(p.iHorz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(p.iHorz) * p.AIRACCELX);
            // if (Mathf.Abs(p.body.velocity.x) > p.AIRMAXSPEEDX)
            // {
            //     p.body.velocity = new Vector2(p.AIRMAXSPEEDX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
            // }
        }
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
