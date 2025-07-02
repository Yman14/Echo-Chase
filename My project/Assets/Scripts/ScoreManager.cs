using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // UI Elements
    public TextMeshProUGUI scoreText;
    public Slider energySlider;

    // Scoring Variables
    private int score = 0;

    // Energy Variables
    private float energy = 100f; // Starting energy
    public float energyDecayRate = 1f; // Energy lost per second
    public float energyReplenishRate = 5f; // Energy gained per action (optional)

    void Start()
    {
        // Initialize UI
        scoreText.text = score.ToString();
        energySlider.value = energy;
    }

    void Update()
    {
        // Decay energy over time
        if (energy > 0)
        {
            energy -= energyDecayRate * Time.deltaTime;
            energySlider.value = energy;
        }
        else
        {
            GameOver();
        }
    }

    public void AddScore(int amount)
    {
        // Increase score
        score += amount;
        scoreText.text = score.ToString();

        // Replenish energy
        ReplenishEnergy(energyReplenishRate);
    }

    public void ReplenishEnergy(float amount)
    {
        energy = Mathf.Min(energy + amount, energySlider.maxValue); // Ensure energy doesn't exceed max
        energySlider.value = energy;
    }

    private void GameOver()
    {
        //Debug.Log("Game Over! Energy Depleted.");
        //Game Over logic, restarting the game or showing a Game Over screen.
    }
}
