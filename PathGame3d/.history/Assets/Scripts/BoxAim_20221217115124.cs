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
    }

    void OnTriggerEnter(Collider other) 
    {
        isTouching = true;
    }
    
    void OnTriggerExit(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isTouching = false;
        }
    }
}
