using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private ChangeToNextSceneTwo changeSceneScript;

    void Start()
    {
        changeSceneScript = FindObjectOfType<ChangeToNextSceneTwo>(); 
        if (changeSceneScript == null)
        {
            Debug.LogError("ChangeToFinalScene script not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (changeSceneScript != null)
            {
                changeSceneScript.SetHasKey(true);
            }

            // Hancurkan object key
            Destroy(gameObject);
        }
    }
}