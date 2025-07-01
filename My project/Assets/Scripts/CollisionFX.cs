using UnityEngine;
using System.Collections;

public class CollisionFX : MonoBehaviour
{
    public float visibilityDuration = 1f;


    public void ItemFx()
    {
        gameObject.SetActive(true);
        StartCoroutine(HideAfterDelay(visibilityDuration));
    }

    private IEnumerator HideAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }

}
