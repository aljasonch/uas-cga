using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMovement : MonoBehaviour
{
    CharacterController ChrController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float verticalSpeed = 3.0f; // New variable for vertical speed
    Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    void Start()
    {
        ChrController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (ChrController.isGrounded)
        {
            anim.SetBool("isJumping", false);
            // Horizontal and Vertical movement
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Add vertical input for Z-axis
            moveDirection *= speed;
            // Jumping (Y-axis movement)
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("isJumping", true);
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.x = Input.GetAxis("Horizontal") * speed;
        }
        // Animation and running state
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("isRunning", true);
            Vector3 moveDirectionXZ = new Vector3(-moveDirection.z, 0, moveDirection.x); // Membuat vektor baru tanpa komponen Y
            Quaternion targetRotation = Quaternion.LookRotation(-moveDirectionXZ); // Membalik arah rotasi
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        // Apply gravity and vertical movement
        moveDirection.y -= gravity * Time.deltaTime;
        // For vertical control, you could also allow movement along the y-axis if needed
        moveDirection.y += Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime; // Adjust vertical movement based on player input
        // Move the character controller
        ChrController.Move(moveDirection * Time.deltaTime);
    }
}