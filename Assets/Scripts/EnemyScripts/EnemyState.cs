using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{

    public virtual EnemyState HandleInput(EnemyController enemy) { return null; }
    public virtual EnemyState Update(EnemyController enemy) { return null; }

    //To call from PlayerController at the end of the frame if the state changes
    public virtual void StateEnter(EnemyController enemy) { }

    //Only implement in non-abstract states
    public virtual string GetStateID() { return null; }

    //Only implement in abstract states (e.g. GroundedState)
    public virtual string GetBaseStateID() { return null; }
}
