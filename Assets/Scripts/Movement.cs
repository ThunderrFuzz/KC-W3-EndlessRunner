 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtTrailParticle;
    public AudioClip[] jumpSFX;
    public AudioClip[] crashSFX;
    AudioSource audioPlayer;
    float verInput;
    public int jumpForce;
    public float gravity;
    public int maxJumps = 2;
    public bool gameOver;
    [SerializeField]
    int jumpCount;
    public Animator playerAnim;

    [SerializeField]
    bool isGrounded = false;

    bool firstTouchGround = true;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        Physics.gravity *= gravity;
        

    }

    // Update is called once per frame
    void Update()
    {


        
        if (rb != null && !gameOver)
        {
            playerAnim.SetFloat("Speed_f", Input.GetKey(KeyCode.LeftShift) ? 1f : .4f);
            if ((Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps) && rb.velocity.y <= 0)
            {
                dirtTrailParticle.Stop();
                int randomIndex = Random.Range(0, jumpSFX.Length);
                audioPlayer.PlayOneShot(jumpSFX[randomIndex], .5f);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
                isGrounded = false;
                
                playerAnim.SetTrigger("Jump_trig");

            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            dirtTrailParticle.Play();
            if (firstTouchGround)
            {
                firstTouchGround = false;
            } 
            else
            {
               
                int randomIndex2 = Random.Range(0, crashSFX.Length);
                audioPlayer.PlayOneShot(crashSFX[randomIndex2], .5f);
            }
            jumpCount = 0;
            isGrounded = true;
            
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            explosionParticle.Play();
            playerAnim.SetBool("Death_b",true);

            gameOver = true;
        }
    }
}
