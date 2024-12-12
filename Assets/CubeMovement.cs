using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan
    public float moveDistance = 3f; // Jarak gerakan dari posisi awal

    private Vector3 startPosition; // Posisi awal cube
    private bool movingRight = true; // Arah gerakan

    void Start()
    {
        // Simpan posisi awal cube
        startPosition = transform.position;
    }

    void Update()
    {
        // Periksa arah gerakan
        if (movingRight)
        {
            // Gerak ke kanan
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            // Berhenti jika sudah mencapai batas kanan
            if (transform.position.x >= startPosition.x + moveDistance)
                movingRight = false;
        }
        else
        {
            // Gerak ke kiri
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // Berhenti jika sudah mencapai batas kiri
            if (transform.position.x <= startPosition.x - moveDistance)
                movingRight = true;
        }
    }
}
