using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcJumpState : AerialState
{
    // private float ArcForce; 
    // private float horSpeed = 5; // initial horizontal speed; todo change w/ timePresed  
    // private static float vertSpeed = 5; // initial vertical speed; todo change w/ timePressed  
    // private static float g = -9.8f; 
    // private static float maxHeight = 5; // maximum height; todo change w/ timePressed 
    // private float totalTime = 2 * vertSpeed / g; // total time of projectile 

    private bool entered = true;
    private float vSpeed;
    private float hSpeed;

    public ArcJumpState(PlayerController p, float addedArcforce)
    {
        vSpeed = p.ARCFORCEY * addedArcforce;
        if (!p.isFacingRight)
        {
            hSpeed = -1 * p.ARCFORCEX * addedArcforce;
        }
        else
        {
            hSpeed = p.ARCFORCEX * addedArcforce;
        }
    }


    public override PlayerState HandleInput(PlayerController p)
    {
        //Do nothing
        return base.HandleInput(p);
    }

    public override PlayerState Update(PlayerController p)
    {
        // Debug.Log("ArcJump");

        //Run once
        if (entered)
        {
            entered = false;
            // Debug.Log(string.Format("ArcJump... vspeed: {0}, hspeed: {1}", vSpeed, hSpeed));
            p.body.velocity = new Vector3(hSpeed, vSpeed, 0);
        }

        return base.Update(p);
    }


    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("slamming", true);
    }
}
