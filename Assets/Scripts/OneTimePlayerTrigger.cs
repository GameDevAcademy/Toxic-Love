using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for generating a player overlap event for one time events.
 */

public class OneTimePlayerTrigger : PlayerTrigger
{
    private bool triggered = false;

    protected override void OnPlayerOverlap()
    {
        base.OnPlayerOverlap();

        if(triggered == false)
        {
            triggered = true;
            OnPlayerUniqueOverlap();
        }
    }

    protected virtual void OnPlayerUniqueOverlap()
    {
        Debug.Log("Overlapping only once with the player on base level on " + gameObject.name);
    }

}
