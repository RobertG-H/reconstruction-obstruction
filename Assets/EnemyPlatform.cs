using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyPlatform : MonoBehaviour
{
    public GameObject[] platforms;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject plat in platforms)
        {
            LineRenderer lr = plat.GetComponent<LineRenderer>();
            // lr.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnArcPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            foreach (GameObject plat in platforms)
            {
                LineRenderer lr = plat.GetComponent<LineRenderer>();
                lr.enabled = true;
            }
        }
        else
        {
            foreach (GameObject plat in platforms)
            {
                LineRenderer lr = plat.GetComponent<LineRenderer>();
                // lr.enabled = false;
            }
        }
    }
}
