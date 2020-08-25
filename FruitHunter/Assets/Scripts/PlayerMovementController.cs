using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed;
    private float horizontalMove;
    public float jumpForce;

    private Animator playerAnimator;
    private Rigidbody2D rb;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask ground;

    private bool isJump;

    public AudioSource audioSource;
    public AudioClip pickUpFruit;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));
        Flip();
        IsLanding();

        if (Input.GetButton("Jump") && isJump)
        {
            playerAnimator.SetBool("IsJump", true);
        }

        if (!isJump)
            playerAnimator.SetBool("IsJump", false);

    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 0)
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetButton("Jump") && !isJump)
            rb.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxisRaw("Horizontal") == -1)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void IsLanding()
    {
        Collider2D[] touches = Physics2D.OverlapCircleAll(groundChecker.position, groundCheckerRadius, ground);

        if (touches.Length == 0)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            audioSource.PlayOneShot(pickUpFruit);
        }
    }
}
