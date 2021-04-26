using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform shieldpoint;
    public GameObject shieldprototype;
    public bool shieldout = false;
    private bool facingRight = false;
    public float cooldownTime = 2;
    private float nextshieldTime = 0;
    private float killShield = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextshieldTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                startShield();
                nextshieldTime = Time.time + cooldownTime;
            }

        }
        if (Input.GetButtonUp("Fire1"))
        {
            endShield();
            nextshieldTime = Time.time + cooldownTime;
        }


    }


    void startShield()
    {
        //Instantiate(shieldprototype, shieldpoint.position, shieldpoint.rotation);
        GameObject go = Instantiate(shieldprototype, shieldpoint.position, shieldpoint.rotation);
        go.transform.parent = GameObject.Find("shieldpoint").transform;
        shieldout = true;
    }
    void endShield()
    {
            shieldout = false;
            Destroy(shieldprototype);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
