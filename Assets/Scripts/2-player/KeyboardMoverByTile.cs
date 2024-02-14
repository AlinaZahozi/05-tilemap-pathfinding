using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KeyboardMoverByTile : KeyboardMover
{
    [Tooltip("Reference to the Tilemap component on which the player moves.")]
    [SerializeField] Tilemap tilemap = null;

    [Tooltip("Reference to the AllowedTiles script containing the list of tiles the player can move onto.")]
    [SerializeField] AllowedTiles allowedTiles = null;

    [Tooltip("Tile representing the boat.")]
    [SerializeField] TileBase boatTile = null;

    [Tooltip("Tile representing the goat.")]
    [SerializeField] TileBase goatTile = null;

    [Tooltip("Tile representing the tool.")]
    [SerializeField] TileBase toolTile = null;

    [Tooltip("First type of water tile.")]
    [SerializeField] TileBase waterTile1 = null;

    [Tooltip("Second type of water tile.")]
    [SerializeField] TileBase waterTile2 = null;

    [Tooltip("Third type of water tile.")]
    [SerializeField] TileBase waterTile3 = null;

    [Tooltip("Tile representing the mountain.")]
    [SerializeField] TileBase mountainTile = null;

    [Tooltip("Tile representing grass.")]
    [SerializeField] TileBase grassTile = null;

    // Flag used to indicate whether the player has the tool and can transform mountain tiles into grass.
    private bool flag = false;

    // Returns the TileBase object at a given world position.
    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    // Checks the tile the player is moving onto and modifies the allowedTiles list accordingly.
    private void CheckAndModifyAllowedTiles(TileBase tile, Vector3 position)
    {
        if (tile == boatTile)
        {
            // Adds water tiles to the allowedTiles list, allowing the player to walk on water.
            allowedTiles.Add(waterTile1);
            allowedTiles.Add(waterTile2);
            allowedTiles.Add(waterTile3);
        }
        else if (tile == goatTile)
        {
            // Adds the mountain tile to the allowedTiles list, allowing the player to walk on mountains.
            allowedTiles.Add(mountainTile);
        }
        else if (tile == toolTile)
        {
            // Allows walking on mountains and prepares to transform mountain tiles into grass on the next move.
            allowedTiles.Add(mountainTile);
            flag = true; // Set the flag to true indicating the player has the tool.
        }
        else if (tile == mountainTile && flag)
        {
            // If the player has the tool (flag is true) and moves onto a mountain tile, transform it into grass.
            Vector3Int cellPosition = tilemap.WorldToCell(position);
            tilemap.SetTile(cellPosition, grassTile);
        }
    }

    void Update()
    {
        Vector3 newPosition = newPosition(); // Calculate the new position based on player input.
        TileBase tileOnNewPosition = TileOnPosition(newPosition); // Get the tile at the new position.
        if (allowedTiles.Contains(tileOnNewPosition))
        {
            // If the tile at the new position is in the list of allowed tiles, move the player there.
            transform.position = newPosition;
            // Check if the new tile triggers any special interactions (e.g., boat, goat, tool).
            CheckAndModifyAllowedTiles(tileOnNewPosition, newPosition);
        }
        else
        {
            // If the tile at the new position is not allowed, log a message indicating the movement is blocked.
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
    }
}