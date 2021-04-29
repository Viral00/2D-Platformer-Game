using System;
using UnityEngine;

public class ChomperController : MonoBehaviour
{
    public Animator anim;
    private bool attack;
    private bool isturn;
    public PlayerHealth PlayerHealth;
    private bool move = true;
    [SerializeField] private float Speed = 0.4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerHealth.health -= 1;
        }
    }

    private void Update()
    { 
        ChomperMovement(isturn, move);
    }

    private void ChomperMovement(bool isturn,bool move)
    {
        anim.SetBool("speed1", move);

        Vector2 scale = transform.localScale;

        if (isturn == true)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(2 * Speed * Time.deltaTime, 0, 0);
        }
        else if (isturn == false)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            transform.Translate(-2 * Speed * Time.deltaTime, 0, 0);
        }
        transform.localScale = scale;
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

