using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject pathTilePrefab;
    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;

    public int levelLength = 100;
    public float tileSpacing = 1f;

    private PathManager pathManager;

    void Start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        Vector2Int currentPosition = new Vector2Int(0, 0); // Starting position
        Vector2Int previousPosition = currentPosition;

        for (int row = 0; row < levelLength; row++)
        {
            // Ensure connectivity by generating a tile at current position
            //stuck
            GenerateTile(currentPosition);

            // Randomly decide the next direction (up, left, or right)
            Vector2Int[] directions = { Vector2Int.left, Vector2Int.right, Vector2Int.up };
            Vector2Int nextPosition = currentPosition + directions[Random.Range(0, directions.Length)];

            // Check if the next position is valid (avoids dead ends!!!!!!)
            if (IsPositionValid(nextPosition) && nextPosition != previousPosition)
            {
                currentPosition = nextPosition;
            }
            else
            {
                // Stay on the current position if no valid next tile exists
                currentPosition = previousPosition;
            }

            // Add obstacles or collectibles (ensure logical placement)
            AddObstaclesOrCollectibles(currentPosition, previousPosition);
            previousPosition = currentPosition;
        }
    }

    private void GenerateTile(Vector2Int gridPosition)
    {
        Vector3 worldPosition = GridToWorldPosition(gridPosition);
        Instantiate(pathTilePrefab, worldPosition, Quaternion.identity);
        pathManager.AddValidPosition(worldPosition);
    }

    private void AddObstaclesOrCollectibles(Vector2Int position, Vector2Int previousPosition)
    {
        Vector3 worldPosition = GridToWorldPosition(position);

        if (Random.value < 0.2f) // 20% chance for obstacles
        {
            // Ensure obstacle placement does not block the only valid tile
            if (HasMultipleNeighbors(position))
            {
                Instantiate(obstaclePrefab, worldPosition, Quaternion.identity);
            }
        }
        else if (Random.value < 0.4f) // 20% chance for collectibles
        {
            Instantiate(collectiblePrefab, worldPosition + Vector3.up * 0.5f, Quaternion.identity);
        }
    }


    //Making sure that tile is not alone 
    private bool HasMultipleNeighbors(Vector2Int position)
    {
        Vector2Int[] neighbors = {
            position + Vector2Int.left,
            position + Vector2Int.right,
            position + Vector2Int.up,
            position + Vector2Int.down
        };

        int neighborCount = 0;

        foreach (var neighbor in neighbors)
        {
            if (pathManager.validPositions.Contains(GridToWorldPosition(neighbor)))
            {
                neighborCount++;
            }
        }

        return neighborCount > 1;
    }
    
    //if the position is valid in path manager, then it means it has already have a tile
    //which means its not a valid position for putting new tile on that position
    //it avoid ovrlapping with an existing tile.
    private bool IsPositionValid(Vector2Int position)
    {
        // Prevent out-of-bound placement or overlapping tiles
        return !pathManager.validPositions.Contains(GridToWorldPosition(position));
    }

    //Converts 2d position to 3dposition
    //not required, just using it for more flexiblity
    private Vector3 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(gridPosition.x, gridPosition.y * tileSpacing, 0);
    }
}