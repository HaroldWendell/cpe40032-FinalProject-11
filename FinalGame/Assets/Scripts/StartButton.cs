using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Variables for StartButton script.
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the button and GameManager object.
        button = GetComponent<Button>();
        button.onClick.AddListener(startGame);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Method that will call the startgame method in the GameManager script whenever the player clicked the start button.
    void startGame()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame();
    }
}
