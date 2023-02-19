using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private GameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Copper"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }

        else if (gameObject.CompareTag("Silver"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }

        else if (gameObject.CompareTag("Gold"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
