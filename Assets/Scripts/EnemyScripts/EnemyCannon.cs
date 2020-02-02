using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : Fixable
{
    // cannon 
    public Transform cannonBoneTransform;
    public Transform cannonSpawnPoint;
    public float rotationSpeed = 5f;
    public float deltaAngle = -10; // fix difference in the art and actual rotation bullet is firing from 

    // bullet 
    public GameObject bullet;
    public float timeHorFlying = 2.5f;
    public float timeVerFlying = 2.0f;
    private float bulletForce = 100;

    // shooting
    private int timePassed = 1;
    private float vSpeed;
    private float hSpeed;
    public int framesToShoot = 150;

    // player; rat 
    public Transform ratTransform;


    void Update()
    {
        if (!isActive) return;
        Vector3 direction = ratTransform.position - cannonBoneTransform.position; // direction bullet is fired 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // angle between cannon and rat 
        Quaternion rotation = Quaternion.AngleAxis(angle + deltaAngle, Vector3.forward);
        cannonBoneTransform.rotation = Quaternion.Slerp(cannonBoneTransform.rotation, rotation, rotationSpeed * Time.deltaTime);

        vSpeed = (ratTransform.position.y - cannonBoneTransform.position.y) * timeVerFlying;
        hSpeed = (ratTransform.position.x - cannonBoneTransform.position.x) * timeHorFlying;


        GameObject bulletInstance;
        if (timePassed % framesToShoot == 0)
        {
            bulletInstance = Instantiate(bullet, cannonSpawnPoint.position, rotation);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(hSpeed, vSpeed, 0);
            timePassed = 1;
        }
        timePassed++;
    }
}
