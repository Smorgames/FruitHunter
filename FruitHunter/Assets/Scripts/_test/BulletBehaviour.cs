using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float pushForce;

    private GameObject cannon;
    private GunRotator gunRotator;

    private Rigidbody2D rb;

    void Start()
    {
        cannon = GameObject.FindWithTag("Cannon");
        rb = GetComponent<Rigidbody2D>(); 
        Destroy(gameObject, 5);
        pushForce = Random.Range(2f, 3f);
        rb.AddForce(cannon.GetComponent<GunRotator>().ReturnDirectionVector() * pushForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
