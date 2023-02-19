using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variables for move left script.
    private float speed = 15;
    private GameManager gameManagerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // Varaiable conataing GameManager Script.
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the Obstacle and Background to the left.
        if(gameManagerScript.active == true && !gameObject.CompareTag("Zombie"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        // Move the Zombie to the left.
        if (gameManagerScript.active == true && gameObject.CompareTag("Zombie"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // Destroys the Obstacle.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        // Destroys the Zombie.
        if (transform.position.x < leftBound && gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }
}
