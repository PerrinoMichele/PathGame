using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;

    public bool isTouching = false;
    Vector3Int coordinates = new Vector3Int();
    public List<Vector3> neighbors = new List<Vector3>();
    

    void OnCollisionEnter(Collision other) 
    {
            AddNeighbors();
            CheckNeigbors();
            SnapToGrid();
    }

    private void SnapToGrid()
    {
        coordinates.x = Mathf.RoundToInt(transform.position.x);
        coordinates.z = Mathf.RoundToInt(transform.position.z);
        coordinates.y = Mathf.RoundToInt(transform.position.y);

        transform.position = coordinates;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void AddNeighbors()
    {
        neighbors.Add(transform.position += Vector3.up);
        neighbors.Add(transform.position += Vector3.down);
        neighbors.Add(transform.position += Vector3.right);
        neighbors.Add(transform.position += Vector3.left);
        neighbors.Add(transform.position += Vector3.forward);
        neighbors.Add(transform.position += Vector3.back);        
    }

    private void CheckNeigbors()
    {
        foreach(Vector3 neighbor in neighbors)
        {
            Debug.Log(neighbor);
        }
    }
}
