using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject fort;
    private Camera cam;
    private float velocity = 0f;
    private int zoomState = 0;
    private float zoomInput = 0f;
    private float duration = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;       
        zoomState = 0;
        ZoomStart(-5f, 1);
    }

    void ZoomStart(float zoomDelta, float setDuration)
    {
        zoomState = 1;
        zoomInput = cam.transform.position.z + zoomDelta;
        duration =  setDuration;
    }

    void Zoom()
    {
        if (Mathf.Abs(zoomInput - cam.transform.position.z) > 0.01f)
        {
            float newSize = Mathf.SmoothDamp(cam.transform.position.z, zoomInput, ref velocity, duration);
            float CamX = cam.transform.position.x;
            float CamY = transform.position.y;
            cam.transform.position = new Vector3(CamX, CamY, newSize);
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
            Zoom();
        }
    }
}
