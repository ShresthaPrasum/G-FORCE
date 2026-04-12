using UnityEngine;

public class GravityModifierZone : MonoBehaviour
{
   
    public float newStandardGravity = 3f;
    public float newGravityCooldown = 0.5f;
    public bool requiresCollisionToFlip = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GPlayer player = collision.GetComponent<GPlayer>();
        if (player != null)
        {
            player.ApplyModifiers(newStandardGravity, newGravityCooldown, requiresCollisionToFlip);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GPlayer player = collision.gameObject.GetComponent<GPlayer>();
        if (player != null)
        {
            player.ApplyModifiers(newStandardGravity, newGravityCooldown, requiresCollisionToFlip);
        }
    }
}
