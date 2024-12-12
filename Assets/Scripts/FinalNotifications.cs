using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNotifications : MonoBehaviour
{
    public IntroductionText introductionText;
    public string[] finalSentences;
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang terkena lava adalah player
        if (other.CompareTag("Player"))
        {
            // Jika terkena lava, tampilkan Game Over
            ShowFinalText();
        }
    }

    private void ShowFinalText()
    {
        introductionText.gameObject.SetActive(true);
        introductionText.ShowText(finalSentences, 5f);
    }

}
