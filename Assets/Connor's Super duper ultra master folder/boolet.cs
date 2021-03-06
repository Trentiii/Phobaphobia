using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolet : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Enemy;
    public Patrolpartdeux Patrol;
    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject Enemy = GameObject.Find("Enemy Variant");
        Patrol = Enemy.GetComponent<Patrolpartdeux>();
    }

    // Start is called before the first frame update  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Patrol.movingright == true)
        {
            rb.AddForce(new Vector2(15f * 25f, 0f * 25f));
        }
        if (Patrol.movingright == false)
        {
            rb.AddForce(new Vector2(-15f * 25f, 0f * 25f));
        }
        lastVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);

        if (coll.gameObject.CompareTag("testingboolet"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (trigg.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }







}
