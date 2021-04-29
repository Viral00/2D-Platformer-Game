using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxcollider;
    [SerializeField] [Range(0, 10)] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private ScoreController scoreController;
    private Rigidbody2D rb2d;
    private bool isjump;
    [SerializeField] private GameOverMenu gameovercontroller;
    [SerializeField] private ParticleSystem dust;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<LevelOverController>();
        collision.gameObject.GetComponent<GameOverRespawn>();
        collision.gameObject.GetComponent<KeyController>();
        collision.gameObject.GetComponent<ChomperController>();
        collision.gameObject.GetComponent<GunnerController>();
        collision.gameObject.GetComponent<PlatformController>();
    }

    public void PlayerDeath()
    {
        animator.SetTrigger("Death");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isjump = true;
            Instantiate(dust, transform.position, dust.transform.rotation);
        }

        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isjump = false;
        }

        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }

    public void PickupKey()
    {
        SoundManager.Instance.Play(Sounds.KeyCollect);
        scoreController.IncreaseScore(10);
    }

    private void Update()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float vertical = Input.GetAxisRaw("Jump");

        Playermoveanim(horizontal);


        if (isjump == true)
        {
            PlayerJump(vertical);
        }
        
        if (crouch == false)
        {
            PlayerMove(horizontal, vertical);
        }

        PlayerCrouch(crouch);
        
    }

    private void PlayerMove(float horizontal, float vertical)
    {
        //move horizontal
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;           //+= x = x + y
        transform.position = position;

        // move vertical
        if(vertical > 0 && isjump == true)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            isjump = false;
        }
    }

    private void PlayerCrouch(bool crouch)
    {
        float ySize = 1.211272f;
        float ySize1 = 2.05f;
        float yOffset = 0.5706359f;
        float yOffset1 = 0.99f;
        animator.SetBool("crouch", crouch);

        if (crouch == true)
        {
            boxcollider.size = new Vector2(boxcollider.size.x, ySize);
            boxcollider.offset = new Vector2(boxcollider.offset.x, yOffset);
        }
        else
        {
            boxcollider.size = new Vector2(boxcollider.size.x, ySize1);
            boxcollider.offset = new Vector2(boxcollider.offset.x, yOffset1);
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
      
        Vector2 scale = transform.localScale;

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
