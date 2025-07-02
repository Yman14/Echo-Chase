using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHp = 3;
    public int PlayerHp{get{return playerHp;}}

    public void PlayerHpDecrease(int amount)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.obstacleHitSFX);
        playerHp -= amount;
    }
}