using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float Speed = 0.4f;

    protected void EnemyMovement(bool isturn)
    {
        Vector2 scale = transform.localScale;

        if (isturn == true)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            transform.Translate(2 * Speed * Time.deltaTime, 0, 0);
        }
        else if (isturn == false)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(-2 * Speed * Time.deltaTime, 0, 0);
        }
        transform.localScale = scale;
    }
}
