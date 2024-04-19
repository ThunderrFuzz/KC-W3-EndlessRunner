using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public SpawnManager sm_;
    PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        //finds player stats script
        player = FindObjectOfType<PlayerStats>();
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Obstacle")
        {
            //destroy the object
            Destroy(col.gameObject);
            //decrease obstacle spawn count
            sm_.spawnCount--;
            //adds a cleared obstacle for scoring
            player.clearObs();
            //removes object from spawned object list
            sm_.spawnedObstacles.Remove(col.gameObject);
        }

    }
}
