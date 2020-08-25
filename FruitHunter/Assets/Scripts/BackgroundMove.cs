using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);

        if (transform.position.y <= -19.2f)
            transform.position = new Vector3(-1.5f, 19.15f, 1);
    }
}
