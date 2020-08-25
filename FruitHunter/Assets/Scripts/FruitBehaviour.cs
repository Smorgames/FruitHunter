using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    private GameObject player;
    private PlayerScoreSystem playerScoreSystem;

    public int amountOfAddingScore;

    public GameObject collectedEffectPrefab;
    public GameObject SplashEffectPrefab;

    private GameObject lava;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        lava = GameObject.FindWithTag("Lava");
        playerScoreSystem = player.GetComponent<PlayerScoreSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScoreSystem.ScoreUpdate(amountOfAddingScore);
            Instantiate(collectedEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Lava")
        {
            lava.GetComponent<LavaUp>().LavaLevelRise();
            Instantiate(SplashEffectPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
