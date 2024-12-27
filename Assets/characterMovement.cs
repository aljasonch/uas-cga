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
        // Declare inputDirection outside of the if block
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (ChrController.isGrounded)
        {
            anim.SetBool("isJumping", false);

            // Horizontal and Vertical movement in local space
            moveDirection = transform.TransformDirection(inputDirection); // Convert to world space

            // Apply speed
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
            // While airborne, maintain horizontal input but still in world space
            moveDirection.x = transform.TransformDirection(inputDirection).x * speed;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character controller
        ChrController.Move(moveDirection * Time.deltaTime);

        // Handle rotation for facing movement direction
        if (inputDirection.x != 0 || inputDirection.z != 0)
        {
            anim.SetBool("isRunning", true);

            // Face the movement direction
            Vector3 lookDirection = new Vector3(inputDirection.x, 0, inputDirection.z);
            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            // Set animation based on movement direction
            if (inputDirection.x < 0) // Moving Left
            {
                anim.SetBool("isWalkingLeft", true);
                anim.SetBool("isWalkingRight", false);
            }
            else if (inputDirection.x > 0) // Moving Right
            {
                anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isWalkingRight", true);
            }
            else // Not moving horizontally
            {
                anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isWalkingRight", false);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            // Reset animation if no movement
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
        }
    }
}
