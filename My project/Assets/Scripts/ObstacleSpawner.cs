using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 10;

    void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float xPosition = i * 1.5f; // Adjust spacing between obstacles
            float yPosition = Random.Range(-1f, 1f); // Slight vertical randomness
            Instantiate(obstaclePrefab, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        }
    }
}
