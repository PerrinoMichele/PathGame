using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBox : MonoBehaviour
{
    void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Box touching ground");
        }
    }
}
