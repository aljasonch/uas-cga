using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Kecepatan rotasi (x, y, z)

    void Update()
    {
        // Rotasi objek berdasarkan waktu
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
