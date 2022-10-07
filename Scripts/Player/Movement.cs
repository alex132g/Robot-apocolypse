using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IDataPersistence
{

    public float moveSpeed = 8f;
    public float gravity = -9.81f;
    public float groundDis = 0.4f;
    public float jumpHeight = 2f;
    public float jumpStaminaUsed = 4f;
    
    public CharacterController controller;

    public Transform groundCheck;
    public Transform player;
    public Transform playerGfx;
    public Transform spawnPoint;

    public LayerMask groundMask;

    public StaminaBar stamina;

    Vector3 velocity;

    public bool isGrounded = false;

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPos;
    }

    public void SaveData(GameData data)
    {
        data.playerPos = this.transform.position;
    }

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
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
            stamina.currentStamina -= jumpStaminaUsed;
        }

        if(isGrounded == false)
        {
            moveSpeed = 6f;
        }else
        {
            moveSpeed = 8f;
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
