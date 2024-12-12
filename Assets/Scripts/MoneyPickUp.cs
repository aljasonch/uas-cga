using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{
    private ChangeToNextScene changeSceneScript; // Tambahkan ini
    
    void Start()
    {
        changeSceneScript = FindObjectOfType<ChangeToNextScene>(); // Inisialisasi di Start
        if (changeSceneScript == null)
        {
            Debug.LogError("ChangeToNextScene script not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set hasMoney menjadi true di script ChangeToNextScene
            if (changeSceneScript != null)
            {
                changeSceneScript.SetHasMoney(true);
            }

            // Hancurkan object uang
            Destroy(gameObject);
        }
    }
}