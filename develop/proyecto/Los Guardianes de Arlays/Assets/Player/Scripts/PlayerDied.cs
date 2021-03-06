﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    private int health;
    public GameObject levelFailedUI;

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<PlayerController>().health;

        if (health <= 0)
        {
            levelFailedUI.SetActive(true);

            Invoke("die", 1f);
        }
    }

    private void die ()
    {
        levelFailedUI.SetActive(false);

        SceneManager.LoadScene("LevelSelect");
    }

}
