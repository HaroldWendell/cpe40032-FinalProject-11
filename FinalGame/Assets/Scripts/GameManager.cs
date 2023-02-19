using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables for Game manager script.
    public GameObject[] obstaclePrefabs;
    public GameObject player;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject scoreBorder;
    public GameObject mileageBorder;
    public GameObject livesBorder;
    public GameObject inGameButtons;
    public GameObject aboutGame;
    public GameObject credits;
    public GameObject socialMedia;
    public GameObject like;
    public GameObject finalScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI mileageText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    public Button playButton;
    public Button pauseButton;
    public Button gameOverButton;
    public Button playAgainButton;
    public Button homeButton;
    public Button quitButton;
    private float repeatRate = 3;
    private int score;
    public int lives = 3;
    private int mileage;
    public bool active;

    // Method that spawns the obstacles.
    IEnumerator SpawnPrefabs()
    {
        // Spawn the obstacles.
        while(active)
        {
            yield return new WaitForSeconds(repeatRate);
            int obstacleindex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 obstaclespawnPos = new Vector3(30, transform.position.y, 0);
            Instantiate(obstaclePrefabs[obstacleindex], obstaclespawnPos, obstaclePrefabs[obstacleindex].transform.rotation);
        }

    }

    // Method that update the mileage that the player achieve while running. 
    IEnumerator UpdateMileage(int mileage)
    {
        while (active)
        {
            mileage += 1;
            mileageText.text = "Mileage : " + mileage + " m";
            yield return new WaitForSeconds(0.25f);
        }
    }

    // Method that update the score of the player.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    // Method that update the lives of the player.
    public void UpdateLives(int livesTosubtract)
    {
        lives -= livesTosubtract;
        livesText.text = "Lives : " + lives + " /3";
    }

    // Method that indicates that the game is over and display the game over screen with approriate buttons.
    public void GameOver()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        scoreBorder.gameObject.SetActive(false);
        livesBorder.gameObject.SetActive(false);
        mileageBorder.gameObject.SetActive(false);
        inGameButtons.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        finalScoreText.text = "Final Score : " + score;
        active = false;
    }

    // Method that plays the scene again whenever the player clicked the play again and home button.
    public void PlayAgain()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method that exit or quit the game whenever the player clicked the quit button.
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Quit!");
#endif
    }

    // Method that continue to play the game whenever the player clicked the play button. 
    public void Play()
    {
        active = true;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().UnPause();
        Time.timeScale = 1;
    }

    // Method that pause the game whenever the player clicked the pause button.
    public void Pause()
    {
        active = false;
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
        Time.timeScale = 0;
    }

    // Method that display the information about the game.
    public void AboutGame()
    {
        titleScreen.gameObject.SetActive(false);
        aboutGame.gameObject.SetActive(true);
    }

    // Method that display the information of the creator of the game.
    public void Credits()
    {
        titleScreen.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    // Method that display the social media account that the player can connect but still it's unavailable.
    public void SocmedUnavailable()
    {
        titleScreen.gameObject.SetActive(false);
        socialMedia.gameObject.SetActive(true);
    }

    // Method that display a message for Prof. Roman Angelo C. Tria.
    public void Like()
    {
        titleScreen.gameObject.SetActive(false);
        like.gameObject.SetActive(true);
    }

    // Method that will return the screen to main menu.
    public void BackButtonCredits()
    {
        credits.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    // Method that will return the screen to main menu.
    public void BackButtonAbout()
    {
        aboutGame.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    // Method that will return the screen to main menu.
    public void BackButtonSocmed()
    {
        socialMedia.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    // Method that will return the screen to main menu.
    public void BackButtonLike()
    {
        like.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    // Method that will make the game starts.
    public void StartGame()
    {
        active = true;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        score = 0;
        mileage = 0;
        UpdateLives(0);
        UpdateScore(score);
        StartCoroutine(UpdateMileage(mileage));
        StartCoroutine(SpawnPrefabs());
        titleScreen.gameObject.SetActive(false);
        scoreBorder.gameObject.SetActive(true);
        livesBorder.gameObject.SetActive(true);
        mileageBorder.gameObject.SetActive(true);
        inGameButtons.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }
}
