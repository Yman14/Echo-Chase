using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour
{
    public float maxSize = 5f; // Maximum radius
    public float growSpeed = 2f; // Speed of ripple growth
    public float visibilityDuration = 4f; // Time tiles remain visible

    void Update()
    {
        // Ripple grows over time
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        // Destroy ripple when max size is reached
        if (transform.localScale.x >= maxSize)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the ripple hits a hidden tile or obstacle
        if (other.CompareTag("Hidden"))
        {
            Debug.Log("Ripple hit Hidden Object.");

            other.GetComponent<SpriteRenderer>().color = Color.white; // Reveal the tile
            StartCoroutine(HideAfterDelay(other.gameObject, visibilityDuration));
        }
    }

    private IEnumerator HideAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.GetComponent<SpriteRenderer>().color = Color.black; // Hide again
    }
}
