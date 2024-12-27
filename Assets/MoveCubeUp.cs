using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeUp : MonoBehaviour
{
    public float speed = 2f; // Kecepatan gerak balok
    public float distance = 3f; // Jarak maksimum gerak balok dari posisi awal

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        // Menyimpan posisi awal balok
        startPosition = transform.position;
    }

    void Update()
    {
        // Menghitung posisi target
        Vector3 targetPosition = startPosition + (movingUp ? Vector3.up : -Vector3.up) * distance;

        // Gerakkan balok ke arah target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Periksa jika balok sudah mencapai target
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Balik arah gerak
            movingUp = !movingUp;
        }
    }
}
