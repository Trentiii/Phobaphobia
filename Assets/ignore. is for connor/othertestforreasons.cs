using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othertestforreasons : MonoBehaviour
{
    public testforreasons script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > script.nextshieldTime & script.thing == true)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                Debug.Log("Shield is in!");
                script.nextshieldTime = Time.time + script.cooldownTime;
                script.thing = false;
            }
        }
    }
}
