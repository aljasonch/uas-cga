using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string lastScene = PlayerPrefs.GetString("LastScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("LastScene");
        Debug.Log("Progress has been reset");
    }
}
