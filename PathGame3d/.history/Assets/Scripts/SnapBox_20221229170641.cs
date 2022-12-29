using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;

    public bool isTouching = false;
    Vector3Int coordinates = new Vector3Int();
    public List<Vector3> neighboringTiles = new List<Vector3>();   

    void OnCollisionEnter(Collision other) 
    {
        SnapToGrid();
        AddNeighbors();
        CheckNeigbors();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        foreach (Vector3 neighbor in neighboringTiles)
        {
            Gizmos.DrawWireSphere(neighbor, sphereRadius);
        }

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
        neighboringTiles.Add(transform.position += Vector3.up);
        neighboringTiles.Add(transform.position -= Vector3.down);
        Debug.Log(transform.position);
        Debug.Log(neighboringTiles[0]);
        Debug.Log(neighboringTiles[1]);
    }

    private void CheckNeigbors()
    {
        foreach(Vector3 neighboringTile in neighboringTiles)
        {

            if(Physics.CheckSphere(neighboringTile, sphereRadius))
            {
                
                //Debug.Log(neighboringTile);
                return;
            }
        }
    }

    private void MoveBoxDown()
    {
        this.transform.position += Vector3.down;
    }
}
