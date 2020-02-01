using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileDriver : MonoBehaviour
{
    public GameObject piledriverProjectile; //Pipe driver game object
    [SerializeField]
    private float projectileForce = 10f;
    [SerializeField]
    private float projectileStartingPosition = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void ShootShockwave()
    {
        GameObject shockwave1  = Instantiate(piledriverProjectile, new Vector3(projectileStartingPosition,0,0), Quaternion.identity) as GameObject;
        shockwave1.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileForce,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            ShootShockwave();
        }
    }
}
