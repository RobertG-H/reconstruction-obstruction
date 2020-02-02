using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    // ENEMY STATS
    public float ACCELSLOWDOWN;
    public float ACCELX;
    public float STOPTHRESH;
    public float SLOWDOWNTHRES;
    public float MAXSPEEDX;

    public float RAYCASTSIDEDIST = 2.0f;

    // DELEGATES AND EVENTS
    public delegate void HorzRayCast();
    public static event HorzRayCast OnHorzRayCast;

    // INSPECTOR OBJECTS
    [HideInInspector]
    public Rigidbody2D body;

    [HideInInspector]
    public Animator anim;

    // ENEMY STATUS VARS
    [HideInInspector]
    public float iHorz;
    private bool isFacingRight = true;

    private EnemyState state;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = new EnemyIdleState();
    }

    void Update()
    {
        // Debug.Log(string.Format("iHorz: {0}", iHorz));

        RayCastDirection();
        CheckNewState(state.Update(this));
    }

    public void CheckFlip()
    {
        if ((isFacingRight && iHorz < 0) || (!isFacingRight && iHorz > 0))
        {
            // Vector3 newScale = transform.localScale;
            // newScale.x = -transform.localScale.x;
            // transform.localScale = newScale;
            isFacingRight = !isFacingRight;
        }
    }

    public void Stop()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    public void HandleInput()
    {
        // State can be null if player joins scene by pressing input.
        // The input events will be fired before Start() is called.
        if (state == null)
        {
            return;
        }
        CheckNewState(state.HandleInput(this));
    }

    private void CheckNewState(EnemyState newState)
    {
        if (newState == null)
            return;
        state = newState;
        state.StateEnter(this);
    }

    public bool RayCastDirection()
    {
        Vector3 direction = new Vector3();
        if (isFacingRight)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        int layerMask2 = 1 << LayerMask.NameToLayer("Fort");
        layerMask += layerMask2;
        layerMask = ~layerMask;
        Vector3 currentPos = transform.position;

        if (Physics2D.Raycast(currentPos, transform.TransformDirection(direction), RAYCASTSIDEDIST, layerMask).collider == null)
        {
            Debug.DrawRay(currentPos, transform.TransformDirection(direction) * RAYCASTSIDEDIST, Color.yellow);
            return false;
        }
        else
        {
            Debug.DrawRay(currentPos, transform.TransformDirection(direction) * RAYCASTSIDEDIST, Color.red);
            OnHorzRayCast();
            return true;
        }
    }

    public void ResetStates()
    {
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Bool)
            {
                anim.SetBool(param.name, false);
            }
        }
    }
    public void OnHorizontal(InputAction.CallbackContext context)
    {
        HandleHorizontal(context.ReadValue<float>());
    }

    public void HandleHorizontal(float horizontal)
    {
        iHorz = horizontal;
        HandleInput();
    }
}
