using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class movePerson : MonoBehaviour
{

    public float speed;
    //public float rot = 0F;
    //public float gravity = 8;
    //public float rotateSpeed = 80;

    //private Vector3 moveDirection = Vector3.zero;
    //CharacterController controller;
    //Animator anim;
    // Use this for initialization
    void Start()
    {
        speed = 7f;
        //controller = GetComponent<CharacterController>();
       // anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        //Debug.Log(controller.isGrounded);
        //if (controller.isGrounded)
        //{
        //    if(Input.GetKey(KeyCode.W))
        //    {
        //       // anim.SetInteger("Condition", 1);
        //        moveDirection = new Vector3(0, 0, 1);
        //        moveDirection *= speed;
        //        moveDirection = transform.TransformDirection(moveDirection);
        //    }
            
        //    if(Input.GetKeyUp(KeyCode.W))
        //    {
        //        //anim.SetInteger("Condition", 0);
        //        moveDirection = new Vector3(0, 0, 0);
        //    }
        //}
        //rot += Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime; ;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        //moveDirection.y -= gravity * Time.deltaTime;
        //controller.Move(moveDirection * Time.deltaTime);  
    }
}