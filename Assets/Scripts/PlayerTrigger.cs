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
        Movement player = collision.gameObject.GetComponent<Movement>();
        if(player != null)
        {
            // The player overlapped the trigger.
            OnPlayerOverlap();
        }
    }

    protected virtual void OnPlayerOverlap()
    {
        Debug.Log("Overlapping with the player on base level on " + gameObject.name);
    }
}
