using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenucontroller : MonoBehaviour
{
    public void ButtonSound()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
