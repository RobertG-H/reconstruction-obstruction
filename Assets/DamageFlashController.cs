using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class DamageFlashController : MonoBehaviour
{

    public delegate void FlashComplete();
    public static event FlashComplete OnFlashComplete;

    public SpriteMeshInstance[] meshInstances;
    public bool isFlashing = false;
    public int flashCounter = 0;
    public int FLASHMAX = 80;
    // Start is called before the first frame update
    void Start()
    {
        setAlpha(1);

    }

    void Update()
    {
        if (!isFlashing)
        {
            return;
        }
        flashCounter += 1;
        if (flashCounter > FLASHMAX)
        {
            OnFlashComplete();
            setAlpha(1);
            isFlashing = false;
            flashCounter = 0;
        }
        if (flashCounter % 20 == 0)
        {
            setAlpha(1);

        }
        else if (flashCounter % 10 == 0)
        {
            setAlpha(0);
        }
    }

    void setAlpha(float val)
    {
        foreach (SpriteMeshInstance mi in meshInstances)
        {
            mi.color = new Color(1, 1, 1, val);
        }
    }


}
