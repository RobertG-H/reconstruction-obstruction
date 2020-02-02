using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnArcPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                LineRenderer lr = transform.GetChild(i).gameObject.GetComponent<LineRenderer>();
                lr.enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                LineRenderer lr = transform.GetChild(i).gameObject.GetComponent<LineRenderer>();
                lr.enabled = false;
            }
        }
    }
}
