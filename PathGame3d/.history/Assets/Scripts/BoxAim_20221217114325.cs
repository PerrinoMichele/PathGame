using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAim : MonoBehaviour
{
    [SerializeField] float fruitShootingForce = 450;
    
    void Update()
    {
    this.GetComponent<Rigidbody>().AddForce(transform.forward * fruitShootingForce);
    }
}
