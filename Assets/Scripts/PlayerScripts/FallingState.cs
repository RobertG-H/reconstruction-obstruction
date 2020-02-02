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
        // Debug.Log("Falling");
        if (p.RayCastGround())
        {
            if (p.isGroundPounding)
            {
                p.cameraController.Shake(0.4f, 0.4f);
                p.isGroundPounding = false;
                p.ratSounds.PlayRatSound("hammer-touchdown");
            }

            p.currentFallMultiplier = p.NORMALFALLMULTIPLIER;
            if (Mathf.Abs(p.iHorz) > 0)
            {
                return new WalkingState();
            }
            else
            {
                return new IdleState();
            }
        }
        else
        {
            p.body.velocity += Vector2.up * Physics2D.gravity.y * p.currentFallMultiplier * Time.deltaTime;
            // Debug.Log(string.Format("current fall: {0}", p.currentFallMultiplier));
        }
        return base.Update(p);
    }

    public override void StateEnter(PlayerController p)
    {
        // p.ResetStates();
        // p.anim.SetBool("falling", true);
    }
}
