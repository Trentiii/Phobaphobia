using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currenHealth;


    // Start is called before the first frame update
    void Start()
    {
        currenHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currenHealth -= amount;
        if (currenHealth <= 0)
        {
            GetComponent<Death>();

            //we are dead lol
            //we die lol
            //play animation idiot
            //also game over
        }
    }


}
