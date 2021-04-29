using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testforreasons : MonoBehaviour
{

    public float cooldownTime = 2;
    public float nextshieldTime = 0;
    public bool shieldout = false;
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
                Debug.Log("Shield is out!");
                //nextshieldTime = Time.time + cooldownTime;
                shieldout = true;
            }

        }


    }



}
