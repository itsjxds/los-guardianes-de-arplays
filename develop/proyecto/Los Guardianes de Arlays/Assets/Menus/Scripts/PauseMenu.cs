using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool optionsMenu = false;
    public static bool backFromOptionsMenu = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsMenu)
            {
                backFromOptions();

            } else
            {
                if(gameIsPaused)
                {
                    resume();
                } else
                {
                    pause();
                }
            }
            
        }


        if(backFromOptionsMenu)
        {
            backFromOptions();
        }

    }

    private void pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }


    public void options ()
    {
        MenuManager.backMenu = "PauseMenu";
        optionsMenu = true;
    }


    public void exitLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    private void backFromOptions ()
    {
        backFromOptionsMenu = false;
        optionsMenu = false;
        OptionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
