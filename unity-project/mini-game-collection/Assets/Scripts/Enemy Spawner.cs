using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Timers;

public class EnemySpawner : MonoBehaviour
{
    //Spawn points
    public Transform[] spawnPoints;
    public GameObject enemy;
    public int lastSpawnIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    void Update()
    {
        
    }

    void spawnEnemy()
    {
        int newSpawnIndex;
        do
        {
            newSpawnIndex = Random.Range(0, spawnPoints.Length);
        } while (newSpawnIndex == lastSpawnIndex);

        lastSpawnIndex = newSpawnIndex;
        Instantiate(enemy, spawnPoints[lastSpawnIndex].position, Quaternion.identity);
    }
}
