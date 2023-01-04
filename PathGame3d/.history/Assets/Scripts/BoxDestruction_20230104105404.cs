using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "RedFruit")
        {
            this.GetComponent<SnapBox>().enabled = false;
            Debug.Log("Hit by red fruit");
        }
    }
}
