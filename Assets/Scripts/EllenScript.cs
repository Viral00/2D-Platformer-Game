using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenScript : MonoBehaviour
{
    public GameOverMenu gameovercontroller;

    public void gameover()
    {
        gameovercontroller.GameOverUI();
    }
}
