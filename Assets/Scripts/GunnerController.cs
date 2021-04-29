using UnityEngine;

public class GunnerController : EnemyController
{

    public Animator anim;
    private bool attack;
    private bool isturn;
    public PlayerHealth PlayerHealth;
    private bool move = true;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerHealth.health -= 1;
        }
    }

    private void Update()
    {
        anim.SetBool("Move", move);
        EnemyMovement(isturn);
    }

    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("TurnRight"))
        {
            isturn = (isturn) ? false : true;
        }
        if (trigg.gameObject.GetComponent<GameOverRespawn>())
        {
            Destroy(gameObject);
        }
    }
}
