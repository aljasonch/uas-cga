using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class NotificationAnimation : MonoBehaviour
{
    public TextMeshProUGUI notificationText;
    public float moveSpeed = 500f;
    public float pauseDuration = 1f;
    public string notificationMessage = "Stage 1"; // Pesan notifikasi default

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 centerPosition;
    private Vector2 endPosition;

    private bool isAnimating = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Hitung posisi awal (di luar layar kiri)
        float screenWidth = Screen.width;
        CanvasScaler canvasScaler = GetComponentInParent<CanvasScaler>();
        float scaleFactor = canvasScaler != null ? canvasScaler.scaleFactor : 1f;

        // Perhitungan posisi dengan memperhitungkan ukuran elemen (rectTransform.rect.width)
        startPosition = new Vector2(-screenWidth / scaleFactor - rectTransform.rect.width, rectTransform.anchoredPosition.y);

        // Ambil posisi tengah langsung dari posisi X elemen di editor
        centerPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);

        // Posisi akhir (di luar layar kanan, lebih jauh agar benar-benar hilang)
        endPosition = new Vector2(screenWidth / scaleFactor + rectTransform.rect.width, rectTransform.anchoredPosition.y);

        // Debugging untuk memeriksa posisi
        Debug.Log($"StartPosition: {startPosition}, CenterPosition: {centerPosition}, EndPosition: {endPosition}");

        // Set posisi awal
        rectTransform.anchoredPosition = startPosition;
    }

    void Start()
    {
        // Dapatkan nama scene yang aktif
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Atur pesan notifikasi berdasarkan nama scene
        switch (currentSceneName)
        {
            case "Scene 1": // Ganti "SceneName1" dengan nama scene kamu
                notificationMessage = "Stage 1";
                break;
            case "Scene 2": // Ganti "SceneName2" dengan nama scene kamu
                notificationMessage = "Stage 2";
                break;
            case "Scene 3": 
                notificationMessage = "Last Stage";
                break;
            // Tambahkan case lain sesuai kebutuhan
            default:
                // Pesan default jika nama scene tidak cocok dengan case di atas
                break;
        }

        // Mulai animasi notifikasi secara otomatis saat scene dimulai
        ShowNotification(notificationMessage);
    }

    public void ShowNotification(string message)
    {
        if (!isAnimating)
        {
            notificationText.text = message;
            StartCoroutine(AnimateNotification());
        }
    }

    IEnumerator AnimateNotification()
    {
        isAnimating = true;
        rectTransform.anchoredPosition = startPosition;

        Debug.Log($"Animating from StartPosition: {startPosition}");

        // Bergerak ke tengah
        while (Vector2.Distance(rectTransform.anchoredPosition, centerPosition) > 0.1f) // Toleransi kecil
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, centerPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        rectTransform.anchoredPosition = centerPosition; // Paksa posisi
        Debug.Log($"Reached CenterPosition: {centerPosition}");

        // Jeda
        yield return new WaitForSeconds(pauseDuration);

        // Bergerak ke kanan
        while (Vector2.Distance(rectTransform.anchoredPosition, endPosition) > 0.1f) // Toleransi kecil
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, endPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        rectTransform.anchoredPosition = endPosition; // Paksa posisi
        Debug.Log($"Reached EndPosition: {endPosition}");

        // Hancurkan objek setelah animasi selesai
        Destroy(gameObject);
        Debug.Log("Notification destroyed!");
        isAnimating = false;
    }
}