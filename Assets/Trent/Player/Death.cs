using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    //public GameObject spawnpoint;
   // public GameObject mainPlayer;
   // private Rigidbody2D rb2;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.tag == "Player")
        {
           // rb2 = mainPlayer.GetComponent<Rigidbody2D>();
            //rb2.velocity = new Vector2(0, 0);
           // mainPlayer.transform.localPosition = spawnpoint.transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}