using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
   
    void Update()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float vertical = Input.GetAxisRaw("Jump");
        

        Playermoveanim(horizontal);
        PlayerMove(horizontal, vertical);
        PlayerCrouch(crouch);
        PlayerJump(vertical);
        
    }

    private void PlayerMove(float horizontal, float vertical)
    {
        //move horizontal
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;           //+= x = x + y
        transform.position = position;

        // move vertical
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerCrouch(bool crouch)
    {
        float ySize = 1.185594f;
        float ySize1 = 2.087556f;

        animator.SetBool("crouch", crouch);

        if (crouch == true)
        {
            boxcollider.size = new Vector2(boxcollider.size.x, ySize);
        }
        else
        {
            boxcollider.size = new Vector2(boxcollider.size.x, ySize1);
        }
    }

    private void PlayerJump(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    private void Playermoveanim(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    
}
