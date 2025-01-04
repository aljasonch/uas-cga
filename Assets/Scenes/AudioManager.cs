using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip musicScene1;
    public AudioClip musicScene2;
    public AudioClip musicScene3;
    public AudioClip musicScene4;
    private AudioSource audioSource;
    private static AudioManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe ke event scene loaded
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe saat GameObject dihancurkan
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
    }

    public void PlayMusicForScene(int sceneIndex)
    {
        if (audioSource == null) return;

        switch (sceneIndex)
        {
            case 0:
                if (musicScene1 != null)
                {
                    audioSource.clip = musicScene1;
                    audioSource.Play();
                }
                break;
            case 1:
                if (musicScene2 != null)
                {
                    audioSource.clip = musicScene2;
                    audioSource.Play();
                }
                break;
            case 2:
                if (musicScene3 != null)
                {
                    audioSource.clip = musicScene3;
                    audioSource.Play();
                }
                break;
            case 3:
                if (musicScene4 != null)
                {
                    audioSource.clip = musicScene4;
                    audioSource.Play();
                }
                break;
            // Tambahkan case lain untuk scene-scene lain jika diperlukan
            default:
                audioSource.Stop(); // Hentikan musik jika tidak ada musik spesifik untuk scene ini
                break;
        }
    }
}