using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountOfScoreChanger : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private GameObject player;
    private PlayerScoreSystem playerScoreSystem;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScoreSystem = player.GetComponent<PlayerScoreSystem>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "PlayerScoreIndicator")
        {
            transform.position = player.transform.position - new Vector3(0.3f, 0.98f, 1.0f);
            textMesh.text = playerScoreSystem.ScoreDisplay().ToString();
        }
    }
}
