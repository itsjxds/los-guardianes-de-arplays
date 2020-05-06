using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    public Button[] levelList;
    public Button[] worldList;

    void Start()
    {
        int levelAt = MenuManager.levelAt+3;
        for (int i = 0; i<levelList.Length; i++)
        {

            if (i+3 > levelAt)
            {
                levelList[i].interactable = false;
                worldList[i].interactable = false;
            } else
            {
                levelList[i].interactable = true;
                worldList[i].interactable = true;
            }
        }
    }

    public void loadLevel (string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    public void options()
    {
        MenuManager.backMenu = "LevelMenu";
        SceneManager.LoadScene("OptionsMenu");
    }

}
