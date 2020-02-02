using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailController : MonoBehaviour
{

    public Transform endpoint;

    public ParticleSystem particleSystem;

    public Fixable weapon;

    private Vector3 startPosition;

    public float moveSpeed;

    private bool moving = false;
    private bool isHit = false;

    private float weight = 0.0f;
    private SoundManager nailSound1;
    private SoundManager nailSound2;

    public GameObject house;
    private FortSounds fortSounds;
 
    // Start is called before the first frame update
    void Awake()
    {
        print(GetComponents<SoundManager>().Length);
        nailSound1 = GetComponents<SoundManager>()[0];
        nailSound2 = GetComponents<SoundManager>()[1];
        fortSounds = house.GetComponent<FortSounds>();

        particleSystem = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) return;
        if (transform.position == endpoint.position)
        {
            particleSystem.Stop();
            isHit = true;
            Debug.Log("stopped moving");
            nailSound2.PlaySound("nail2");
            fortSounds.PlaySound("roar");
        }
        if (moving)
        {
            //check flag
            weight += Time.deltaTime * moveSpeed; //amount
            transform.position = Vector3.Lerp(startPosition, endpoint.position, weight);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().CheckHitting())
            {
                Debug.Log("PLAYER NAIL HIT");
                if(!isHit)
                {
                    nailSound1.PlaySound("nail");
                }
                nailHit();
            }

        }
    }

    void nailHit()
    {
        moving = true;
        if (weapon == null)
        {
            Debug.LogWarning("NO WEAPON SET FOR THE NAIL");
        }
        else
        {

            weapon.repair();
        }
    }
}
