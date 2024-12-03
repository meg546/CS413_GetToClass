using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement; // Required for scene management
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public List<Tilemap> walkableTilemaps; // List of walkable tilemaps
    public float moveSpeed = 5f;          // Adjust for desired speed
    public Tilemap walkableTilemap; // Assign the Tilemap for the walkways
    private Vector3Int currentTilePosition;
    private Vector3Int doorPosition = new Vector3Int(6, 4, 0); // Door position in tile coordinates

    // Score and time variables (example placeholders)
    public int playerScore = 100; // Replace with your score logic
    private float startTime;

    void Start()
    {
        // Set initial tile position based on the player's starting location
        currentTilePosition = walkableTilemap.WorldToCell(transform.position);
        CenterOnTile();

        // Record start time for tracking duration
        startTime = Time.time;
    }

    void Update()
    {
        Vector3Int targetTilePosition = currentTilePosition;

        // Handle input for movement (WASD or Arrow Keys)
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            targetTilePosition += new Vector3Int(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            targetTilePosition += new Vector3Int(0, -1, 0);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            targetTilePosition += new Vector3Int(-1, 0, 0);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            targetTilePosition += new Vector3Int(1, 0, 0);

        // Check if the target position is walkable
        if (IsWalkableTile(targetTilePosition))
        {
            currentTilePosition = targetTilePosition;
            CenterOnTile();
            // Check if the player is at the door
            CheckForDoor(currentTilePosition);
        }
    }
            // Center the player on the current tile
    void CenterOnTile()
    {
        Vector3 tileCenter = walkableTilemap.GetCellCenterWorld(currentTilePosition);
        transform.position = tileCenter + new Vector3(0 , 0.5f , 0); // Adjust 'y_offset' as needed
    }


    // Check if a tile is walkable in any of the tilemaps
    private bool IsWalkableTile(Vector3Int tilePosition)
    {
        foreach (Tilemap tilemap in walkableTilemaps)
        {
            if (tilemap.GetTile(tilePosition) != null)
            {
                return true; // Found a walkable tile
            }
        }
        return false; // No walkable tile found
    }

    // Check if the player has reached the door
    private void CheckForDoor(Vector3Int tilePosition)
    {
        if (tilePosition == doorPosition)
        {
            Debug.Log("Player has reached the door at position: " + tilePosition);

            // Calculate elapsed time
            float elapsedTime = Time.time - startTime;

            // Pass score and time to the next scene
            PlayerPrefs.SetInt("PlayerScore", playerScore);
            PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);

            // Load the score scene (replace "ScoreScene" with your scene name)
            SceneManager.LoadScene("ScoreScene");
        }
    }
}
