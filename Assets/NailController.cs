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
    public bool isHit = false;

    private float weight = 0.0f;
    private SoundManager nailSound1;
    private SoundManager nailSound2;

    public GameObject house;
    private FortSounds fortSounds;
    private bool initialHit = false;


    public delegate void NailHit();
    public static event NailHit OnNailHit;

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
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) return;
        if (transform.localPosition == endpoint.localPosition)
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
            transform.localPosition = Vector3.Lerp(startPosition, endpoint.localPosition, weight);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().CheckHitting())
            {
                if (!initialHit)
                {
                    initialHit = true;
                    Debug.Log("PLAYER NAIL HIT");
                    if (!isHit)
                    {
                        nailSound1.PlaySound("nail");
                        nailHit();
                    }
                }

            }

        }
    }



    void nailHit()
    {
        if (isHit) return;
        OnNailHit();
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
