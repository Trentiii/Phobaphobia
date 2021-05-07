using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolpartdeux : MonoBehaviour
{
    public float speed;
    public int current;
    public bool movingright = false;

    public Transform[] moveSpots;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != moveSpots[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % moveSpots.Length;
        }

        if(current == 0)
        {
            movingright = false;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (current == 1)
        {
            movingright = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
