using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof (SphereCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, 0, joystick.Vertical * moveSpeed);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            //Debug.Log(joystick.Horizontal + joystick.Vertical);
        }

    }
}
