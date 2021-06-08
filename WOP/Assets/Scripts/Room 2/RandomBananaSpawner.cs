using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBananaSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private int rand;

    private int i;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        while (i <= 4)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawPoint].position, transform.rotation);

            i++;
        }
    }

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawPoint].position, transform.rotation);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
