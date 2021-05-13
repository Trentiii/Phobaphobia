using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clownBoolet : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.AddForce(new Vector2(-15f * 25f, 0f * 25f));
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
