using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class Arm : Fixable
{
    void Update()
    {
        if (isActive)
        {
            animator.SetBool("attack", true);
        }
    }
}
