using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform releasePos;
    [SerializeField][Range(10,100)] private int LinePoints = 25;
    [SerializeField][Range(0.01f,0.25f)] private float TimeBetweenPoints = 0.1f;
}
