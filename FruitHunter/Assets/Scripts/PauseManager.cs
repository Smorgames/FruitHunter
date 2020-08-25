using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseTable;
    private Animator pauseTableAnimator;

    private bool isPaused = false;

    private GameObject player;
    private PlayerMovementController playerMovementController;

    public GameObject miniPauseButton;

    public GameObject continueButton;
    public GameObject toMenuButton;
    private Button continueButtonComponent;
    private Button toMenuButtonComponent;

    private void Start()
    {
        continueButtonComponent = continueButton.GetComponent<Button>();
        toMenuButtonComponent = toMenuButton.GetComponent<Button>();
        pauseTableAnimator = pauseTable.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerMovementController = player.GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
            PauseOn();
    }

    public void PauseOn()
    {
        StartCoroutine(PauseOnCoroutine());
    }


    public void PauseOff()
    {
        StartCoroutine(PauseOffCoroutine());
    }

    IEnumerator PauseOnCoroutine()
    {
        isPaused = true;
        playerMovementController.enabled = false;
        miniPauseButton.SetActive(false);
        Time.timeScale = 0.0001f;
        continueButtonComponent.enabled = false;
        toMenuButtonComponent.enabled = false;
        pauseTableAnimator.SetBool("IsAppear", true);
        yield return new WaitForSeconds(0.0002f);
        continueButtonComponent.enabled = true;
        toMenuButtonComponent.enabled = true;
        Time.timeScale = 0;
    }

    IEnumerator PauseOffCoroutine()
    {
        playerMovementController.enabled = true;
        Time.timeScale = 0.0001f;
        continueButtonComponent.enabled = false;
        toMenuButtonComponent.enabled = false;
        pauseTableAnimator.SetBool("IsAppear", false);
        yield return new WaitForSeconds(0.0002f);
        miniPauseButton.SetActive(true);
        continueButtonComponent.enabled = true;
        toMenuButtonComponent.enabled = true;
        Time.timeScale = 1;
        isPaused = false;
    }

}
