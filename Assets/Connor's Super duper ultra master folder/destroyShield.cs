using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyShield : MonoBehaviour
{
    public bool shieldout = false;
    public float cooldownTime = 2f;
    private float nextshieldTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextshieldTime)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                endShield();
                nextshieldTime = Time.time + cooldownTime;
            }
        }
    }

    void endShield()
    {
        shieldout = false;
        Destroy(gameObject);
    }

}
