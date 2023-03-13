using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Unity.Netcode;


public class GunController : NetworkBehaviour
{

    SpriteRenderer sprite;
    public int rotationOffset;

    public FixedJoystick joystickRotation;

    public GameObject bullet;
    public Transform spawnbullet;
    public FixedJoystick ainJoystick;
    public Button Fire;


    public float timeLeft = 2f;
    public bool buttonActive = true;
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

        if (!buttonActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                button.interactable = true;
                buttonActive = true;
                timeLeft = 2f;
            }
        }

    }

    public void Disable()
    {
        if (buttonActive)
        {
            button.interactable = false;
            buttonActive = false;
        }
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
        if(!IsOwner) return;
        ShootServerRpc();

         
    }

    [ServerRpc]
    private void ShootServerRpc()
    {
        GameObject go =  Instantiate(bullet, spawnbullet.position, transform.rotation);
           go.GetComponent<NetworkObject>().Spawn();
        
    }

}
