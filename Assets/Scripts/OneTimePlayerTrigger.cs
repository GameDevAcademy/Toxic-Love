using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for generating a player overlap event for one time events.
 */

public class OneTimePlayerTrigger : PlayerTrigger
{
    // Was this event already triggered?
    private bool triggered = false;

    protected override void OnPlayerOverlap(GameObject player)
    {
        if(triggered == false)
        {
            // Set the trigger.
            triggered = true;

            // Generate the event.
            OnPlayerUniqueOverlap(player);
        }
    }

    protected virtual void OnPlayerUniqueOverlap(GameObject player)
    {
        Debug.Log("Overlapping only once with the player on base level on " + gameObject.name);
    }

}
