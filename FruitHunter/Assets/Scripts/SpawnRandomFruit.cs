using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomFruit : MonoBehaviour
{
    public float timeBetweenFruits;
    public GameObject randomFruitPrefab;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while(true)
        {
            Instantiate(randomFruitPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenFruits);
        }
    }
}
