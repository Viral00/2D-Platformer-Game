using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenucontroller : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseUI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }   
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void BackToMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
