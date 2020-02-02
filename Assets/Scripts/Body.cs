using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Fixable
{
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            animator.SetTrigger("activated");
        }
    }
}
