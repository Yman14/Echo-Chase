using UnityEngine;

public class PathTile : MonoBehaviour
{
    private PathManager pathManager;

    void start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        pathManager.AddValidPosition(transform.position);
    }
}