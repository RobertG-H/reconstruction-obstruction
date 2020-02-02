using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonballDestroy : AttackController
{
    public float timeoutDestructor = 2.5f;
    public GameObject bulletInstance;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(bulletInstance, timeoutDestructor); ;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER IT");

            other.gameObject.GetComponent<PlayerController>().TakeHit(transform.position, damage, GetKnockback());
            Destroy(bulletInstance);
        }
    }
}
