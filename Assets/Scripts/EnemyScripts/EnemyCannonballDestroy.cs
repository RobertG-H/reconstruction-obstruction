using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonballDestroy : MonoBehaviour
{
    public float timeoutDestructor = 2.5f;
    public GameObject bulletInstance; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(bulletInstance, timeoutDestructor); ; 
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(bulletInstance); 
    }
}
