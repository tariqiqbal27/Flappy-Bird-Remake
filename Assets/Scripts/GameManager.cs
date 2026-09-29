using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private int _score = 0;
    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;
    public event Action OnGameStart;
    
    void Awake() {
        if (instance == null) {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Time.timeScale = 0;
    }

    public void StartGame() {
        Time.timeScale = 1;
        OnGameStart?.Invoke();
    }

    public void IncreaseScore() {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void GameOver() {
        OnGameOver?.Invoke();
        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene() {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        _score = 0;
        SceneManager.LoadScene(0);
    }
    

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
