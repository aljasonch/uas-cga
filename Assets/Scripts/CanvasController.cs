using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
public void RestartGame()
{
    Time.timeScale = 1f; // Resume waktu
    Debug.Log("Time resumed: " + Time.timeScale); // Debug log untuk pengecekan

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
}

}
