using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float approachSpeed;
    SpawnManager gm_;
    PlayerStats player;

    void Start()
    {
        gm_ = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        // Move the obstacles
        transform.Translate(Vector3.left * approachSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.doDam(5);
        }
    }

}
