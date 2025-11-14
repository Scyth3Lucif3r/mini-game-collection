using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Timers;

public class EnemySpawner2 : MonoBehaviour
{
    //Spawn points
    public Transform[] spawnPoints;
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public int lastSpawnIndex = -1;
    //Timer for the enemy's spawn
    public int spawnTimer = 0;
    //Edit this to have more enemies spawning at once
    public int enemyFrequency = 1000;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        Wait();
    }

    public void SpawnEnemy()
    {
        int randomizer = Random.Range(0, 8);
        if (randomizer >= 0 && randomizer <= 2)
        {
            enemy = enemy1;
        }
        else if (randomizer == 3)
        {
            enemy = enemy2;
        }
        else if (randomizer == 4)
        {
            enemy = enemy3;
        }
        else if (randomizer == 5)
        {
            enemy = enemy4;
        }
        else if (randomizer == 6)
        {
            enemy = enemy5;
        }
        else if (randomizer == 7)
        {
            enemy = enemy6;
        }
            int newSpawnIndex;
        do
        {
            newSpawnIndex = Random.Range(0, spawnPoints.Length);
        } while (newSpawnIndex == lastSpawnIndex);
        lastSpawnIndex = newSpawnIndex;
        Instantiate(enemy, spawnPoints[lastSpawnIndex].position, Quaternion.identity);
    }

    public void Wait()
    {
        spawnTimer++;
        if (spawnTimer % enemyFrequency == 0)
        {
            SpawnEnemy();
        }

        if (spawnTimer % 1000 == 0)
        {
            enemyFrequency += 1000;
        }
    }
}

