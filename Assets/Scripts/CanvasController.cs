using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
public void RestartGame()
{
    Time.timeScale = 1f; 
    Debug.Log("Time resumed: " + Time.timeScale); 

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
}

}
