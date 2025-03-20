using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject losePanel;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        losePanel.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score < 0)
        {
            LoseGame();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Point: " + score;
    }

    void LoseGame()
    {
        playerMovement.enabled = false;
        losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        UpdateScoreText();
        playerMovement.enabled = true;
        losePanel.SetActive(false);
        // Oyun sahnesini yeniden yükleyebilirsiniz
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
