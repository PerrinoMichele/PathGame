using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CameraFollow : MonoBehaviour {
      public GameObject player;
      public float cameraHeight = 30f;
      public float cameraZ = 5;
      public float cameraX = 5;
  
      void Update() {
          Vector3 pos = player.transform.position;
          pos.y += cameraHeight;
          pos.z -= cameraZ;
          pos.x -= cameraX;
          transform.position = pos;
          //70gradix; 5z; 30y
          //60gradix; -15 z; 20 y
          //90gradix; 30y
          //60gradix; 32y; 12z
          //60gradix; 45gradiy; 32y; 10x; 10y
      }
}