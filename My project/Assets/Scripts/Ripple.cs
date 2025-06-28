using UnityEngine;

public class Ripple : MonoBehaviour
{
    public float maxSize = 2f;
    public float growSpeed = 1f;

    void Update()
    {
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        if (transform.localScale.x >= maxSize)
            Destroy(gameObject);
    }
}

