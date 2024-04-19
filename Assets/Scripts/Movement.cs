 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    [Header("Prefabs & audio")]
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtTrailParticle;
    public AudioClip[] jumpSFX;
    public AudioClip[] crashSFX;
    public Animator playerAnim;
    

    [Header("Public Variables")]
    public int jumpForce;
    public float gravity;
    public int maxJumps = 2;
    public bool gameOver;

    //private variables
    Rigidbody rb;
    AudioSource audioPlayer;
    
    int jumpCount;
    bool isGrounded = false;
    bool firstTouchGround = true;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        //get required component
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        
        //sets gravirty multiplier 
        Physics.gravity *= gravity;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype 3");
        }
            


        if (rb != null && !gameOver)
        {
            //walk or run anim 
            playerAnim.SetFloat("Speed_f", Input.GetKey(KeyCode.LeftShift) ? 1f : .4f);
            if ((Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps) && rb.velocity.y <= 0)
            {
                //stop playing dirt trail 
                dirtTrailParticle.Stop();
                //random numbner
                int randomIndex = Random.Range(0, jumpSFX.Length);
                //play audio sound effect randomly
                audioPlayer.PlayOneShot(jumpSFX[randomIndex], .5f);
                // adds jumpfroce to the player
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //increase jump count
                jumpCount++;
                //set isgrounded
                isGrounded = false;
                //play jump animationm
                playerAnim.SetTrigger("Jump_trig");
            }

            if(rb.velocity.y < 0) 
            {
                //play falling animation when negatvie y velocity is detected 
                playerAnim.SetBool("Grounded", false);
            } 
            else
            {
                //else do not be falling.
                playerAnim.SetBool("Grounded", true);
            }

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //play dust trail 
            dirtTrailParticle.Play();
            //checks if it is the first time the player touched the ground
            if (firstTouchGround)
            {
                //if it is do nothing except toggle the first touch bool
                firstTouchGround = false;
            } 
            else
            {
               //not the first time and plays landing sound effect 
                int randomIndex2 = Random.Range(0, crashSFX.Length);
                audioPlayer.PlayOneShot(crashSFX[randomIndex2], .5f);
            }
            //no matter what touching ground resets jump counter and grounded bool
            jumpCount = 0;
            isGrounded = true; 

            
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            //play smoke particle on death
            explosionParticle.Play();
            //play death animation
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetBool("Death_b",true);
            //sets game over
            gameOver = true;
        }
    }
}
