using UnityEngine;
using UnityEngine.InputSystem;

// Unity 6 / Input System ready. Requires the com.unity.inputsystem package.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 16f;
    public float coyoteTime = 0.1f;       // grace after leaving ground
    public float jumpBufferTime = 0.1f;   // grace before landing
    [Range(0f, 1f)] public float jumpCutMultiplier = 0.5f; // variable height

    [Header("Ground Check")]
    public Transform groundCheck;         // empty child at the feet
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    public LayerMask groundLayer;

    Rigidbody2D rb;
    float moveInput;
    bool isGrounded;
    float coyoteCounter;
    float jumpBufferCounter;
    public bool jumpHeld;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Hooked up from a PlayerInput component (Behavior: Send Messages / Invoke Unity Events)
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>().x;
     
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started) jumpBufferCounter = jumpBufferTime; // press buffered
        jumpHeld = ctx.ReadValueAsButton();
        if (ctx.canceled) jumpHeld = false;
    }

    void Update()
    {
        // Ground check with an OverlapBox at the feet
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        // Coyote time and jump buffer countdowns
        coyoteCounter = isGrounded ? coyoteTime : coyoteCounter - Time.deltaTime;
        jumpBufferCounter -= Time.deltaTime;

        // Execute a jump if we have buffered input and are within coyote window
        if (jumpBufferCounter > 0f && coyoteCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpBufferCounter = 0f;
            coyoteCounter = 0f;
        }

        // Variable jump height: cut upward velocity when the button is released early
        if (!jumpHeld && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,
                                            rb.linearVelocity.y * jumpCutMultiplier);
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement in FixedUpdate keeps physics stable
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}
