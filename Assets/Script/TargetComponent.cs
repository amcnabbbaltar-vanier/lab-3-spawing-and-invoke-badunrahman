using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private Color originalColor;
    public Color hitColor = Color.green;

    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();

        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Increase score
            if (GameManager.Instance != null)
                GameManager.Instance.IncrementScore();

            // Change color
            if (targetRenderer != null)
                targetRenderer.material.color = hitColor;

            // Restore color after 5 seconds
            Invoke(nameof(ResetColor), 5f);
        }
    }

    private void ResetColor()
    {
        if (targetRenderer != null)
            targetRenderer.material.color = originalColor;
    }
}
