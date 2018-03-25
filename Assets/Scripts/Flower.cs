using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sending the object to the player when collected.
 */

public class Flower : PlayerTrigger
{
    public FloatReference flowers;

    protected override void OnPlayerOverlap()
    {
        flowers.CurrentValue++;
        Destroy(gameObject);
    }
}
