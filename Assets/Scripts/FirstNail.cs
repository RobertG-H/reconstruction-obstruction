using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNail : MonoBehaviour
{

    public delegate void FirstNailHit();
    public static event FirstNailHit OnFirstNailHit;
    public GameObject childNail;
    private bool playOnce = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (playOnce) return;
        if (childNail.GetComponent<NailController>().isHit)
        {
            playOnce = true;
            OnFirstNailHit();
        }
    }


}
