using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthScript : MonoBehaviour
{
    public GameObject mPlayer;
    public int CurrentHealthOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthOfPlayer = mPlayer.GetComponent<Player>().currentHealth;
        Debug.Log(CurrentHealthOfPlayer);
    }
}
