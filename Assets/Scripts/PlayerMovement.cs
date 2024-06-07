using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public CharacterController controller;
    public float gravity = -9.81f;
    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    public float jumpHeight = 5;
    private bool isGround;
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0;
        }
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 move = transform.right * xInput + transform.forward * yInput;
        controller.Move(moveSpeed * move * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
