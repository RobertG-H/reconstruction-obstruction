using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public GameObject container;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = container.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            animator.SetBool("attack", true);
        }
    }
}
