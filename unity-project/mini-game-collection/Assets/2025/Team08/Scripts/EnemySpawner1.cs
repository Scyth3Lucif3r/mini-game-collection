using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Timers;

public class EnemySpawner1 : MonoBehaviour
{
    EnemyBehavior behavior = new EnemyBehavior();
    //Spawn points
    public Transform[] spawnPoints;
    public GameObject enemy;
    public int lastSpawnIndex = -1;
    //Timer for the enemy's spawn
    public int spawnTimer = 0;
    //Edit this to have more enemies spawning at once
    public int enemyFrequency = 1000;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    void Update()
    {
        wait();
    }

    public void spawnEnemy()
    {
        int newSpawnIndex;
        do
        {
            newSpawnIndex = Random.Range(0, spawnPoints.Length);
        } while (newSpawnIndex == lastSpawnIndex);
        lastSpawnIndex = newSpawnIndex;
        Instantiate(enemy, spawnPoints[lastSpawnIndex].position, Quaternion.identity);
        //behavior.direction = 1;
    }

    public void wait()
    {
        spawnTimer++;
        if (spawnTimer % enemyFrequency == 0)
        {
            spawnEnemy();
        }

        if (spawnTimer % 1000 == 0)
        {
            enemyFrequency += 1000;
        }
    }
}
