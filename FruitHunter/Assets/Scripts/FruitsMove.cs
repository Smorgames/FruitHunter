using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsMove : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    private float sinVariable;

    public Sprite[] fruitSprites;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = fruitSprites[Random.Range(0, 8)];
    }

    private void Update()
    {
        sinVariable += Time.deltaTime;
        transform.Translate(new Vector2(horizontalSpeed, Mathf.Sin(sinVariable) * verticalSpeed) * Time.deltaTime);

        if (transform.position.x >= 10)
            Destroy(gameObject);

        if (transform.position.x > -2.6f && transform.position.x < 0.9f || transform.position.x > 3.5f && transform.position.x < 7f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
}
