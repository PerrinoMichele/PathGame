using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject fruitPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(fruitPrefab, new Vector3(0,0,0), Quaternion.identity);
            Debug.Log("Shoot");
        }
    }
}
