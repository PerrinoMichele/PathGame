using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof (SphereCollider))]

public class PlayerController : MonoBehaviour
{
    public List<GameObject> ammo = new List<GameObject>();
    public GameObject redFruitPrefab;
    public GameObject yellowFruitPrefab;
    public GameObject boxPrefab;
    public GameObject currentThrowableObject;

    [SerializeField] float fruitShootingForce = 10;//make this accessible from other scripts
    [SerializeField] float timeBetweenShots;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            StopPlayer();
            if (timer >= timeBetweenShots)
            {
                Shoot();
            }
        }
        else
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void StopPlayer()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Shoot()
    {   
        if (ammo.Count > 0)
        {
            GameObject fruitShot = Instantiate(ammo[0], new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), Quaternion.identity);//make 1.2 a variable
            ammo.Remove(ammo[0]);
            fruitShot.GetComponent<Rigidbody>().AddForce(transform.forward * fruitShootingForce, ForceMode.VelocityChange); // forward should be something tweakable to try different shooting angles
            timer = 0;
        }
        else { return; }
    }

    void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "RedFruit") //&&ammo[ammo.length] not null
        {
            Destroy(other.gameObject);
            ammo.Add(redFruitPrefab);//only one
        }
        if (other.gameObject.tag == "YellowFruit") //&&ammo[ammo.length] not null
        {
            Destroy(other.gameObject);
            ammo.Add(yellowFruitPrefab);
        }
        if (other.gameObject.tag == "Box") //&&ammo[ammo.length] not null
        {
            Destroy(other.gameObject);
            ammo.Add(boxPrefab);
        }
    }
}
