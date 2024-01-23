using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameOverScreen GameOverScreen;
    public bool IsGameRunning;
    public bool IsGameEnd;

    public void PauseGame()
    {
        IsGameRunning = false;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        IsGameRunning = true;
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsGameRunning = true;
        IsGameEnd = false;
        Time.timeScale = 1;
        GridManager.OnGameOver += GameOver;
    }
    private void OnDestroy()
    {
        GridManager.OnGameOver -= GameOver;
    }

    private void GameOver()
    {
        GameOverScreen.OnGameOver();
        IsGameEnd = false;
        IsGameRunning = false;
    }
}
