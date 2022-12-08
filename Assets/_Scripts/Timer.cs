using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timerText;
    public GameObject GameOverCanvas;
    public GameObject pauseButton;

    private Main main;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        GameOverCanvas.SetActive(false);
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                int scoreee = Mathf.FloorToInt(main.levelScore.value);
                PlayerPrefs.SetInt("HighScore", scoreee);
                timeRemaining = 0;
                timerIsRunning = false;

                Time.timeScale = 0;
                pauseButton.SetActive(false);
                GameOverCanvas.SetActive(true);
            }
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
