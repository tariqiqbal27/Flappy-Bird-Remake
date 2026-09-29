using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour {
    private int _totalScore = 0;
    

    [SerializeField] private GameObject tapToPlayText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private int highScore = 0;


    private void Start() {
        highScore = highScore = PlayerPrefs.GetInt("HighScore");
        GameManager.instance.OnGameStart += StartGame;
        GameManager.instance.OnScoreChanged += UpdateScore;
        GameManager.instance.OnGameOver += ShowGameOverPanel;
    }

    private void OnDestroy() {
        GameManager.instance.OnGameStart -= StartGame;
        GameManager.instance.OnScoreChanged -= UpdateScore;
        GameManager.instance.OnGameOver -= ShowGameOverPanel;
    }

    private void StartGame() {
        tapToPlayText.SetActive(false);
    }

    private void ShowGameOverPanel() {
        if (_totalScore > highScore) {
            PlayerPrefs.SetInt("HighScore", _totalScore);
        }
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + _totalScore.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    private void UpdateScore(int score) {
        _totalScore += 1;
        scoreText.text = score.ToString();

    }

}
