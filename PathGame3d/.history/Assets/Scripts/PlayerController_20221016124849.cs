using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (SphereCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {

        
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * -moveSpeed);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.Log("horizontal" + joystick.Horizontal + "vertical" + joystick.Vertical);
        

    }
}
