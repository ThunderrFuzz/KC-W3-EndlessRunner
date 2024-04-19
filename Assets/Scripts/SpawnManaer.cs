using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] obstacalPrefabs;
    public GameObject obstacalPrefab;
    public Movement mov;
    [Header("Spawned objects")]
    public int spawnCount;
    public List<GameObject> spawnedObstacles;
    Vector3 spawnPos = new Vector3(35f, 0f, 0f);
  
   

    void Start()
    {
        
        mov = FindAnyObjectByType<Movement>(); 
        // Start spawning obstacles
        InvokeRepeating("SpawnObstacle", 3, 2);
    }
   
    void SpawnObstacle()
    {
        
        if (!mov.gameOver)
        {
            if (spawnCount <= 5)
            {
                //randomly select an obstacle
                int randObstacle = Random.Range(0, obstacalPrefabs.Length);
                //spawns the randomly selected obstacle
                obstacalPrefab = Instantiate(obstacalPrefabs[randObstacle], spawnPos, transform.rotation, transform);
                //adds the obstacle to a list
                spawnedObstacles.Add(obstacalPrefab);
                //increases spawn count
                spawnCount++;
            }
        }
    }

    
}
