using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLastScene : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
    }
}
