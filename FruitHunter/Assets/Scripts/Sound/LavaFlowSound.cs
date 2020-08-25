using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFlowSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
