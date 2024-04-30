using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI instructionsText;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return StartCoroutine(Countdown(3));
        instructionsText.text = "Swipe left to go left.\nSwipe right to go right.\nDo not let the score reach below zero.";
        yield return new WaitForSeconds(2);
        instructionsText.gameObject.SetActive(false);
        // Add any other initialization logic or start your main game logic here.
    }

    IEnumerator Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
    }
}
