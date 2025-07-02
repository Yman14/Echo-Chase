using UnityEngine;
using System.Collections;

public class HiddenObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float visibilityDuration = 4f; // Time object remain visible

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(spriteRenderer == null){Destroy(gameObject);}

        Hide();
    }

    public void Reveal()
    {
        // Make the object visible
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    }

    public void Hide()
    {
        // Make the object fully transparent
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the ripple hits a hidden objects
        if (other.CompareTag("Ripple"))
        {
            Debug.Log("Ripple hit Hidden Object.");

            Reveal();
            StartCoroutine(HideAfterDelay(visibilityDuration));
        }
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Hide(); // Hide again
    }
}
