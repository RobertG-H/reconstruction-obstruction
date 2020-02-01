using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public virtual PlayerState HandleInput(PlayerController p) { return null; }
    public virtual PlayerState Update(PlayerController p) { return null; }

    //To call from PlayerController at the end of the frame if the state changes
    public virtual void StateEnter(PlayerController p) { }

    //Only implement in non-abstract states
    public virtual string GetStateID() { return null; }

    //Only implement in abstract states (e.g. GroundedState)
    public virtual string GetBaseStateID() { return null; }

}
