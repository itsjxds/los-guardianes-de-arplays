using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void newGame ()
    {
        //todo borrar save systems files que haya
        SaveSystem.deletePlayerSave();

        SceneManager.LoadScene("Level0");
    }

    public void resume()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void options ()
    {
        MenuManager.backMenu = "MainMenu";
        Debug.Log(MenuManager.backMenu);
        SceneManager.LoadScene("OptionsMenu");
    }

    public void quitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
