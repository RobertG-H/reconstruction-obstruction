using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_script : MonoBehaviour
{

    public SpriteRenderer intro;
    public AudioSource introSound;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = Fade(2.0f);
        StartCoroutine(coroutine);


    }

    // Update is called once per frame
    void Update()
    {

    }

    // every 2 seconds perform the print()
    private IEnumerator Fade(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime / 2);
            print("WaitAndPrint " + Time.time);
            yield return new WaitForSeconds(waitTime / 2);

        }
    }
}
