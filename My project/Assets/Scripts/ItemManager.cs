using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private CollisionFX collisionFx;

    public int points = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();   
        collisionFx = FindAnyObjectByType<CollisionFX>(FindObjectsInactive.Include); //the gamobject is inactive
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //SFX
            AudioManager.instance.PlaySFX(AudioManager.instance.collectibleSFX);

            Debug.Log("Item collided with player.");
            scoreManager.AddScore(points);
            collisionFx.ItemFx();
            Destroy(gameObject);
        }
    }

}
