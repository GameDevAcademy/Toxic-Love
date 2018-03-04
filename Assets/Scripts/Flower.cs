using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sending the object to the player when collected.
 */

public class Flower : PlayerTrigger
{
    protected override void OnPlayerOverlap()
    {
        GameManager.instance.AddFlower();
        Destroy(gameObject);
    }
}
