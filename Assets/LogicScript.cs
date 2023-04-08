using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource pointSFX;
    public int highscore;
    public Text highscoreText;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("hiscore", 0);
        highscoreText.text = "High Score: " + highscore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameOverScreen.activeSelf == false)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            pointSFX.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (playerScore > highscore)
        {
            highscore = playerScore;
            PlayerPrefs.SetInt("hiscore", playerScore);
            highscoreText.text = "High Score: " + highscore.ToString();
        }
    }
}
