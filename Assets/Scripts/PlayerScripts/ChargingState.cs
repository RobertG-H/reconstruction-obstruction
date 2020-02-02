using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ChargingState : MovingState
{
    public override PlayerState HandleInput(PlayerController p)
    {
        if (p.iArcReleased)
        {
            return new ArcJumpState(p, p.iArcPressDuration * p.ARCSQUATFORCE);
        }
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        return base.Update(p);
    }
    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("charging", true);
    }
}