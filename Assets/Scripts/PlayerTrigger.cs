using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for generating a player overlap event.
 */

[RequireComponent(typeof(Collider2D))]
public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the player is the object entering the trigger.
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if(player != null)
        {
            // The player overlapped the trigger.
            OnPlayerOverlap(player.gameObject);
        }
    }

    protected virtual void OnPlayerOverlap(GameObject player)
    {
        Debug.Log("Overlapping with the player on base level on " + gameObject.name);
    }
}
