using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitForwardMove : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
}
