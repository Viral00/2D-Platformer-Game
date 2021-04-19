using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRespawn : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision1)
    {
        if (collision1.gameObject.GetComponent<PlayerController>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerHealth.health -= 1;
        }
    }
}
