using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreSystem : MonoBehaviour
{
    private int score;

    public GameObject splashEffect;
    private GameObject doubleScalesplashEffect;

    public GameObject restartTable;
    private Animator restartTableAnimator;

    public GameObject scoreText;
    public GameObject highscoreText;

    public GameObject miniPauseButton;

    public AudioSource audioSource;
    public AudioClip deathSound;

    private void Start()
    {
        restartTableAnimator = restartTable.GetComponent<Animator>();
        doubleScalesplashEffect = splashEffect;
        doubleScalesplashEffect.transform.localScale = new Vector3(2.5f, 2.5f, -3.0f);
        score = 0;
    }

    public void ScoreUpdate(int amountOfPoint)
    {
        score += amountOfPoint;
    }

    public int ScoreDisplay()
    {
        return score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        audioSource.PlayOneShot(deathSound);
        miniPauseButton.SetActive(false);
        if (PlayerPrefs.GetInt("Highscore") <= score)
            PlayerPrefs.SetInt("Highscore", score);

        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        highscoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Highscore").ToString();

        Destroy(gameObject, 1);
        Instantiate(doubleScalesplashEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0001f;
        restartTableAnimator.SetBool("IsAppear", true);
        yield return new WaitForSeconds(0.00025f);
        Time.timeScale = 0f;
        Instantiate(doubleScalesplashEffect, transform.position, Quaternion.identity);
    }
}
