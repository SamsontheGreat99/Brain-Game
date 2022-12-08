using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject show;
    public GameObject hide;
    public void PlayAgain(int i)
    {
        SceneManager.LoadScene(i);
        Time.timeScale = 1;
    }

    public void MainMenu(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ShowHighScore(GameObject Score)
    {

        Score.SetActive(true);
        show.SetActive(false);
        hide.SetActive(true);
    }
    public void HideHighScore(GameObject Score)
    {
        Score.SetActive(false);
        show.SetActive(true);
        hide.SetActive(false);
    }
}
