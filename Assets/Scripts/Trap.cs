using UnityEngine;
using UnityEngine.SceneManagement;  // Untuk memuat ulang scene

public class Trap : MonoBehaviour
{
    // Saat karakter memasuki area lava
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang terkena lava adalah player
        if (other.CompareTag("Player"))
        {
            // Jika terkena lava, restart scene
            RestartGame();
        }
    }

    // Fungsi untuk restart game
    private void RestartGame()
    {
        // Memuat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
