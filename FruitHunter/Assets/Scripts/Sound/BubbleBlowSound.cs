using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlowSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bubbleBlow;

    private float bubbleBlowRate;
    private float nextBubbleFlow;

    void Update()
    {
        if (Time.time > nextBubbleFlow)
        {
            audioSource.PlayOneShot(bubbleBlow);
            bubbleBlowRate = Random.Range(2.0f, 5.0f);
            nextBubbleFlow = Time.time + bubbleBlowRate;
        }
    }
}
