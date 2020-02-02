using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private float duration = 0.5f;
    private float elapsedTime = 0;
    public float damage = 0;
    private float knockback = 0;

    private bool persistent = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!persistent)
        {
            if (elapsedTime >= duration)
            {
                Destroy(this.gameObject);
            }
            elapsedTime += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER IT");

            other.gameObject.GetComponent<PlayerController>().TakeHit(transform.position, damage, knockback);
        }
    }
    public void SetPersistent()
    {
        this.persistent = true;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    public void SetKnockback(float knockback)
    {
        this.knockback = knockback;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetKnockback()
    {
        return knockback;
    }
}
