using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotator : MonoBehaviour
{
    public float rotationSpeed;
    private float var;

    public GameObject[] differentFruits;
    private GameObject fruitPrefab;
    public Transform shootPoint;
    public Transform shootPointVector;

    public float shootRate;
    private float nextShoot;
    public float nextShootValue;

    private Animator cannonAnimator;

    private void Start()
    {
        cannonAnimator = GetComponent<Animator>();
        nextShoot = nextShootValue;
    }

    void Update()
    {
        var += Time.deltaTime;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * Mathf.Sin(var));
        if (Time.time > nextShoot)
        {
            fruitPrefab = differentFruits[Random.Range(0, 8)];
            cannonAnimator.SetTrigger("Shoot");
            Instantiate(fruitPrefab, shootPoint.position, Quaternion.identity);
            nextShoot = Time.time + shootRate;
        }
    }

    public Vector2 ReturnDirectionVector()
    {
        return new Vector2(shootPointVector.position.x - shootPoint.position.x, shootPointVector.position.y - shootPoint.position.y);
    }
}
