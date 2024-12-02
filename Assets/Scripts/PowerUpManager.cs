using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpManager : MonoBehaviour
{
    public Tilemap walkableTilemap; // Assign the walkable Tilemap in the Inspector
    public GameObject[] powerUpPrefabs; // Array of different Power-Up prefabs
    public int numberOfPowerUps = 1; // Number of power-ups to spawn at the start
    public float verticalOffset = -0.5f; // Offset to position the power-up at the bottom of the tile

    void Start()
    {
        SpawnInitialPowerUps();
    }

    private void SpawnInitialPowerUps()
    {
        if (walkableTilemap == null || powerUpPrefabs.Length == 0)
        {
            Debug.LogError("Tilemap or Power-Up prefabs are not assigned.");
            return;
        }

        // Get the bounds of the walkable Tilemap
        BoundsInt bounds = walkableTilemap.cellBounds;

        // Find all valid walkable tile positions
        var validPositions = new System.Collections.Generic.List<Vector3Int>();
        foreach (var position in bounds.allPositionsWithin)
        {
            if (walkableTilemap.HasTile(position))
            {
                validPositions.Add(position);
            }
        }

        // Spawn a limited number of power-ups
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            if (validPositions.Count > 0)
            {
                // Choose a random tile position
                Vector3Int randomTile = validPositions[Random.Range(0, validPositions.Count)];

                // Convert the tile position to a world position
                Vector3 spawnPosition = walkableTilemap.GetCellCenterWorld(randomTile);
                spawnPosition.y += verticalOffset; // Adjust the vertical position

                // Choose a random power-up prefab
                GameObject randomPowerUp = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

                // Instantiate the chosen power-up at the selected position
                Instantiate(randomPowerUp, spawnPosition, Quaternion.identity);
                Debug.Log("Spawned a power-up at: " + spawnPosition);
            }
            else
            {
                Debug.LogError("No valid tiles available to spawn a power-up.");
            }
        }
    }
}
