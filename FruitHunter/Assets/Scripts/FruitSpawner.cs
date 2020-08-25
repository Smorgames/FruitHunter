using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] differentFruits;
    private GameObject fruitPrefab;

    public float shootRate;
    private float nextShoot;
    public float nextShootValue;

    private void Start()
    {
        nextShoot = nextShootValue;
    }

    void Update()
    {
        if (Time.time > nextShoot)
        {
            fruitPrefab = differentFruits[Random.Range(0, 8)];
            Instantiate(fruitPrefab, new Vector3(Random.Range(-9.0f, 6.3f), transform.position.y, transform.position.z), Quaternion.identity);
            nextShoot = Time.time + shootRate;
        }
    }
}
