using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    [SerializeField] float sphereRadius = 0.3f;

    public bool isTouching = false;
    public List<Vector3> neighboringTiles = new List<Vector3>();
    public bool isPickable = false;
    Vector3Int coordinates = new Vector3Int();

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "RedFruit")
        {
            this.GetComponent<SnapBox>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hit by red fruit");
            isPickable = true; //Make collider size 1,1,1
        }
        else if (isPickable == false)
        {
            SnapToGrid();
            AddNewNeighbors();
            return;
            //Make collider size .8,.8,.8
        }
    }



    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic == true)
        {
            if (NeighborCollides() == false)
            {           
                MoveBoxDown();
                AddNewNeighbors();
            }
        }
    }

    private void MoveBoxDown()
    {
        transform.position += Vector3.down;
    }

    private void OnDrawGizmos() {//delete
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
        //gameObject.GetComponent<Collider>().isTrigger = false;
    }

    private void AddNewNeighbors()
    {
        neighboringTiles.Clear();
        neighboringTiles.Add(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        neighboringTiles.Add(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
        neighboringTiles.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
        neighboringTiles.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
        neighboringTiles.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
        neighboringTiles.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
    }
    //RemoveNeighbors?

    private bool NeighborCollides()
    {
        foreach(Vector3 neighboringTile in neighboringTiles)
        {
            if(Physics.CheckSphere(neighboringTile, sphereRadius))
            {
                return true;
            }
        }

    
        return false;
    }


}
