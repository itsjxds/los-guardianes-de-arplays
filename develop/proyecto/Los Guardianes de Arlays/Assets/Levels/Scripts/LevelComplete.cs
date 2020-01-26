using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private int nextScene;
    public GameObject levelCompletedUI;

    // Start is called before the first frame update
    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex+1;
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);

            //todo go to level completed scene

            Debug.Log("Level completed!!");

            MenuManager.levelAt = nextScene - 3;

            //todo save level with savesystem
            
            levelCompletedUI.SetActive(true);

            Invoke("levelCompleted", 1f);

        }
    }


    private void levelCompleted()
    {
        levelCompletedUI.SetActive(false);

        SaveSystem.deletePlayerSave();

        SceneManager.LoadScene("LevelSelect");
    }
}
