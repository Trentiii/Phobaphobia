using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clownShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject boolet;
    public float fireRate;
    public float cooldownTime;
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
