using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    public bool isGameOver = false;
    public bool isPaused = false;

    public GameObject mainHUD;
    public GameObject gameOverUI;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over!");

        Time.timeScale = 0f;

        mainHUD.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
