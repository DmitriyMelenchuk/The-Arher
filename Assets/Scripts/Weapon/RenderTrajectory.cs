using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RenderTrajectory : MonoBehaviour
{
    [SerializeField] private int _countPoint;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw(Vector3 startPosition, Vector3 speed)
    {
        Vector3[] points = new Vector3[_countPoint];
        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = startPosition + speed * time + Physics.gravity * time * time / 2f;
        }

        _lineRenderer.SetPositions(points);
    }

    public void Activated()
    {
        gameObject.SetActive(true);
    }

    public void Deactivated()
    {
        gameObject.SetActive(false);
    }
}
