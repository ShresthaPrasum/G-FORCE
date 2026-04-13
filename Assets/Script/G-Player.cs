using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class GPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isGravityInverted = false;
    public AudioClip soundW;
    public AudioClip soundS;

    public float standardGravity = 3f;
    public float gravityCooldown = 0.5f;
    public bool requireCollisionToFlip = true;
    private float nextGravitySwitchTime = 0f;

    [Header("Movement Settings")]
    public float moveSpeed = 8f;

    [Header("Game Flow")]
    public string homeSceneName = "Home";

    private bool isTouchingCollider = false;

    [HideInInspector]
    public Vector3 respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        
        rb.gravityScale = standardGravity;

        
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        
        
        rb.linearVelocity = Vector2.zero;

        if (isGravityInverted)
        {
            SetGravity(false);
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // MANDATORY FEATURE
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(homeSceneName);
            return;
        }
        
        if (Time.time < nextGravitySwitchTime) return;
        if (requireCollisionToFlip && !isTouchingCollider) return;
        
        if (Keyboard.current.wKey.wasPressedThisFrame && !isGravityInverted)
        {
            if (soundW != null) audioSource.PlayOneShot(soundW);
            SetGravity(true);
            nextGravitySwitchTime = Time.time + gravityCooldown;
        }
        
        else if (Keyboard.current.sKey.wasPressedThisFrame && isGravityInverted)
        {
            if (soundS != null) audioSource.PlayOneShot(soundS);
            SetGravity(false);
            nextGravitySwitchTime = Time.time + gravityCooldown;
        }
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        
        float moveInput = 0f;
        if (isTouchingCollider)
        {
            if (Keyboard.current.dKey.isPressed) moveInput += 1f;
            if (Keyboard.current.aKey.isPressed) moveInput -= 1f;

            // BACKPAIN...
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchingCollider = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isTouchingCollider = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingCollider = false;
    }

    public void ApplyModifiers(float newGravity, float newCooldown, bool collisionRequired)
    {
        standardGravity = newGravity;
        gravityCooldown = newCooldown;
        requireCollisionToFlip = collisionRequired;

        // GEOMETRY DASH PLAYER GONNA LOVE THIS
        rb.gravityScale = isGravityInverted ? -standardGravity : standardGravity;
    }

    private void SetGravity(bool invert)
    {
        isGravityInverted = invert;

        
        rb.gravityScale = isGravityInverted ? -standardGravity : standardGravity;

        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        
        Vector3 newScale = transform.localScale;
        //Absolute chinema

        newScale.y = isGravityInverted ? -Mathf.Abs(newScale.y) : Mathf.Abs(newScale.y);
        transform.localScale = newScale;
    }
}
