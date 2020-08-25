using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject highscoreText;
    public GameObject miniPauseButton;

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("FruitHunter");
        miniPauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ToPlay()
    {
        SceneManager.LoadScene("FruitHunter");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NullifyHighscore()
    {
        highscoreText.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        PlayerPrefs.SetInt("Highscore", 0);
    }
}
