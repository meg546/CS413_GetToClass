using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerUpSpawner : MonoBehaviour
{
    public Tilemap walkableTilemap; // Assign the walkable Tilemap in the Inspector
    public GameObject powerUpPrefab; // Assign the Power-Up prefab in the Inspector
    public float verticalOffset = -0.5f; // Offset to position the power-up at the bottom of the tile

    public void SpawnPowerUp(Vector3Int tilePosition)
    {
        if (walkableTilemap == null || powerUpPrefab == null)
        {
            Debug.LogError("Tilemap or Power-Up prefab is not assigned.");
            return;
        }

        // Get the world position for the center of the tile
        Vector3 spawnPosition = walkableTilemap.GetCellCenterWorld(tilePosition);

        // Adjust the spawn position to move the power-up to the bottom of the tile
        spawnPosition.y += verticalOffset;

        // Instantiate the power-up at the adjusted position
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Spawned a power-up at {spawnPosition}");
    }
}
