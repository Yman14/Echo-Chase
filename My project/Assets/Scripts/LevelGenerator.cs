using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject pathTilePrefab;
    public float pathLength = 10;
    private PathManager pathManager;

    void Start()
    {
        pathManager = FindObjectOfType<PathManager>();

        // Example: Generate a straight path
        for (float i = 0.5f; i < pathLength; i++)
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
