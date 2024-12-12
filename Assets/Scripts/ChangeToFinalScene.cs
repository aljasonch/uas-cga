using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeToFinalScene : MonoBehaviour
{
    public TextMeshProUGUI interactionPrompt;
    public int sceneNameToLoad = 0; // Mengubah scene menjadi 3
    public KeyCode interactionKey = KeyCode.E;
    public GameObject bookObject; // Mengganti Money menjadi Book
    public IntroductionText introductionText;
    public string[] noBookSentences; // Mengganti noMoneySentences menjadi noBookSentences

    private bool canChangeScene = false;
    private bool isInteracting = false;
    private bool hasBook = false; // Mengganti hasMoney menjadi hasBook

    private void Start()
    {
        if (bookObject == null) // Mengganti moneyObject menjadi bookObject
        {
            bookObject = GameObject.FindGameObjectWithTag("Book"); // Mengganti tag "Money" menjadi "Book"
        }
    }

    public void SetHasBook(bool value) 
    {
        hasBook = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowInteractionPrompt("Press 'E' to Finish");
            canChangeScene = true;
        }
        else if (other.gameObject == bookObject) 
        {
            hasBook = true; 
            bookObject.SetActive(false); 
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
                if (hasBook) 
                {
                    StartCoroutine(ChangeSceneRoutine());
                }
                else
                {
                    introductionText.gameObject.SetActive(true);
                    introductionText.ShowText(noBookSentences, 5f); 
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
            interactionPrompt.gameObject.SetActive(true);
            interactionPrompt.text = message;
        }
    }

    void HideInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false);
        }
    }
}