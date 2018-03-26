using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void ReadInput()
    {
        // Get the input from the player.
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        HandleMovement(horizontalInput);

        HandleJump(verticalInput);

        HandleCrouch(verticalInput);
    }

}
