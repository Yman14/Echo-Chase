using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private PathManager pathManager;

    public GameObject pathTilePrefab;  // Prefab for path tiles
    public GameObject obstaclePrefab; // Prefab for obstacles
    public GameObject collectiblePrefab; // Prefab for collectibles

    public int levelLength = 50;      // Number of rows in the level
    public float tileSpacing = 1f;   // Distance between rows


    void Start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        GenerateLevel();

    }


    private void GenerateLevel()
    {
        Vector3 startPosition = new Vector3(0, 0, 0);

        for (int row = 0; row < levelLength; row++)
        {
            // Generate up to 3 tiles in each row
            for (int column = -1; column <= 1; column++) // Left (-1), Center (0), Right (+1)
            {
                if (Random.value > 0.4f) // 60% chance to place a tile
                {
                    Vector3 tilePosition = startPosition + new Vector3(column, row * tileSpacing, 0);
                    Instantiate(pathTilePrefab, tilePosition, Quaternion.identity);

                    // Register the tile as a valid position
                    pathManager.AddValidPosition(tilePosition);

                    // Randomly add an obstacle or collectible
                    AddObstaclesOrCollectibles(tilePosition);
                }
            }
        }
    }


    private void AddObstaclesOrCollectibles(Vector3 position)
    {
        float chance = Random.value;

        if (chance < 0.2f) // 20% chance to add an obstacle
        {
            Instantiate(obstaclePrefab, position, Quaternion.identity);
        }
        else if (chance < 0.4f) // 20% chance to add a collectible
        {
            Instantiate(collectiblePrefab, position + Vector3.up * 0.5f, Quaternion.identity); // Slightly above the tile
        }
    }


    /*private void AdjustDifficulty(int row)
    {
        // Increase obstacle and gap frequency as the player progresses
        float difficultyFactor = Mathf.Clamp01((float)row / levelLength);

        if (Random.value < 0.2f + difficultyFactor * 0.4f) // More gaps in later rows
            return;

        if (Random.value < 0.2f + difficultyFactor * 0.4f) // More obstacles in later rows
            Instantiate(obstaclePrefab, position, Quaternion.identity);
    }*/


    void GenerateStraightPath()
    {
        // Example
        for (float i = 0.5f; i < levelLength; i++)
        {
            Vector3 tilePosition = new Vector3(0.5f, i, 0f); // Example: Vertical path
            Instantiate(pathTilePrefab, tilePosition, Quaternion.identity);

            // Add this position to the valid positions list
            pathManager.AddValidPosition(tilePosition);
        }
    }


    void AddNewPathSegment(Vector3 position)
    {
        // Instantiate the tile
        Instantiate(pathTilePrefab, position, Quaternion.identity);

        // Add the position to the valid list
        pathManager.AddValidPosition(position);
    }
}
