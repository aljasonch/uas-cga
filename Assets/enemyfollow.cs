using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referensi ke karakter pemain
    public float speed = 2f; // Kecepatan musuh
    public float killDistance = 1.5f; // Jarak minimum untuk membunuh pemain

    void Update()
    {
        if (player == null)
            return;

        // Menghitung arah ke pemain
        Vector3 direction = (player.position - transform.position).normalized;

        // Bergerak ke arah pemain
        transform.position += direction * speed * Time.deltaTime;

        // Memeriksa jarak dengan pemain
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < killDistance)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        // Logika untuk membunuh pemain
        Debug.Log("Player is dead!");
        // Bisa mengganti ini dengan transisi scene, animasi, atau efek lainnya
    }
}
