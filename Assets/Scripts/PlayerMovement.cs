using UnityEngine;

/*
 * Responsible for transforming the player's input into character movement.
 */

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
