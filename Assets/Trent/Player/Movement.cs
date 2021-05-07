using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private float startingSpeed;
    public float shieldSpeed;
    public float jumpForce;
    private float startingJumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    public bool Turned = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float launchForce;

    public Vector3 respawnPoint;

    public Transform keyFollowPoint;


    private int extraJumps;
    public int extraJumpsValue;

    public Shield script;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        startingSpeed = speed;
        startingJumpForce = jumpForce;
    }

    //Movement
    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    //Jump
    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (script.shieldout == true)
        {
            speed = shieldSpeed;
            jumpForce = 0f;
        }
        if (script.shieldout == false)
        {
            speed = startingSpeed;
            jumpForce = startingJumpForce;
        }
        if (Input.GetAxis("Horizontal") < 0 && !Turned)
        {
            Flip();
        }

        if (Input.GetAxis("Horizontal") > 0 && Turned)
        {
            Flip();
        }
    }

    void Flip()
    {
        Turned = !Turned;

        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Trampoline"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death")
        {
            transform.position = respawnPoint;
        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}