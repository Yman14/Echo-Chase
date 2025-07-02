using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    public int damage = 1;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // Add Game Over logic here
            playerHealth.PlayerHpDecrease(damage);
            Die();
        }
    }

    private void Die()
    {
        if(playerHealth.PlayerHp <= 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.gameOverSFX);
            gameManager.GameOver();
        }
    }
}
