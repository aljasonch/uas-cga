using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    GameObject Player;

    public float FollowSpeed = 10f; // Adjust follow speed
    private float xOffset; // Offset along X-axis
    private float yOffset; // Offset along Y-axis
    private float zOffset; // Offset along Z-axis

    private Vector3 Target;

    void Start()
    {
        Player = FindObjectOfType<characterMovement>().gameObject;

        // Calculate initial offsets based on the manually set camera position
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = Player.transform.position;

        xOffset = cameraPosition.x - playerPosition.x;
        yOffset = cameraPosition.y - playerPosition.y;
        zOffset = cameraPosition.z - playerPosition.z;
    }

    void Update()
    {
        if (Player != null)
        {
            // Set target position based on the player’s position and offsets
            Target = new Vector3(
                Player.transform.position.x + xOffset,
                Player.transform.position.y + yOffset,
                Player.transform.position.z + zOffset
            );

            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, Target, FollowSpeed * Time.deltaTime);
        }
    }
}
