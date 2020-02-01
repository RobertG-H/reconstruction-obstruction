using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardsAerialState : AerialState
{
    public override PlayerState HandleInput(PlayerController p)
    {
        //Do nothing
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        Debug.Log("Moving Up");

        return base.Update(p);
    }
    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("movingUp", true);
    }
}
