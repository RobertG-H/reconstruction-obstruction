using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    // cannon 
    public Transform cannonBoneTransform;
    public float rotationSpeed = 5f;
    public float deltaAngle = -10; // fix difference in the art and actual rotation bullet is firing from 

    // bullet 
    public GameObject bullet;
    private float timeHorFlying = 1.5f;
    private float timeVerFlying = 0.5f; 
    public float bulletForce = 100;

    // shooting
    private int timePassed = 1;
    public float vSpeed;
    public float hSpeed;
    
    // player; rat 
    public Transform ratTransform; 
    

    void Start()
    {
        // :) 
    }


    void Update()
    {
        Vector3 direction = ratTransform.position - cannonBoneTransform.position; // direction bullet is fired 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // angle between cannon and rat 
        Quaternion rotation = Quaternion.AngleAxis(angle + deltaAngle, Vector3.forward); 
        cannonBoneTransform.rotation = Quaternion.Slerp(cannonBoneTransform.rotation, rotation, rotationSpeed * Time.deltaTime);

        vSpeed = (ratTransform.position.y - cannonBoneTransform.position.y) * timeVerFlying;
        hSpeed = (ratTransform.position.x - cannonBoneTransform.position.x) * timeHorFlying;


        GameObject bulletInstance;
        if (timePassed % 150 == 0) 
        {
            bulletInstance = Instantiate(bullet, cannonBoneTransform.position, rotation);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(hSpeed, vSpeed, 0); 
            timePassed = 1; 
        }
        timePassed++;
    }
}
