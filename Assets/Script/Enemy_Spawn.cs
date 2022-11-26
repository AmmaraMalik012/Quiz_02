using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Spawn : MonoBehaviour
{
    public NavMeshAgent enemyPrefab;
    private float startDelay = 2;
    private float repeatTime = 2;
    // public int enemyCount;
    // public GameObject powerupPrefab;
    // private float spawnRage = 41;
    // public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatTime);
        // SpawnEnemy(waveNumber);
        // SpawnEnemy();
        // PowerUp();
    }

    // Update is called once per frame
   
    // void SpawnEnemy(int enemiesToSpawn)
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
        // I tried to spwan waves of enemies at diff points but it was working for only one spawn manager 
        // and i just don't have the energy and brain to make a parent to control the children spawn managers.. 
        // it's just too much for my tiny brain cells...
        // for(int i=0; i<enemiesToSpawn; i++)
        // {
        //     Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
        // }
    }
    
}
