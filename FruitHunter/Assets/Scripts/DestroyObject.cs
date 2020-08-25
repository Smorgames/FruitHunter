using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float timeToDeath;

    private void Start()
    {
        Destroy(gameObject, timeToDeath);
    }
}
