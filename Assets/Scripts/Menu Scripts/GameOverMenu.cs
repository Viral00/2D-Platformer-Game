using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameoverUI;
    public bool isGameOver = false;
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
   
    public void GameOver()
    {
        if (isGameOver)
        {
            Resume();
        }
        else
        {
            GameOverUI();
        }
    }

    public void Resume()
    {
        gameoverUI.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void GameOverUI()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
