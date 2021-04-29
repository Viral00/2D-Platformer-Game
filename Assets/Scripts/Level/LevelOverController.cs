using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerController == true)
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}
