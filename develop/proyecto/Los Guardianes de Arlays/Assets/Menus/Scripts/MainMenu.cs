using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button resumeButton;
    public GameObject warningNewGame;

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

        SceneManager.LoadScene("Level0");
    }

    public void warning()
    {
        if (SaveSystem.existsGameData())
        {
            warningNewGame.SetActive(true);
        } else
        {
            newGame();
        }
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
