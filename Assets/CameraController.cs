using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject fort;
    private Camera cam;
    private float velocity = 0f;
    //Zoom variables
    private int zoomState = 0;
    private float zoomInput = 0f;
    private float zoomDuration = 0f;
    //Shake variables
    private int shakeState = 0;
    private float shakeIntensity = 0f;
    private float shakeDuration = 0f;
    Vector3 originalPosition;
    public Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
        originalPosition = camTransform.localPosition;
        Zoom(-5f, 10f);
        Shake(0.1f, 5f);

    }

    void Shake(float intensity, float setDuration)
    {
        shakeState = 1;
        shakeIntensity = intensity;
        shakeDuration = setDuration;
        originalPosition = camTransform.localPosition;
    }

    void ShakeChange()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        else {
            shakeState = 0;
            //camTransform.localPosition = originalPosition;
        }
    }

    void Zoom(float zoomDelta, float setDuration)
    {
        zoomState = 1;
        zoomInput = cam.transform.position.z + zoomDelta;
        zoomDuration =  setDuration;
    }

    void ZoomChange()
    {
        Debug.Log(zoomInput);
        Debug.Log(cam.transform.position.z);
        if (Mathf.Abs(zoomInput - cam.transform.position.z) > 0.01f)
        {
            camTransform.localPosition = originalPosition; //resets to original position so that zoom functions with shake
            float newSize = Mathf.SmoothDamp(cam.transform.position.z, zoomInput, ref velocity, zoomDuration);
            float CamX = cam.transform.position.x;
            float CamY = transform.position.y;
            cam.transform.position = new Vector3(CamX, CamY, newSize);
            originalPosition = camTransform.localPosition;
        }
        else
        {
            zoomState = 0;
        }
    }



    // Update is called once per frame
    void Update()
    {
        //Set update zoom level based on current trajectory of the hammer
        //Zoom(player.)
        if (zoomState == 1)
        {
            ZoomChange();
        }
        if (shakeState == 1)
        {
            ShakeChange();
        }
    }
}
