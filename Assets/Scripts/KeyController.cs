using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collison.gameObject.GetComponent<PlayerController>();
            playerController.PickupKey();
            Destroy(gameObject);
        }
    }
}
