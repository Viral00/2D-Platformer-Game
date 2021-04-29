using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image heart;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
    public int health;
    [SerializeField] private GameOverMenu gameovercontroller;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;

    private void Start()
    {
        health = 4;
        heart.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    private void Update()
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
                break;
        }
    } 

}
