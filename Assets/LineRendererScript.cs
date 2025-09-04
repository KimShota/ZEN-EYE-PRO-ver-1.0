using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float rayDistance = 10f;
    public Color lineColor = Color.green;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.forward * rayDistance;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}