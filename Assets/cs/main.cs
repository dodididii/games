using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class main : MonoBehaviour
{
    public BaseMove data;
    public bool isGameOver = false;
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshPro scoreText;

     void Start()
    {
        data.InitializeParameters();
        Time.timeScale = 0f;
        gameStart.SetActive(true);
        
    }

    void Update()
    {
        if(isGameOver) return;

        if (!data.isMovingForward && data.counter <= 0)
        {
            isGameOver = true;
            calculateScores();
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over");
        }
        if (data.fishCount == data.caughtFish.Length)
        {
            isGameOver = true;
            calculateScores();           
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            
            Debug.Log("Game Over");
        }

    }
    void calculateScores()
    {
        for (int i = 0; i < data.fishCount; i++)
        {
            if (data.caughtFish[i] != null)
            {
                fishMove fishScore = data.caughtFish[i].GetComponent<fishMove>();
                if (fishScore != null)
                {
                    int score = fishScore.score;
                    Debug.Log("Caught fish score: " + score);
                    // 在这里可以将分数累加到总分
                    data.fishScore += score;
                }

            }
        }
        scoreText.text = "final score: " + (int)data.fishScore;
    }
}
