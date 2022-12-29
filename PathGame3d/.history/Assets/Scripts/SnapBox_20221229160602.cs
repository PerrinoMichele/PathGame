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
        neighbors.Add(transform.position += Vector3.up);
        neighbors.Add(transform.position += Vector3.down);
        neighbors.Add(transform.position += Vector3.right);
        neighbors.Add(transform.position += Vector3.left);
        neighbors.Add(transform.position += Vector3.forward);
        neighbors.Add(transform.position += Vector3.back);
        Debug.Log(neighbors);
    }

    private void CheckNeigbors()
    {

    }
}
