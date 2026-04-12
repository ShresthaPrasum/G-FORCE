using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class GPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGravityInverted = false;

    [Header("Gravity Settings")]
    public float standardGravity = 3f;

    [Header("Movement Settings")]
    public float moveSpeed = 8f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        
        rb.gravityScale = standardGravity;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        
        if (Keyboard.current.wKey.wasPressedThisFrame && !isGravityInverted)
        {
            SetGravity(true);
        }
        
        else if (Keyboard.current.sKey.wasPressedThisFrame && isGravityInverted)
        {
            SetGravity(false);
        }
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        
        float moveInput = 0f;
        if (Keyboard.current.dKey.isPressed) moveInput += 1f;
        if (Keyboard.current.aKey.isPressed) moveInput -= 1f;

        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void SetGravity(bool invert)
    {
        isGravityInverted = invert;

        
        rb.gravityScale = isGravityInverted ? -standardGravity : standardGravity;

        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        
        Vector3 newScale = transform.localScale;
        
        newScale.y = isGravityInverted ? -Mathf.Abs(newScale.y) : Mathf.Abs(newScale.y);
        transform.localScale = newScale;
    }
}
