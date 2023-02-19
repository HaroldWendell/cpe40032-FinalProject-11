using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Variables for Coins script.
    private GameManager gameManagerScript;
    public ParticleSystem explosionParticle;
    private float speed = 15;
    private float leftBound = -15;
    private float rotationspeed = 400;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the GameManager object.
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Condition that checks if the game is active.
        if (gameManagerScript.active == true)
        {
            // Spins the coins and moves them to the left.
            transform.Rotate(rotationspeed * Time.deltaTime * Vector3.forward);
            transform.position += new Vector3(-1 * Time.deltaTime * speed, 0, 0);
        }

        // Condition that checks if the coins have reach the boundary.
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    // Method that indicates that the coins collide with the player, causing the score to be updated.
    private void OnCollisionEnter(Collision collision)
    {
        // Condition that checks if the game is active.
        if (gameManagerScript.active)
        {
            // Destroy the coins, play the explosion particle, and calls the updatescore method in the gamemanager script.
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManagerScript.UpdateScore(pointValue);
        }
    }
}
