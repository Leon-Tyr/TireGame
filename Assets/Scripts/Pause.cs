using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
   private bool paused;
    public GameObject PausePanel;


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            paused = !paused;
            if (paused)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;

            }
            else
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }

       
        }

    }

    public void Unpause()
    {
        paused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        SceneManager.LoadScene("Menu");
    }

}
