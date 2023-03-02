using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float fireSpeed;

    Vector2 moveInput;
    Animator anim;
    public FixedJoystick moveJoystick;
    public FixedJoystick ainJoystick;

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
    }
}
