﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public Transform shieldpoint;
    public GameObject shieldprototype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startShield();
        }
    }

    void startShield()
    {
        Instantiate(shieldprototype, shieldpoint.position, shieldpoint.rotation);
    }
}