using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeToNextScene : MonoBehaviour
{
    public TextMeshProUGUI interactionPrompt;
    public int sceneNameToLoad = 2;
    public KeyCode interactionKey = KeyCode.E;
    public GameObject moneyObject;
    public IntroductionText introductionText;
    public string[] noMoneySentences;

    private bool canChangeScene = false;
    private bool isInteracting = false;
    private bool hasMoney = false;

    private void Start()
    {
        if (moneyObject == null)
        {
            moneyObject = GameObject.FindGameObjectWithTag("Money");
        }
    }

    public void SetHasMoney(bool value)
    {
        hasMoney = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowInteractionPrompt("Press 'E' to interact");
            canChangeScene = true;
        }
        else if (other.gameObject == moneyObject)
        {
            hasMoney = true;
            moneyObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canChangeScene = false;
            HideInteractionPrompt();
        }
    }

    private void Update()
    {
        if (canChangeScene && !isInteracting)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                if (hasMoney)
                {
                    StartCoroutine(ChangeSceneRoutine());
                }
                else
                {
                    introductionText.gameObject.SetActive(true);
                    introductionText.ShowText(noMoneySentences, 5f);
                }
            }
        }
    }

    private IEnumerator ChangeSceneRoutine()
    {
        isInteracting = true;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }

        isInteracting = false;
    }
    void ShowInteractionPrompt(string message)
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(true); // Aktifkan game object text
            interactionPrompt.text = message;
        }
    }

    // Fungsi untuk menyembunyikan prompt interaksi
    void HideInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false); // Nonaktifkan game object text
        }
    }
}