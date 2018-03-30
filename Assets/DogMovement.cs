using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : Movement
{
    public Transform target;
    private float distanceThreshold = 1f;

    protected override void ReadInput()
    {
        // Get the input based on the target location.
        float horizontalInput = 0f;

        Vector3 targetDirection = (target.position - transform.position);
        float distance = targetDirection.x;
        if (Mathf.Abs(distance) > distanceThreshold)
        {
            horizontalInput = (distance < 0f) ? (-1f) : (1f);
        }

        HandleSpriteDirectionWithInput(horizontalInput);

        HandleMovement(horizontalInput);
    }


}
