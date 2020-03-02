using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string backMenu;


    public void goBack ()
    {
        backMenu = MenuManager.backMenu;
        Debug.Log(backMenu);

        switch(backMenu)
        {
            case "MainMenu":
                SceneManager.LoadScene("Menu");
                break;
            case "LevelMenu":
                SceneManager.LoadScene("LevelSelect");
                break;
            case "PauseMenu":
                PauseMenu.optionsMenu = false;
                PauseMenu.backFromOptionsMenu = true;
                break;
        }
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
