using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float waktuMulaiDefault = 60f;
    private float waktuSaatIni;
    private float waktuMulai;
    public TextMeshProUGUI tampilanTimer;
    public GameObject gameOverCanvas;

    private bool timerBerjalan = true;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "Scene 1":
                waktuMulai = 120f;
                break;
            case "Scene 2":
                waktuMulai = 75f;
                break;
            case "Scene 3":
                waktuMulai = 150f;
                break;
            default:
                waktuMulai = waktuMulaiDefault;
                break;
        }

        waktuSaatIni = waktuMulai;

        if (tampilanTimer == null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                tampilanTimer = canvas.GetComponentInChildren<TextMeshProUGUI>();
                if (tampilanTimer == null)
                {
                    Debug.LogError("Komponen TextMeshProUGUI untuk timer tidak ditemukan di dalam Canvas!");
                }
            }
            else
            {
                Debug.LogError("Tidak ada Canvas yang ditemukan di scene!");
            }
        }
    }

    void Update()
    {
        if (timerBerjalan)
        {
            if (waktuSaatIni > 0)
            {
                waktuSaatIni -= Time.deltaTime;
            }
            else
            {
                waktuSaatIni = 0;
                timerBerjalan = false;
                ShowGameOver();
            }
        }

        TampilkanWaktu();
    }

    void TampilkanWaktu()
    {
        if (tampilanTimer != null)
        {
            int menit = Mathf.FloorToInt(waktuSaatIni / 60);
            int detik = Mathf.FloorToInt(waktuSaatIni % 60);
            tampilanTimer.text = string.Format("{0:00}:{1:00}", menit, detik);
        }
        else
        {
            Debug.LogWarning("Komponen TextMeshProUGUI untuk timer tidak diatur!");
        }
    }

    private void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("Canvas Game Over tidak diatur pada skrip Timer!");
        }

        Time.timeScale = 0f;
    }

    public void HentikanTimer()
    {
        timerBerjalan = false;
    }

    public void LanjutkanTimer()
    {
        timerBerjalan = true;
    }
}