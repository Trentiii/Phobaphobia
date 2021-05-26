using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public string SceneName, ReqScene;
    string CurrentSceneName;

    public BKHealthBar healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        CurrentSceneName = scene.name;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        TakeDamage(20);
    //    }
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        ResetHealth();
    //    }
    //}


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        
        if(currentHealth <= 0)
        {
           if (CurrentSceneName == ReqScene)
           {
            Debug.Log("Reloading Scene");
            SceneManager.LoadScene(SceneName);
           }
            
            GetComponent<Movement>().BackToSpawn();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
           
        }

    }

    public void ResetHealth()
    {        
        Debug.Log("Resetting health");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage()
    {
        TakeDamage(30);
    }


}