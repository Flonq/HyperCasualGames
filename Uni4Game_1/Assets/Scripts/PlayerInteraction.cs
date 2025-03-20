using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public GameObject winPanel;
    public GameObject losePanel;
    void Update()
    {
        scoreText.text = score.ToString();
        if (score == 10) {
            winPanel.SetActive(true);
        }
        else if (score == -1) {
            losePanel.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Obstacles")) {
            Debug.Log("Obstacles");
            score -= 1;
        }
        if (other.CompareTag("Collectables")) {
            Debug.Log("Collectables");
            score += 1;
        }
        Destroy(other.gameObject);
    }
}
