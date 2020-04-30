﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public bool spawnerAllowed = false;
    public float timeBtInvoke = 2.5f;

    private Transform target;
    public float spawnDistance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("spawnEnemy", 0f, timeBtInvoke);
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > spawnDistance)
        {
            spawnerAllowed = false;
            
        } else
        {
            spawnerAllowed = true;
        }
    }


    private void spawnEnemy()
    {
        if (spawnerAllowed)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
