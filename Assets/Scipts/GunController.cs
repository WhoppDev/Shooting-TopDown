using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    SpriteRenderer sprite;
    public int rotationOffset;

    public FixedJoystick joystickRotation;

    public GameObject bullet;
    public Transform spawnbullet;
    public FixedJoystick ainJoystick;
    public Button Fire;


    public GameObject gun;
    public Color buttonColor;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
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

    public void Shoot()
    {

            Instantiate(bullet, spawnbullet.position, transform.rotation);
    }

}
