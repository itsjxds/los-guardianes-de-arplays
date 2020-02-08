using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public bool spawnerAllowed = false;
    public float timeBtInvoke = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0f, timeBtInvoke);
    }


    private void spawnEnemy ()
    {
        if (spawnerAllowed)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

}
