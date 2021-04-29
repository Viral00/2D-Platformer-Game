using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float dirX1;
    [SerializeField] private float dirX2;
    [SerializeField] private float dirY1;
    [SerializeField] private float dirY2;
    [Range(0, 10)] public float moveSpeed = 3f;
    private bool moveRight = true;
    private bool moveDown = true;
    [SerializeField] private bool horizontal;

    private void Update()
    {
        if (horizontal == true)
        {
            HorizontalPlatform();
        }
        else
        {
            VerticalPlatform();
        }
        
    }

    private void HorizontalPlatform()
    {
        if (transform.position.x > dirX2)
            moveRight = false;
        else if (transform.position.x < dirX1)
            moveRight = true;

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void VerticalPlatform()
    {
        if (transform.position.y > dirY1)
            moveDown = false;
        else if (transform.position.y < dirY2)
            moveDown = true;

        if (moveDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

}