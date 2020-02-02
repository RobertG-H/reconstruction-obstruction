using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingState : PlayerState
{
    public override PlayerState HandleInput(PlayerController p)
    {
        // p.CheckFlip(p.iHorz);
        return null;
        // return null;
    }

    public override PlayerState Update(PlayerController p)
    {
        p.CheckFlip(p.iHorz);
        //Do nothing
        if (Mathf.Abs(p.iHorz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(p.iHorz) * p.ACCELX);
            if (Mathf.Abs(p.body.velocity.x) > p.currentMaxSpeedX)
            {
                p.body.velocity = new Vector2(p.currentMaxSpeedX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
            }
        }
        else
        {
            if (Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
            {
                p.body.AddForce(new Vector2(Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
            }
            else
            {
                p.Stop();
            }
        }
        return null;
    }
}
