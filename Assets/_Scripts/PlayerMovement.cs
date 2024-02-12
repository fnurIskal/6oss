using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private float moveSpeed = 7.5f;
    [SerializeField] private float jumpingForce = 15f;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    public bool isFacingRight = true;
    private bool isDashing = false;
    private bool canDash = true;
    private float horizontal;
    private enum MovementState {idle, run, jump, fall}
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (!isFacingRight && horizontal > 0f)
            Flip();
        else if (isFacingRight && horizontal < 0f)
            Flip();

        Animations();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    void Animations()
    {
        MovementState state;

        if (!IsGrounded())
        {
            if (rb.velocity.y > 0f)
                state = MovementState.jump;
            else
                state = MovementState.fall;
        }
        else
        {
            if (horizontal != 0f)
                state = MovementState.run;
            else
                state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
            StartCoroutine(Dash());
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        anim.SetTrigger("dash");
        rb.velocity = new Vector2(horizontal * dashSpeed, rb.velocity.y);
        
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    public IEnumerator SetCollider()
    {
        capsuleCollider.offset = new Vector2(0.008911133f, -1.32495f);
        capsuleCollider.size = new Vector2(1.264221f, 1.620093f);
        yield return new WaitForSeconds(0.6f);
        capsuleCollider.offset = new Vector2(0.008911133f, -0.1000152f);
        capsuleCollider.size = new Vector2(1.264221f, 3.806233f);
    }
}