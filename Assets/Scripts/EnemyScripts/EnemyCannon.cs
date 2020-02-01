using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    private bool fix; // true if cannon is fixed 

    public Rigidbody2D cannonball;
    public Transform cannonHeadTransform;
    public Transform playerTransform; 

    private float hSpeed;
    private float vSpeed; 

    private int timePassed = 1;

    // Start is called before the first frame update
    void Start()
    {
        // :) 
    }

    // Update is called once per frame
    void Update()
    {
        // add while (fixed) 
        if (timePassed % 50 == 0)
        {
            vSpeed = (playerTransform.position.y - cannonHeadTransform.position.y);
            hSpeed = (playerTransform.position.x - cannonHeadTransform.position.x);

            Rigidbody2D cannonballInstance; 
            cannonballInstance = Instantiate(cannonball, cannonHeadTransform.position, cannonHeadTransform.rotation); 
            cannonballInstance.velocity = new Vector3(hSpeed, vSpeed, 0);
        }
        timePassed++;
    }
}
