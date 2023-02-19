using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Variables for the player.
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private GameManager gameManager;
    private Vector3 vanishposition = new Vector3(0, 2, 0);
    public ParticleSystem explosionParticle;
    public ParticleSystem vanishParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip coinSound;
    private float jumpForce = 600;
    public float gravityModifier;
    public bool isOnGround = true;
    private int livestosbtract = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the player object.
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Gives the player a perfect jump.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the player jump and run the animations, sound and effect.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameManager.active == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    // Method that checks if the player encounter a collision.
    private void OnCollisionEnter(Collision collision)
    {
        // Player is on gorund.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        // Player collide to the obstacles that will reduce the lives.
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Update the lives of the player reducing by 1.
            gameManager.UpdateLives(livestosbtract);
            
            // Condition that checks if the players' lives is equal to 0.
            if (gameManager.lives == 0)
            {
                // Calls the death method. 
                Death();
            }
        }

        // Player collide to the zombie that will automatic set the lives of the player to zero.
        else if (collision.gameObject.CompareTag("Zombie"))
        {
            gameManager.UpdateLives(3);
            Destroy(gameObject);
            Instantiate(vanishParticle, vanishposition, vanishParticle.transform.rotation);
            gameManager.GameOver();
        }
    }

    // Method that indicate that the player is dead and the game is already over.
    public void Death()
    {
        explosionParticle.Play();
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        Debug.Log("Game Over!");
        gameManager.GameOver();
    }
}
