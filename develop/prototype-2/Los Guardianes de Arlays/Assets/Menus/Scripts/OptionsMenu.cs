using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string backMenu;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = MenuManager.audioVolume;
    }

    void Update ()
    {
        changeVolume();
    }

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

    private void changeVolume() {
        MenuManager.audioVolume = volumeSlider.value;
        SaveSystem.saveGameData();
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
