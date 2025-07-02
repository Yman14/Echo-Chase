using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
    private GameManager gameManager;
    private CollisionFX collisionFx;

    public int points = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();   
        collisionFx = FindAnyObjectByType<CollisionFX>(FindObjectsInactive.Include); //the gamobject is inactive
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Item collided with player.");
            gameManager.AddScore(points);
            collisionFx.ItemFx();
            Destroy(gameObject);
        }
    }

}
