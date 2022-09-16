using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed;
    public float gravity = -9.81f;
    public float groundDis = 0.4f;
    public float jumpHeight = 3f;
    
    public CharacterController controller;
    public Transform groundCheck;
    public Transform player;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);

        if(isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(player.position.y < -1f)
        {
            FindObjectOfType<GameManager>().Endgame();
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime); 

        velocity.y += gravity * Time.deltaTime;
    }
}
