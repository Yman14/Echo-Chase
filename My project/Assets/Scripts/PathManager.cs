using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public HashSet<Vector3> validPositions = new HashSet<Vector3>(); // Stores valid tile positions

    public void AddValidPosition(Vector3 position)
    {
        if (!validPositions.Contains(position))
        {
            validPositions.Add(position);
        }
    }

    public bool IsPositionValid(Vector3 position)
    {
        return validPositions.Contains(position);
    }
}
