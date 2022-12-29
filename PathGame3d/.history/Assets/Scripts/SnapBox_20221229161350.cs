using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;

    public bool isTouching = false;
    Vector3Int coordinates = new Vector3Int();
    //create a list of transforms called neighbors; in Start, fill this list with all neighboring positions
    public List<Vector3> neighbors = new List<Vector3>();
    

    void OnCollisionEnter(Collision other) 
    {
        isTouching = true;
    }

    void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isTouching = false;
        }
    }

    void Update()
    {
        if (isTouching == true)
        {
            SnapToGrid();
            AddNeighbors();
            CheckNeigbors();

            //check in this coordinates there is no box

            //deactivate gravity

            //check each neighbor to make sure there is something there or else move down by one until it has a neighbor
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
        neighbors.Add(transform.position += Vector3.up.normalized);
        neighbors.Add(transform.position += Vector3.down.normalized);
        neighbors.Add(transform.position += Vector3.right.normalized);
        neighbors.Add(transform.position += Vector3.left.normalized);
        neighbors.Add(transform.position += Vector3.forward.normalized);
        neighbors.Add(transform.position += Vector3.back.normalized);
        Debug.Log(neighbors[0] +neighbors[1] + neighbors[2] +neighbors[3] + neighbors[4] + neighbors[5]);
        
    }

    private void CheckNeigbors()
    {

    }
}
