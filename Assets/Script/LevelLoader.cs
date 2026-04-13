using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private string nextSceneName = "Level2";

    [Header("Activation")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private bool allowParentTagCheck = true;
    [SerializeField] private bool allowGPlayerCheck = true;
    [SerializeField] private bool useTrigger = true;
    [SerializeField, Min(0f)] private float loadDelay = 0f;

    private bool hasLoaded;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!useTrigger) return;
        TryLoad(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useTrigger) return;
        TryLoad(collision.gameObject);
    }

    private void TryLoad(GameObject candidate)
    {
        if (hasLoaded) return;
        if (!IsPlayerObject(candidate)) return;

        if (string.IsNullOrWhiteSpace(nextSceneName))
        {
            Debug.LogWarning("LevelLoader has no target scene set.");
            return;
        }

        hasLoaded = true;

        if (loadDelay > 0f)
        {
            Invoke(nameof(LoadTargetScene), loadDelay);
        }
        else
        {
            LoadTargetScene();
        }
    }

    private bool IsPlayerObject(GameObject candidate)
    {
        if (candidate == null) return false;

        
        if (!string.IsNullOrWhiteSpace(playerTag) && candidate.CompareTag(playerTag)) return true;

        
        if (allowParentTagCheck)
        {
            Transform current = candidate.transform.parent;
            while (current != null)
            {
                if (!string.IsNullOrWhiteSpace(playerTag) && current.CompareTag(playerTag)) return true;
                current = current.parent;
            }   
        }

        
        if (allowGPlayerCheck)
        {
            if (candidate.GetComponent<GPlayer>() != null || candidate.GetComponentInParent<GPlayer>() != null)
            {
                return true;
            }
        }

        return false;
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
