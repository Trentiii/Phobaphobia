using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    
    
    public float speed;
    private float startingSpeed;
    public float shieldSpeed;
    public float jumpForce;
    private float startingJumpForce;
    public float moveInput;



    public Animator animator;

    private Rigidbody2D rb;

    public bool Turned = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float launchForce;

    public Vector3 respawnPoint;

    public Transform keyFollowPoint;

    public Key followingKey;


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
        animator.SetBool("IsJumping", !isGrounded);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animator.SetFloat("FallingSpeed", (rb.velocity.y));
        if (rb.velocity.y < -0.1f)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false); 
        }
        else
        { 
            animator.SetBool("IsFalling", false);
        
        }

        //if (rb.velocity.y < 0)
        //{
        //    animator.Play("Fall_Player");
        //}

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
            animator.SetBool("IsJumping", true);
            
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

    public void OnLanding()
    {
       // animator.SetBool("IsJumping", false);
       // Debug.Log("CHANGING ANIMATOR STATE to IsJumping FALSE");
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
        Debug.Log(other.tag);
        if (other.tag == "testingboolet")
        {
            GetComponent<Player>().TakeDamage();
        }
        if (other.tag == "Enemy")
        {
            GetComponent<Player>().TakeDamage();
        }

        if (other.tag == "Death")
        {
            Debug.Log("Tagged with death");
            transform.position = respawnPoint;

            
            GetComponent<Player>().ResetHealth();
        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
            
            GetComponent<Player>().ResetHealth();
        }
    }
    public void BackToSpawn()
    {
        transform.position = respawnPoint;
    }

}