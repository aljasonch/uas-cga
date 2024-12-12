using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject gameOverCanvas; // Referensi ke Canvas Game Over

    // Saat karakter memasuki area lava
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang terkena lava adalah player
        if (other.CompareTag("Player"))
        {
            // Jika terkena lava, tampilkan Game Over
            ShowGameOver();
        }
    }

    // Fungsi untuk menampilkan Canvas Game Over
    private void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // Aktifkan Canvas Game Over
        }

        // Opsional: Hentikan waktu
        Time.timeScale = 0f; // Pause permainan
    }

    // Opsional: Fungsi untuk mereset permainan
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume waktu
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Ganti dengan nama/ID scene Anda
    }
}
