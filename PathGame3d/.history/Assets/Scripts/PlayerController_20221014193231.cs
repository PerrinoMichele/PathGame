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
        if (!TouchScreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("no press");
            return;
        }
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, 0, joystick.Vertical * -moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.Log(joystick.Horizontal + joystick.Vertical);
        }
    }
}
