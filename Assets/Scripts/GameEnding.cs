using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public CanvasGroup exitBackgroundCanvasGroup;

    private float fadeDuration = 1f;

    private float timer;

    private bool isPlayerAtExit = false;

    private bool isPlayerCaught = false;

    public CanvasGroup caughtBackgroundCanvasGroup;

    public float displayImageDuration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Game Completed");
            //exitBackgroundCanvasGroup.alpha = 1f;

            isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    private void Update()
    {
        if (isPlayerAtExit == true)
        {
            timer += Time.deltaTime;
            //Debug.Log("Timer : " + timer);

            exitBackgroundCanvasGroup.alpha = timer / fadeDuration;

            if (timer > fadeDuration + displayImageDuration)
            {
                Application.Quit();
            }
        }

        if (isPlayerCaught == true)
        {
            timer += Time.deltaTime;
            caughtBackgroundCanvasGroup.alpha = timer / fadeDuration;

            if(timer > fadeDuration + displayImageDuration)
            {
                //¾À ´Ù½Ã ·Îµå
                SceneManager.LoadScene(0);
            }
        }
    }
}
