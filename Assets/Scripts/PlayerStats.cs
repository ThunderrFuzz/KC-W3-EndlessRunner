using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int health;
    SpawnManager spawnManager;
    public int maxHealth;
    [SerializeField]
    int clearedObstacle;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        health = maxHealth;
        clearedObstacle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Loop through each spawned obstacle 
     
    }
    public void doDam(int damage)
    {
        health -= damage;
    }
    public int getHealth() { return health; }  
    public void clearObs() { clearedObstacle += 1; }
}
