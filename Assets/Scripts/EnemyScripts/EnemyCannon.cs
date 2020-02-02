using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    private int timePassed = 1;
    public float vSpeed;
    public float hSpeed;
    public Transform cannonTransform;
    public Transform ratTransform; 
    public GameObject cannonball;
    public float cannonForceUp; 

    public float rotationSpeed = 5f;
    private float timeFlying = 1; 

    void Start()
    {

    }


    void Update()
    {
        Vector3 direction = ratTransform.position - cannonTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        cannonTransform.rotation = Quaternion.Slerp(cannonTransform.rotation, rotation, rotationSpeed * Time.deltaTime);

        vSpeed = (ratTransform.position.y - cannonTransform.position.y) * timeFlying;
        hSpeed = (ratTransform.position.x - cannonTransform.position.x) * timeFlying;

        if (timePassed % 150 == 0)
        {
            GameObject cannonballInstance;
            cannonballInstance = Instantiate(cannonball, cannonTransform.position, cannonTransform.rotation);
            // cannonballInstance.AddForce(cannonTransform.up * cannonForceUp);
            cannonballInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(hSpeed, vSpeed, 0); 

            timePassed = 1; 
        }
        timePassed++; 

    }
}
