using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform releasePos;
    [SerializeField][Range(10,100)] private int LinePoints = 25;
    [SerializeField][Range(0.01f,0.25f)] private float TimeBetweenPoints = 0.1f;
    
    public GameObject boxPrefab;

    void Update() {
        DrawProjection();
    }

    private void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt (LinePoints / TimeBetweenPoints) + 1;
        Vector3 startPosition = releasePos.position;
        Vector3 startVelocity = 450 * transform.forward / 1;
    }
}
