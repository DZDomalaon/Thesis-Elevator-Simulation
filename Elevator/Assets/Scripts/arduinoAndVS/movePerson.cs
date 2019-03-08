using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class movePerson : MonoBehaviour
{

    public float speed = 4;
    public float rotSpeed = 20;
    public float rot = 0f;
    public float gravity = 20.0f;
    Animator anim;

    Vector3 moveDir = Vector3.zero;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            if(Input.GetKey (KeyCode.W))
            {
                anim.SetInteger("condition", 1);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
            }            
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}