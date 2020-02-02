using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject fort;
    public Camera cam;
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

    float ORIGINALZOOM;
    float ORIGINALY;
    private Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.transform;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
        originalPosition = camTransform.localPosition;
        ORIGINALZOOM = cam.orthographicSize;
        ORIGINALY = cam.transform.localPosition.y;
        // Zoom(-5f, 10f);
        // Shake(0.1f, 5f);

    }

    public void Shake(float intensity, float setDuration)
    {
        Debug.Log("Shake");
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
        else
        {
            shakeState = 0;
            camTransform.localPosition = originalPosition;
        }
    }

    public void Zoom(float zoomDelta, float setDuration)
    {
        zoomState = 1;
        zoomInput = cam.orthographicSize + zoomDelta;
        zoomDuration = setDuration;

    }

    public void ZoomReset()
    {
        zoomState = 2;
        zoomInput = ORIGINALZOOM;
        zoomDuration = 0.7f;
    }

    void ZoomChange()
    {
        if (Mathf.Abs(zoomInput - cam.orthographicSize) > 0.1f)
        {
            camTransform.localPosition = originalPosition; //resets to original position so that zoom functions with shake
            float newSize = Mathf.SmoothDamp(cam.orthographicSize, zoomInput, ref velocity, zoomDuration);
            cam.orthographicSize = newSize;
            float newHeight = Mathf.SmoothDamp(camTransform.localPosition.y, ORIGINALY + 20.0f, ref velocity, zoomDuration);
            cam.transform.localPosition = new Vector3(0, newHeight, -40);
            originalPosition = camTransform.localPosition;
        }
        else
        {
            zoomState = 0;
        }
    }

    void ZoomChangeReset()
    {
        if (Mathf.Abs(zoomInput - cam.orthographicSize) > 0.1f)
        {
            camTransform.localPosition = originalPosition; //resets to original position so that zoom functions with shake
            float newSize = Mathf.SmoothDamp(cam.orthographicSize, zoomInput, ref velocity, zoomDuration);
            cam.orthographicSize = newSize;
            float newHeight = Mathf.SmoothDamp(camTransform.localPosition.y, ORIGINALY, ref velocity, zoomDuration);
            cam.transform.localPosition = new Vector3(0, newHeight, -40);
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
        if (zoomState == 2)
        {
            ZoomChangeReset();
        }
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
