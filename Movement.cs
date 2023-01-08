using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController CharController;
    public float WalkSpeed = 2.5f;
    public float Speed = 5f;
    public float JumpSpeed = 5f;
    public float RotationSpeed = 200f;
    public float Gravity = 15f;
    public Transform Camera;

    public bool Grounded;

    Vector3 moveVelocity;
    Vector3 turnVelocity;

    private Transform tf;
    private float turn = 0;

    void Start()
    {
        tf = transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(Grounded)
        {
            moveVelocity = new Vector3(hInput, 0, vInput).normalized;
            

            if(Input.GetKey(KeyCode.LeftShift)) 
            { 
                moveVelocity *= Speed;
            }
            else
            {
                moveVelocity *= WalkSpeed;
            }


            moveVelocity = tf.TransformDirection(moveVelocity);

            if(Input.GetButton("Jump"))
            {
                moveVelocity.y = JumpSpeed;
            }
        }

        turnVelocity = tf.up * RotationSpeed * mouseX;


        moveVelocity.y -= Gravity * Time.deltaTime;

        CharController.Move(moveVelocity*Time.deltaTime);

        tf.Rotate(turnVelocity*Time.deltaTime);

        turn += mouseY;
        
        turn = Mathf.Clamp(turn, -50, 30);

        Camera.localRotation = Quaternion.Euler(-turn, 0, 0);
        //Camera.Rotate(Camera.right * mouseY * RotationSpeed * Time.deltaTime, Space.Self);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Grounded = CharController.isGrounded;


    }







}
