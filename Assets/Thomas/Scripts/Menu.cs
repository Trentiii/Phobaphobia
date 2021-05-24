using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Creditation()
    {
        SceneManager.LoadScene("Credit");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
