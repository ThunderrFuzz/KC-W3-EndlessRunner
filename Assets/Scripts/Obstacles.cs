using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [Header("Obstacle Movespeed")]
    public float approachSpeed;
    SpawnManager gm_;
    Movement player;
    float initialApproachSpeed;

    void Start()
    {
        gm_ = FindObjectOfType<SpawnManager>();
        initialApproachSpeed = 10f;
    }


    void Update()
    {
        //sets speed multiplier 
        float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1.0f;
        float adjustedSpeed = initialApproachSpeed * speedMultiplier;
        // Move the obstacles by the adjusted speed
        if (!gm_.mov.gameOver)
        {
            transform.Translate(Vector3.left * adjustedSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm_.mov.gameOver = true;
        }
    }

}
