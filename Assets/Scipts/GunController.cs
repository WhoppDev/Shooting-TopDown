using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    SpriteRenderer sprite;
    public int rotationOffset;

    public FixedJoystick joystickRotation;

    public GameObject bullet;
    public Transform spawnbullet;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    void Aim()
    {
        Vector3 moveVector = (Vector3.up * joystickRotation.Horizontal + Vector3.left * joystickRotation.Vertical);
        if (joystickRotation.Horizontal != 0 || joystickRotation.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }

        sprite.flipY = (joystickRotation.Horizontal < joystickRotation.Vertical);
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bullet, spawnbullet.position, transform.rotation);
        }
    }

}
