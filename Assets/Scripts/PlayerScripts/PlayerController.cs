using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    private PlayerState state;
    public float iHorz;
    public bool iJumpReleased; 
    public float JUMPSQUATFORCE;
    public bool iArcReleased;
    public float ARCSQUATFORCE; 

    public float MAXJUMPDURATION;
    public float MAXARCDURATION; 

    public float iJumpPressDuration;
    public float iArcPressDuration; 

    // Start is called before the first frame update
    public override void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = new IdleState();
        // AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        // foreach(AnimationClip clip in clips)
        // {
        //     switch(clip.name)
        //     {
        //         case "Slash":
        //             attackDurations[clip.name] = clip.length;
        //             break;
        //     }
        // }
        base.Start();
    }
    void Update()
    {
        CheckNewState(state.Update(this));
    }

    void HandleInput()
    {
        // State can be null if player joins scene by pressing input.
        // The input events will be fired before Start() is called.
        if (state == null)
        {
            return;
        }
        CheckNewState(state.HandleInput(this));
    }

    private void CheckNewState(PlayerState newState)
    {
        if (newState == null)
            return;
        state = newState;
        state.StateEnter(this);
    }

    // TODO remove entityinput and playerinput classes
    public void OnHorizontal(InputAction.CallbackContext context)
    {
        iHorz = context.ReadValue<float>();
        HandleInput();
    }

    public void OnJumpPressed(InputAction.CallbackContext context)
    {
        return; 
        // First press
        if (!context.started)
        {
            iJumpReleased = true;
            iJumpPressDuration = Mathf.Min((float)context.duration, MAXJUMPDURATION);
            HandleInput();
            iJumpReleased = false;
        }

    }

    public void OnArcPressed(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            Debug.Log("Second");
            iArcReleased = true;
            iArcPressDuration = Mathf.Min((float)context.duration, MAXARCDURATION); // increase duration 
            HandleInput();
            iArcReleased = false;
        }
        else
            Debug.Log("First");

    }
}
