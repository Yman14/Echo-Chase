using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 30;

    void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float xPosition = Random.Range(-5f, 5f); // Slight horizontal randomness
            float yPosition = i * 2f; // Adjust spacing between obstacle
            Instantiate(obstaclePrefab, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
        }
    }
}
