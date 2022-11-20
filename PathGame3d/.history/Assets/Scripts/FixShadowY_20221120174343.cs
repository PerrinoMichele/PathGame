using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixShadowY : MonoBehaviour
{
    public GameObject shadowCaster;
    public float shadowY = 0.2f;
    
    void Update() {
        Vector3 pos = shadowCaster.transform.position;
        pos.y = shadowY;
        
        transform.position = pos;
    }
}
