using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : AerialState
{
    private float addedJumpForce;
    private bool entered = true;
    public JumpingState(float addedJumpForce)
    {
        this.addedJumpForce = addedJumpForce;
    }
    public override PlayerState HandleInput(PlayerController p)
    {
        //Do nothing
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        // Debug.Log("Jumping");

        //Run once
        if (entered)
        {
            entered = false;
            p.body.AddForce(p.transform.TransformDirection(Vector3.up) * (p.JUMPFORCE + addedJumpForce));
        }

        return base.Update(p);
    }

    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("jumping", true);
    }
}
