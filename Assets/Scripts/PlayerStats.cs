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
    float boostTime;
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
        if (spawnManager.mov.playerAnim.GetFloat("Speed_f") == 1 && !spawnManager.mov.gameOver)
        {
            boostTime += Mathf.RoundToInt(Time.time);
        }
     
    }
    

    

    //increment cleared obstacles
    public void clearObs() { clearedObstacle += 1; }
    //getters and setters 
    public int getHealth() { return health; }
    public int getClearedObstacle() {  return clearedObstacle; }

    public float getBoostTime()
    {
        return boostTime;
    }

}
