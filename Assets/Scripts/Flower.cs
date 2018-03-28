using UnityEngine;

/*
 * Responsible for sending the object to the player when collected.
 */

public class Flower : PlayerTrigger
{
    public FloatReference flowers;

    protected override void OnPlayerOverlap(GameObject player)
    {
        //TODO: Make flower collection a designer event.
        flowers.CurrentValue++;
        Destroy(gameObject);
    }
}
