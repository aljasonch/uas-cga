using System.Collections;
using UnityEngine;
using TMPro;

public class IntroductionText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float displayTime = 5f;
    public string[] sentences;
    public float typingSpeed = 0.05f;
    

    private void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            if (textMeshPro == null)
            {
                Debug.LogError("TextMeshProUGUI component not found!");
                return;
            }
        }
        textMeshPro.text = "";
        StartCoroutine(StartTyping());
    }

    public void ShowText(string[] sentencesToShow, float displayTimeOverride = 0f)
    {
        StopAllCoroutines();
        textMeshPro.text = "";

        sentences = sentencesToShow;
        if (displayTimeOverride > 0)
        {
            displayTime = displayTimeOverride;
        }
        
        StartCoroutine(StartTyping());
    }

    IEnumerator StartTyping()
    {
        foreach (string sentence in sentences)
        {
            yield return StartCoroutine(TypeSentence(sentence));
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        textMeshPro.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}