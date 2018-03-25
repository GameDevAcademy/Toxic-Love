using UnityEngine;

/*
 * Responsible for handling the player's input into movement.
 */

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    #region Variabiles

    #region Movement Parameters
    [Header("Movement Parameters")]

    [Tooltip("Movement speed of the player.")]
    public float movementSpeed = 5f;

    #endregion

    #region Jumping Parameter
    [Header("Jump Parameters")]

    [Tooltip("Jumping force of the player.")]
    public float jumpForce;

    [Tooltip("Layer mask for the objects considered ground for the player.")]
    public LayerMask whatIsGround;

    [Tooltip("Distance to Ground to be considered grounded.")]
    public float groundedRadius = 3f;

    [Tooltip("Bonus gravity applied when in air.")]
    public float gravityBonus = 9.81f;

    #endregion

    #region Crouch Paramters
    [Header("Jump Parameters")]

    [Tooltip("How much will the player bow down while crouching.")]
    public float crouchHeight;

    [Tooltip("How slower is the player actually going now.")]
    public float crouchSlow;
    #endregion

    #region Component
    // Components
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    private Animator anim;
    private Transform groundCheck;
    #endregion

    #region Current State of the player.
    // Current state.
    private bool facingRight = true;
    private bool grounded;
    #endregion

    #endregion

    #region Initialization
    private void Start()
    {
        // Set up the components from the player.
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        anim = GetComponentInChildren<Animator>();
        groundCheck = GameObject.Find("GroundCheck").transform;
    }
    #endregion

    #region Updates
    private void Update()
    {
        // Update the grounded state of the player.
        grounded = CheckIfGrounded();

        // Get the input from the player.
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        HandleMovement(horizontalInput);

        HandleJump(verticalInput);

        HandleCrouch(verticalInput);
    }
    #endregion

    #region Movement

    private void HandleMovement(float horizontalInput)
    {
        // Check if a sprite flip is needed now.
        CheckForMeshFlip(horizontalInput);

        // Update the player's rb to move the character.
        rb.velocity = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, rb.velocity.y);

        // Update the player's animation according to the input.
        anim.SetBool("Running", (Mathf.Abs(horizontalInput) > 0f));
    }

    private void CheckForMeshFlip(float horizontalInput)
    {
        // If the direction the player is facing and the input are opposite, flip the sprite.
        if (horizontalInput < 0 && facingRight)
            FlipMesh();
        else if (horizontalInput > 0 && !facingRight)
            FlipMesh();
    }

    private void FlipMesh()
    {
        // Get the current scale of the mesh.
        Vector3 currentScale = anim.transform.localScale;

        // Flip the mesh around X axis.
        currentScale.x = -currentScale.x;

        // Update the current state of the player's variables.
        facingRight = !facingRight;

        // Update the mesh of the animator.
        anim.transform.localScale = currentScale;
    }

    #endregion

    #region Jump

    private bool CheckIfGrounded()
    {
        // Checks if there are any colliders in the radius from the player's feet on the ground layer.
        var collider = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

        return (collider != null);
    }
    
    private void HandleJump(float verticalInput)
    {
        if (grounded && Input.GetButtonDown("Jump"))
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        ApplayGravity();
    }

    private void ApplayGravity()
    {
        // Apply extra down velocity for more falling speed.
        Vector2 currentVel = rb.velocity;
        currentVel.y -= gravityBonus * Time.deltaTime;
        rb.velocity = currentVel;
    }

    #endregion

    #region Crouch
    private void HandleCrouch(float verticalInput)
    {
        if (Input.GetButtonDown("Crouch"))
            StartCrouch();

        if (Input.GetButtonUp("Crouch"))
            StopCrouch();
    }

    private void StartCrouch()
    {
        Vector2 size = collider.size;
        size.y = size.y - crouchHeight;
        collider.size = size;

        movementSpeed = movementSpeed - crouchSlow;
    }

    private void StopCrouch()
    {
        Vector2 size = collider.size;
        size.y = size.y + crouchHeight;
        collider.size = size;

        movementSpeed = movementSpeed + crouchSlow;
    }
    #endregion
}
