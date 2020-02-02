using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNail : Fixable
{


    public delegate void FinalNailHit();
    public static event FinalNailHit OnFinalNailHit;
    public GameObject childNail;
    // Start is called before the first frame update
    void Start()
    {
        childNail.SetActive(false);

    }

    public void showFinal()
    {
        childNail.SetActive(true);
    }

    private void Update()
    {
        if (childNail.GetComponent<NailController>().isHit)
        {
            OnFinalNailHit();
        }
    }
}
