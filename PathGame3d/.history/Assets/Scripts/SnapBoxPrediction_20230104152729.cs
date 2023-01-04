using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBoxPrediction : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;
    public List<Vector3> neighboringTiles = new List<Vector3>();
    Vector3Int coordinates = new Vector3Int();
}
