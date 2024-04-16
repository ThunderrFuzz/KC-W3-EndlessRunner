using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacalPrefabs;
    public GameObject obstacalPrefab;
    public List<GameObject> spawnedObstacles;
    public Movement mov;
   
    public int spawnCount;
    Vector3 spawnPos = new Vector3(35f, 0f, 0f);

    void Start()
    {
        mov = FindAnyObjectByType<Movement>(); 
        // Start spawning obstacles
        InvokeRepeating("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        
        if (!mov.gameOver)
        {
            if (spawnCount <= 5)
            {
                int randObstacle = Random.Range(0, obstacalPrefabs.Length);
                obstacalPrefab = Instantiate(obstacalPrefabs[randObstacle], spawnPos, transform.rotation, transform);
                spawnedObstacles.Add(obstacalPrefab);
                spawnCount++;
            }
        }
    }

    
}
