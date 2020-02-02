using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D body;

    [HideInInspector]
    public Animator anim;

    public float ACCELSLOWDOWN;
    public float ACCELX;
    public float STOPTHRESH;
    public float SLOWDOWNTHRES;
    public float ABSMAXSPEEDX;
    [HideInInspector]
    public float currentMaxSpeedX;
    public float AIRACCELX;
    public float ARCFORCEX;

    public float ARCFORCEY;

    public float RAYCASTDOWNDIST = 0.8f;

    public bool isFacingRight = false;
    public bool changedState = false;

    public virtual void Start()
    {
        currentMaxSpeedX = ABSMAXSPEEDX;
    }
    public void Stop()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    public void CheckFlip(float horz)
    {
        if ((isFacingRight && horz < 0) || (!isFacingRight && horz > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -transform.localScale.x;
            transform.localScale = newScale;
            isFacingRight = !isFacingRight;
            Stop();
        }
    }
    public void ResetStates()
    {
        //Debug.LogWarning("EntityController: ResetStates() -> No animations implemented. Cannot reset states.");
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Bool)
            {
                anim.SetBool(param.name, false);
            }
        }
    }
    public bool RayCastGround()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        layerMask = ~layerMask;
        Vector3 currentPos = transform.position;
        float raycastSpacing = 0.95f;
        currentPos.x -= raycastSpacing;

        int hitRayCasts = 0;
        for (int i = 0; i < 3; i++)
        {
            if (Physics2D.Raycast(currentPos, transform.TransformDirection(Vector3.down), RAYCASTDOWNDIST, layerMask).collider != null)
            {
                hitRayCasts++;
                Debug.DrawRay(currentPos, transform.TransformDirection(Vector3.down) * RAYCASTDOWNDIST, Color.yellow);
            }
            else
            {
                Debug.DrawRay(currentPos, transform.TransformDirection(Vector3.down) * RAYCASTDOWNDIST, Color.red);
            }
            currentPos.x += raycastSpacing;
        }
        currentPos.x -= raycastSpacing;

        if (hitRayCasts == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
