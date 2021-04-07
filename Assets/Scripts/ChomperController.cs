using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperController : MonoBehaviour
{
    public Animator anim;
    public float Speed;
    public bool isturn;
    public bool attack;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>();
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        playerController.EnemyAttack();
    }

    public void Update()
    {
        bool move = true;

        ChomperMovement(isturn);
        Chompermoveanim(move, isturn);
    }

    private void ChomperMovement(bool isturn)
    {
        if (isturn == true)
        {
            transform.Translate(2 * Speed * Time.deltaTime, 0, 0);
        }
        else if(isturn == false)
        {
            transform.Translate(-2 * Speed * Time.deltaTime, 0, 0);
        }
    }

    private void Chompermoveanim(bool move, bool isturn)
    {
        anim.SetBool("speed1", move);

        Vector2 scale = transform.localScale;

        if (isturn == true)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if(isturn == false)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D trigg)
    {
        if (trigg.gameObject.CompareTag("TurnRight"))
        {
            if (isturn)
            {
                isturn = false;
            }
            else
            {
                isturn = true;
            }
        }
        if (trigg.gameObject.GetComponent<GameOverRespawn>())
        {
            Destroy(gameObject);
        }
    }
}
