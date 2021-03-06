using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clownDamage : MonoBehaviour
{
    public float health = 100f;
    public float currentHealth;
    public float targetHealth;
    public bool damage = false;
    public GameObject KeyPrefab;
    public Transform keyPoint;
    // Start is called before the first frame update
    void Start()
    {
        damage = false;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == targetHealth)
        {
            damage = true;
        }
        if(health == 0)
        {
            Instantiate(KeyPrefab, keyPoint.position, keyPoint.rotation);
            Destroy(gameObject);
        }
    }

   public void OnTriggerEnter2D(Collider2D coll)
   {
        if (coll.gameObject.CompareTag("testingboolet"))
        {
            health -= 5;
        }
   }
}
