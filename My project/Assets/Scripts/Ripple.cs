using UnityEngine;

public class Ripple : MonoBehaviour
{
    public float maxSize = 5f;
    public float growSpeed = 2f;

    void Start()
    {
        // Play sound effect once at creation
        if (AudioManager.instance != null)
        {
            //AudioManager.instance.PlaySFX(AudioManager.instance.rippleSFX);
            AudioManager.instance.PlaySFXWithPitch(AudioManager.instance.rippleSFX, .5f);
        }
    }

    void Update()
    {
        // Ripple grows over time
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        // Destroy ripple when max size is reached
        if (transform.localScale.x >= maxSize)
            Destroy(gameObject);
    }
}
