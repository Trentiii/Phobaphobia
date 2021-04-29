using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingmovement : MonoBehaviour
{
    public float speed;
    public float startingSpeed;
    public float shieldSpeed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    public bool Turned = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;
    
    public Shield script;

    
    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        

    }

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
        }
        if (script.shieldout == false)
        {
            speed = startingSpeed;
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

    private void Flip()
    {
        Turned = !Turned;

        transform.Rotate(0f, 180f, 0f);

    }


}