using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    GameObject Player;

    public float FollowSpeed = 10; // Mengatur follow speed menjadi 10
    public float xOffset;
    public float yOffset;

    private Vector3 Target;

    // Nilai zoom tetap
    private const float ZoomPosition = -49.5f;

    void Start()
    {
        Player = FindObjectOfType<characterMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Set posisi target kamera
        Target = new Vector3(
            Player.transform.position.x + xOffset, 
            Player.transform.position.y + yOffset, 
            ZoomPosition // Zoom tetap di posisi -49.5
        );

        // Gerakkan kamera menuju target dengan Lerp
        transform.position = Vector3.Lerp(transform.position, Target, FollowSpeed * Time.deltaTime);
    }
}
