using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeToNextSceneTwo : MonoBehaviour
{
    public TextMeshProUGUI interactionPrompt;
    public int sceneNameToLoad = 3;
    public KeyCode interactionKey = KeyCode.E;
    public GameObject keyObject;
    public IntroductionText introductionText;
    public string[] noKeySentences;

    private bool canChangeScene = false;
    private bool isInteracting = false;
    private bool hasKey = false;

    private void Start()
    {
        if (keyObject == null)
        {
            keyObject = GameObject.FindGameObjectWithTag("Key");
        }
    }
    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowInteractionPrompt("Press 'E' to interact");
            canChangeScene = true;
        }
        else if (other.gameObject == keyObject)
        {
            hasKey = true;
            keyObject.SetActive(false);
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
                if (hasKey)
                {
                    StartCoroutine(ChangeSceneRoutine());
                }
                else
                {
                    introductionText.gameObject.SetActive(true);
                    introductionText.ShowText(noKeySentences, 5f);
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