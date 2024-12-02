using UnityEngine;
using UnityEngine.Tilemaps;

public class NPCSpawner : MonoBehaviour
{
    public Tilemap walkableTilemap; // Assign the walkable Tilemap in the Inspector
    public GameObject npcPrefab; // Assign the NPC prefab in the Inspector
    public float verticalOffset = -0.5f; // Offset to position the NPC properly on the tile

    public void SpawnNPC(Vector3Int tilePosition)
    {
        if (walkableTilemap == null || npcPrefab == null)
        {
            Debug.LogError("Tilemap or NPC prefab is not assigned.");
            return;
        }

        // Get the world position for the center of the tile
        Vector3 spawnPosition = walkableTilemap.GetCellCenterWorld(tilePosition);

        // Adjust the spawn position if needed
        spawnPosition.y += verticalOffset;

        // Instantiate the NPC at the adjusted position
        Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Spawned an NPC at {spawnPosition}");
    }

    public void SpawnMultipleNPCs(int npcCount)
    {
        if (walkableTilemap == null)
        {
            Debug.LogError("Walkable Tilemap is not assigned.");
            return;
        }

        BoundsInt bounds = walkableTilemap.cellBounds;
        int spawnedNPCs = 0;

        while (spawnedNPCs < npcCount)
        {
            Vector3Int randomPosition = new Vector3Int(
                Random.Range(bounds.xMin, bounds.xMax),
                Random.Range(bounds.yMin, bounds.yMax),
                0
            );

            if (walkableTilemap.HasTile(randomPosition))
            {
                SpawnNPC(randomPosition);
                spawnedNPCs++;
            }
        }
    }
}
