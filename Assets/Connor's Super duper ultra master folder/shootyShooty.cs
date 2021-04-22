using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootyShooty : MonoBehaviour
{

    public Transform firePoint;
    public GameObject boolet;
    // Start is called before the first frame update
    void Start()
    {
        shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot()
    {
        Instantiate(boolet, firePoint.position, firePoint.rotation);
    }


}
