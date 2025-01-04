using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false; 

    void Update()
    {
        // Deteksi tombol ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Tampilkan menu
        Time.timeScale = 0f; // Hentikan waktu di game
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Keluar dari game
    }
}
