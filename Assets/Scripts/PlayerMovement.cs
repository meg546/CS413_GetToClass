using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap walkableTilemap; // Assign the Tilemap for the walkways
    public float moveSpeed = 5f;   // Adjust for desired speed

    private Vector3Int currentTilePosition;

    void Start()
    {
        // Set initial tile position based on the player's starting location
        currentTilePosition = walkableTilemap.WorldToCell(transform.position);
        CenterOnTile();
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

        // Check if the target position is a walkable tile
        if (IsWalkableTile(targetTilePosition))
        {
            currentTilePosition = targetTilePosition;
            CenterOnTile();
        }
    }

    // Center the player on the current tilevoid CenterOnTile()
    void CenterOnTile()
    {
        Vector3 tileCenter = walkableTilemap.GetCellCenterWorld(currentTilePosition);
        transform.position = tileCenter + new Vector3(0 , 0.5f , 0); // Adjust 'y_offset' as needed
    }



    // Check if a tile is walkable
    private bool IsWalkableTile(Vector3Int tilePosition)
    {
        TileBase tile = walkableTilemap.GetTile(tilePosition);
        return tile != null; // Assuming null tiles are non-walkable
    }
}
