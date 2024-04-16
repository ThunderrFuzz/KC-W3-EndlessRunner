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
        player = FindObjectOfType<PlayerStats>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Obstacle")
        {
            Destroy(col.gameObject);
            sm_.spawnCount--;
            player.clearObs();
            sm_.spawnedObstacles.Remove(col.gameObject);
        }

    }
}
