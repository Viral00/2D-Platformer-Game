using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameoverUI;
    
    public void BackToMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GameOverUI()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
