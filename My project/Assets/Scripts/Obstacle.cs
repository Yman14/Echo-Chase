using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = Color.black;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // Add Game Over logic here
        }
    }
}
