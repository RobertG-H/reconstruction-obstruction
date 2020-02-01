using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonballDestroy : MonoBehaviour
{
    public float timeoutDestructor = 1.5f;
    public GameObject cannonballInstance; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(cannonballInstance, 1.0f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(cannonballInstance); 
    }
}
