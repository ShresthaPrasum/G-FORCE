using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GPlayer>() != null)
        {
            Die();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GPlayer>() != null)
        {
            Die();
        }
    }

    private void Die()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
