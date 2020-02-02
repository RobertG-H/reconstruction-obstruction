using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class Arm : Fixable
{
    private bool once = false;
    public AttackController attackController;
    void Update()
    {
        if (isActive)
        {
            if (!once)
            {
                animator.SetBool("attack", true);
                once = true;
                attackController.SetDamage(1);

            }

        }
    }
}
