using UnityEngine;

public class PushableCube : MonoBehaviour
{
    public float pushStrength = 5f; // Kekuatan dorongan

    private Rigidbody rb;

    void Start()
    {
        // Menambahkan Rigidbody ke objek jika belum ada
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Membekukan rotasi agar lebih stabil
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Membaca input dari pemain
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hitung arah dorongan
        Vector3 pushDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        // Terapkan gaya hanya jika ada input
        if (pushDirection.magnitude >= 0.1f)
        {
            rb.AddForce(pushDirection * pushStrength, ForceMode.Force);
        }
        else
        {
            // Membuat cube diam ketika tidak ada input
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
