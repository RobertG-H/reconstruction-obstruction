using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{
    public GameObject player;
    public GameObject fort;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = CameraBase;
        size = cam.orthographicSize;
    }

    void ZoomOut()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
