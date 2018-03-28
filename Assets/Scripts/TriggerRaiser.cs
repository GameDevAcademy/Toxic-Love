using UnityEngine;

public class TriggerRaiser : PlayerTrigger
{
    public GameEvent eventToRaise;

    protected override void OnPlayerOverlap(GameObject player)
    {
        eventToRaise.Raise();
    }
}
