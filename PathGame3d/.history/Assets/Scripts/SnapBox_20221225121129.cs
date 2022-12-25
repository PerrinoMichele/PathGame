using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    public bool isTouching = false;
    Vector3Int coordinates = new Vector3Int();

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
            coordinates.x = Mathf.RoundToInt(transform.position.x );
            coordinates.z = Mathf.RoundToInt(transform.position.z );
            coordinates.y = Mathf.RoundToInt(transform.position.y );
            
            transform.position = coordinates;
            //deactivate gravity
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
