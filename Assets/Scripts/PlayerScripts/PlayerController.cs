using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    private PlayerState state;

    public ArcRenderer arcRenderer;

    public CameraController cameraController;

    public HealthBarController healthBar;

    public DamageFlashController damageFlash;

    public float HEALTH;
    public float MAXHEALTH;

    [HideInInspector]
    public float iHorz;
    [HideInInspector]
    public bool iGroundPoundPressed;
    [HideInInspector]
    public bool iArcReleased;
    [HideInInspector]
    public bool iArcPressed;
    public float ARCSQUATFORCE;

    public float NORMALFALLMULTIPLIER;
    [HideInInspector]
    public float currentFallMultiplier;
    public float MAXARCDURATION;
    public float GPSPEED;
    [HideInInspector]
    public float iArcPressDuration;

    private bool arcCancelled = false;

    public bool isHitting = false;

    public bool isGroundPounding = false;

    [HideInInspector]
    public RatSounds ratSounds;

    public bool isHitable = true;


    // DELEGATES AND EVENTS
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    // Start is called before the first frame update

    void OnEnable()
    {

        DamageFlashController.OnFlashComplete += ResetFlash;
    }

    void OnDisable()
    {
        DamageFlashController.OnFlashComplete -= ResetFlash;
    }
    public override void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = new IdleState();
        ratSounds = GetComponent<RatSounds>();
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        // foreach (AnimationClip clip in clips)
        // {
        //     switch (clip.name)
        //     {
        //         case "Slash":
        //             attackDurations[clip.name] = clip.length;
        //             break;
        //     }
        // }

        arcRenderer.vSpeedFrameDelta = ARCSQUATFORCE * ARCFORCEY;
        arcRenderer.hSpeedFrameDelta = ARCSQUATFORCE * ARCFORCEX;
        arcRenderer.MAXVSPEED = ARCSQUATFORCE * ARCFORCEY * MAXARCDURATION;
        arcRenderer.MAXHSPEED = ARCSQUATFORCE * ARCFORCEX * MAXARCDURATION;

        base.Start();
    }
    void Update()
    {
        // Debug.Log(state.ToString());
        RayCastGround();
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

    public void OnGroundPoundPressed(InputAction.CallbackContext context)
    {
        currentFallMultiplier = NORMALFALLMULTIPLIER * 10;
        isGroundPounding = true;
        iGroundPoundPressed = true;
        HandleInput();
        iGroundPoundPressed = false;
    }

    public void OnArcPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Arc pressed");
        if (context.started)
        {
            currentMaxSpeedX /= 2.5f;
            arcRenderer.isCharging = true;
            cameraController.Zoom(40f, MAXARCDURATION - 0.2f);
            iArcPressed = true;
            HandleInput();
            iArcPressed = false;
            arcCancelled = false;
        }
        else if (!arcCancelled)
        {
            currentMaxSpeedX = ABSMAXSPEEDX;
            arcRenderer.isCharging = false;
            cameraController.ZoomReset();
            iArcReleased = true;
            iArcPressDuration = Mathf.Min((float)context.duration, MAXARCDURATION);
            HandleInput();
            iArcReleased = false;
        }

    }

    public void OnCancelArcPressed(InputAction.CallbackContext context)
    {
        arcRenderer.isCharging = false;
        arcCancelled = true;
    }

    public void TakeHit(Vector3 otherPos, float damage, float knockback)
    {
        if (damage <= 0.0f) return;
        Debug.Log(string.Format("BEEN HIT, with isHitable {0}", isHitable));
        if (!isHitable) return;
        isHitable = false;
        damageFlash.isFlashing = true;
        HEALTH -= damage;
        healthBar.UpdateHealth(HEALTH, MAXHEALTH);

        // Debug.Log(HEALTH);
        ratSounds.PlayRatSound("RAT-hurt");

        if (HEALTH <= 0)
        {
            OnPlayerDeath();
            ratSounds.PlayRatSound("RAT-death");
        }
    }

    public bool CheckHitting()
    {
        return isHitting;
    }

    private void ResetFlash()
    {
        isHitable = true;
    }
}
