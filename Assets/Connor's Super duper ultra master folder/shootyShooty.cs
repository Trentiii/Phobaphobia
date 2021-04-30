using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootyShooty : MonoBehaviour
{
    public Transform firePoint;
    public GameObject boolet;
    private float fireRate = 0f;
    private float cooldownTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireRate)
        {
            shoot();
            fireRate = Time.time + cooldownTime;
        }
    }

    void shoot()
    {
        Instantiate(boolet, firePoint.position, firePoint.rotation);
    }


}
