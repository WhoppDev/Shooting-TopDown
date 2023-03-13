using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed;
    public float fireSpeed;

    Vector2 moveInput;
    Animator anim;
    public FixedJoystick moveJoystick;
    public FixedJoystick ainJoystick;

    public GameObject gun;

   // public override void OnNetworkSpawn(){
     //   if(!IsOwner){
      //      Destroy(this);
     //   }
   // }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = moveJoystick.Horizontal;
        moveInput.y = moveJoystick.Vertical;

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("isWalk", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(gun, transform.position, Quaternion.identity);
        }


    }

}
