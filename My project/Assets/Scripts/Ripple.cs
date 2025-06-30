using UnityEngine;


public class Ripple : MonoBehaviour
{
    public float maxSize = 5f; // Maximum radius
    public float growSpeed = 2f; // Speed of ripple growth

    void Update()
    {
        // Ripple grows over time
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        // Destroy ripple when max size is reached
        if (transform.localScale.x >= maxSize)
            Destroy(gameObject);
    }

    
}
