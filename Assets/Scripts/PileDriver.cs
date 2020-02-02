using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileDriver : AttackController
{
    public GameObject piledriverProjectile; //Pipe driver game object
    [SerializeField]
    private float projectileForce = 10f;
    [SerializeField]
    private float projectileStartingPosition = 1f;

    void Start()
    {
        base.SetDamage(1);
    }

    void ShootShockwave()
    {
        GameObject shockwave1 = Instantiate(piledriverProjectile, new Vector3(projectileStartingPosition, 0, 0), Quaternion.identity) as GameObject;
        shockwave1.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileForce, 0, 0);
    }

}
