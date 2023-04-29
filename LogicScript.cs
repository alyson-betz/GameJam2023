using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
        public GameObject GameOverScreen;
    public int EnemyMax;
    

    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd)
    {
        if (GameOverScreen.activeInHierarchy == false)
            playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }
    }
}
