using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clownDamage : MonoBehaviour
{
    public clownHealth script;
    public float health = 100f;
    public bool damage = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void OnTriggerEnter2D(Collider2D coll)
   {
        if (coll.gameObject.CompareTag("testingboolet"))
        {
            health -= 25;
            damage = true;
        }
   }
}
