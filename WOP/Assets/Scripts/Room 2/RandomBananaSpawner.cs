using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBananaSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private int rand;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
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
