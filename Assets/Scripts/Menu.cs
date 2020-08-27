using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    
    // Start is called before the first frame update
    void Start()
    {
        main.SetActive(true);
        options.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }
    public void Back()
    {
        main.SetActive(true);
        options.SetActive(false);
    }



}
