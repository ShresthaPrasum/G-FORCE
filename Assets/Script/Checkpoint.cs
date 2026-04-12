using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Visual Settings")]
    public Color activeColor = Color.green;
    private Color inactiveColor;

    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            inactiveColor = spriteRenderer.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isActivated) return;

        GPlayer player = collision.gameObject.GetComponent<GPlayer>();
        

        if (player != null)
        {
            
            isActivated = true;

            
            if (spriteRenderer != null)
            {
                spriteRenderer.color = activeColor;
            }

            
            player.respawnPoint = transform.position;
        }
    }
}
