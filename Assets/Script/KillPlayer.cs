using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GPlayer player = collision.gameObject.GetComponent<GPlayer>();
        if (player != null)
        {
            player.Respawn();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GPlayer player = collision.gameObject.GetComponent<GPlayer>();
        if (player != null)
        {
            player.Respawn();
        }
    }
}
