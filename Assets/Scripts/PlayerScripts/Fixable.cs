using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class Fixable : AttackController
{
    public SpriteMeshInstance[] spriteRenderers;
    public Animator animator;

    public bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        base.SetDamage(0);
        if (animator == null)
            animator = GetComponent<Animator>();
        foreach (SpriteMeshInstance sr in spriteRenderers)
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void repair()
    {
        base.SetDamage(1);

        foreach (SpriteMeshInstance sr in spriteRenderers)
        {
            sr.color = Color.white;
        }
        isActive = true;
    }
}
