using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void Start()
    {
        transform.position = spawnPoints[Random.Range(0, 8)].position;
    }
}
