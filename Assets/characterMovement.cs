using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMovement : MonoBehaviour
{
    CharacterController ChrController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float verticalSpeed = 3.0f; 
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
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
            moveDirection *= speed;
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
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("isRunning", true);
            Vector3 moveDirectionXZ = new Vector3(-moveDirection.z, 0, moveDirection.x); 
            Quaternion targetRotation = Quaternion.LookRotation(-moveDirectionXZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.y += Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime; 
        ChrController.Move(moveDirection * Time.deltaTime);
    }
}