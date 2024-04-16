using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupWalkin : MonoBehaviour
{
    
    public Transform playerTransform; 
   

    private bool walking = true; 

    void OnTriggerEnter(Collider other)
    {
        // Check if the player interacts with an object tagged as "playerspot"
        if (other.CompareTag("Player"))
        {
            walking = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            //move player until walking is false when hit the trigger
            playerTransform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        
    }
}
