using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image heart;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public int health;
    public GameOverMenu gameovercontroller;
    public PlayerController playerController;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    public void Start()
    {
        health = 4;
        heart.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (health > 4)
        {
            health = 4;
        }
            
        switch (health)
        {

            case 4:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 3:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                anim3.SetTrigger("Health");
                break;
            case 2:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                anim2.SetTrigger("Health");
                anim3.SetTrigger("Health");
                break;
            case 1:
                heart.gameObject.SetActive(true);
                anim1.SetTrigger("Health");
                anim2.SetTrigger("Health");
                anim3.SetTrigger("Health");
                break;
            case 0:
                anim.SetTrigger("Health");
                anim1.SetTrigger("Health");
                anim2.SetTrigger("Health");
                anim3.SetTrigger("Health");
                playerController.PlayerDeath();
                gameovercontroller.GameOverUI();
                break;
        }
    } 

}
