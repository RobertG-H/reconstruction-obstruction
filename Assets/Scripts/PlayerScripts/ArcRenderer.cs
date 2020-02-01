using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Equations of motion from https://en.wikipedia.org/wiki/Projectile_motion

public class ArcRenderer : MonoBehaviour
{

    public LineRenderer lineRenderer;

    public bool isCharging = false;

    public bool isResetable = false;

    public float velocity;

    private float vSpeed;
    public float MAXVSPEED;
    public float vSpeedFrameDelta;
    private float hSpeed;
    public float MAXHSPEED;
    public float hSpeedFrameDelta;


    public int resolution = 10;

    private float g;
    private float radianAngle;


    void Awake()
    {
        //  lineRenderer = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }
    void Start()
    {
        vSpeed = 0;
        hSpeed = 0;
        //RenderArc();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharging)
        {
            if (!lineRenderer.gameObject.activeSelf)
                lineRenderer.gameObject.SetActive(true);
            vSpeed += vSpeedFrameDelta * Time.deltaTime;
            hSpeed += hSpeedFrameDelta * Time.deltaTime;
            if (vSpeed > MAXVSPEED)
                vSpeed = MAXVSPEED;
            if (hSpeed > MAXHSPEED)
                hSpeed = MAXHSPEED;
            velocity = Mathf.Sqrt(Mathf.Pow(vSpeed, 2) + Mathf.Pow(hSpeed, 2));
            radianAngle = Mathf.Atan2(vSpeed, hSpeed);
            RenderArc();
            isResetable = true;
        }
        else if (isResetable)
        {
            Reset();
        }
    }

    void Reset()
    {
        lineRenderer.gameObject.SetActive(false);
        isResetable = false;
        vSpeed = 0;
        hSpeed = 0;
    }

    void RenderArc()
    {
        // Debug.Log(string.Format("Renderer arc... vspeed: {0}, hspeed: {1}", vSpeed, hSpeed));
        lineRenderer.positionCount = resolution + 1;
        lineRenderer.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }
}
