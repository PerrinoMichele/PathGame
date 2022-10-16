using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CameraFollow : MonoBehaviour {
      public GameObject player;
      public float cameraHeight = 20.0f;
  
      void Update() {
          Vector3 pos = player.transform.position;
          pos.y += cameraHeight;
          pos.z -= 15;
          transform.position = pos;
          //60gradi; -15 z; 20 y
          //90gradi; 30y
      }
}