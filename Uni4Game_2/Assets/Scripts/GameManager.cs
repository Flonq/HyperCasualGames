using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int wrongAttempts = 0;
    public int maxWrongAttempts = 3;
    public int score = 0;
    public int totalCorrectItems = 0;
    public int totalItems = 10;
    public Text scoreUI;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public void UpdateScore(int points)
    {
        score += points;
        scoreUI.text = "Score: " + score;

        totalCorrectItems++;

        CheckWinCondition();
    }
    public void IncreaseWrongAttempts()
    {
        wrongAttempts++;
        if (wrongAttempts >= maxWrongAttempts)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }

        CheckWinCondition();
    }
    private void CheckWinCondition()
    {
        if (totalCorrectItems + wrongAttempts == totalItems && wrongAttempts < maxWrongAttempts)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void FixedUpdate() {
        
    }
}
