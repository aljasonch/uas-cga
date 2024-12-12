using UnityEngine;

public class BookPickUp : MonoBehaviour
{
    private ChangeToFinalScene changeSceneScript; // Tambahkan ini
    
    void Start()
    {
        changeSceneScript = FindObjectOfType<ChangeToFinalScene>(); // Inisialisasi di Start
        if (changeSceneScript == null)
        {
            Debug.LogError("ChangeToFinalScene script not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set hasMoney menjadi true di script ChangeToNextScene
            if (changeSceneScript != null)
            {
                changeSceneScript.SetHasBook(true);
            }

            // Hancurkan object uang
            Destroy(gameObject);
        }
    }
}