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
        Movement player = collision.gameObject.GetComponent<Movement>();
        if(player != null)
        {
            OnPlayerOverlap();
        }
    }

    protected virtual void OnPlayerOverlap()
    {
        Debug.Log("Overlapping with the player on base level on " + gameObject.name);
    }
}
