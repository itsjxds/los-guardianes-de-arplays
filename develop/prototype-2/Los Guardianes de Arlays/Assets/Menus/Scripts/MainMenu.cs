using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button resumeButton;

    void Start()
    { 
        if (SaveSystem.existsGameData())
        {
            resumeButton.interactable = true;
        } else
        {
            resumeButton.interactable = false;
        }
    }

    public void newGame ()
    {
        //borrar save systems files que haya
        SaveSystem.deleteGameData();
        SaveSystem.deletePlayerSave();

        SceneManager.LoadScene("Level0");
    }

    public void resume()
    {
        SaveSystem.loadGameData();
        SceneManager.LoadScene("LevelSelect");
    }

    public void options ()
    {
        MenuManager.backMenu = "MainMenu";
        SceneManager.LoadScene("OptionsMenu");
    }

    public void quitGame ()
    {
        Application.Quit();
    }
}
