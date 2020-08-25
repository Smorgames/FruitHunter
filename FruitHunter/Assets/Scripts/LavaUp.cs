using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaUp : MonoBehaviour
{
    public GameObject[] platforms;

    public AudioSource audioSource;
    public AudioClip splash;

    private void Update()
    {
        if (transform.position.y >= 4.7f)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(false);
            }
        }
    }

    public void LavaLevelRise()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            audioSource.PlayOneShot(splash);
        }
    }
}
