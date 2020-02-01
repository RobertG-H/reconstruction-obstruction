using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{
    public GameObject player;
    public GameObject fort;
    private Camera cam;
    private float velocity = 0f;
    private int zoomState = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;       
        zoomState = 0;
        Debug.Log(cam.transform.position.z);
    }

    void Zoom(int dir, float zoomInput, float duration)
    {
        zoomInput = zoomInput * dir;
        if (Mathf.Abs(zoomInput - cam.transform.position.z) > 0.01f)
        {
            float newSize = Mathf.SmoothDamp(cam.transform.position.z, zoomInput, ref velocity, duration);
            float CamX = cam.transform.position.x;
            float CamY = transform.position.y;
            cam.transform.position = new Vector3(CamX, CamY, newSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Set update zoom level based on current trajectory of the hammer
        //Zoom(player.)
        ZoomOut(-1, 15f, 1f);
        Debug.Log(cam.transform.position.z);
    }
}
