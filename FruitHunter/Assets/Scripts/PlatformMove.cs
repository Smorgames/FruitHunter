using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;

    public Transform point_one, point_two;

    private bool canMove = true;

    private void FixedUpdate()
    {
        if (transform.position.y != point_one.position.y && canMove)
            transform.position = Vector3.MoveTowards(transform.position, point_one.position, Time.fixedDeltaTime * speed);
        if (transform.position.y == point_one.position.y)
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        canMove = false;
        Vector3 variable = new Vector3(0, 0, 0);
        variable = point_one.position;
        point_one.position = point_two.position;
        point_two.position = variable;
        yield return new WaitForSeconds(1);
        canMove = true;
    }
}
