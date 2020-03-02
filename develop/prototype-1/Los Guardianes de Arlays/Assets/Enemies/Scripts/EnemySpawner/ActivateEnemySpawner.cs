using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemySpawner : MonoBehaviour
{
    public GameObject spawnController;
    private bool spawnerAllowed;


    // Update is called once per frame
    void Update()
    {
        spawnerAllowed = spawnController.GetComponent<EnemySpawnerController>().spawnerAllowed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (spawnerAllowed)
            {
                spawnController.GetComponent<EnemySpawnerController>().spawnerAllowed = false;
            }
            else
            {
                spawnController.GetComponent<EnemySpawnerController>().spawnerAllowed = true;
            }
            this.gameObject.SetActive(false);
        }

    }
}
