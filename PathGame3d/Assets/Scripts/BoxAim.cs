using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAim : MonoBehaviour
{
    [SerializeField] float fruitShootingForce = 450;

    public bool isTouching = false;
    Vector3Int coordinates = new Vector3Int();

    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * fruitShootingForce);
        
        if (isTouching == true)
        {
            coordinates.x = Mathf.RoundToInt(transform.position.x );
            coordinates.z = Mathf.RoundToInt(transform.position.z );
            coordinates.y = Mathf.RoundToInt(transform.position.y );
            
            transform.position = coordinates;            
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        isTouching = true;
    }
    
    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isTouching = false;
        }
    }
}
