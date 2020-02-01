using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Equations of motion from https://en.wikipedia.org/wiki/Projectile_motion

public class ArcRenderer : MonoBehaviour
{

    LineRenderer lineRenderer;

    public float velocity;
    public float angle;
    public int resolution = 10;

    private float g;
    private float radianAngle;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }
    void Start()
    {
        RenderArc();
    }

    // Update is called once per frame
    void Update()
    {
        RenderArc();
    }

    void RenderArc()
    {
        lineRenderer.SetVertexCount(resolution + 1);
        lineRenderer.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
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
