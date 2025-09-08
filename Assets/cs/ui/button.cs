using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Button startButton;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameStartPanel;
    public BaseMove data;
    void Start()
    {
        //存储数据
        startButton.onClick.AddListener(startB);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void startB()
    {
        data.InitializeParameters();
        gameStartPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void RestartGame()
    {
        //重置数据
        data.InitializeParameters();
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
