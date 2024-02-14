using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AllowedTiles : MonoBehaviour
{
    [Tooltip("Array of tiles that are considered allowed for movement or action.")]
    [SerializeField] private TileBase[] allowedTiles = null;

    // This method checks if a specified tile is present in the allowedTiles array.
    // It takes a TileBase object as a parameter and returns true if the tile is found in the array, false otherwise.
    public bool Contains(TileBase tile)
    {
        // Uses LINQ's Contains method to check if the tile is in the allowedTiles array.
        return allowedTiles.Contains(tile);
    }

    // Adds a new tile to the allowedTiles array if it is not already included.
    // This method helps dynamically adjust the set of allowed tiles based on game logic.
    public void Add(TileBase tileToAdd)
    {
        // Checks if the array already contains the tile to avoid duplicates.
        if (!Contains(tileToAdd))
        {
            // Converts the array to a list to take advantage of List<T>'s ability to dynamically add items.
            var tilesList = allowedTiles.ToList();

            // Adds the new tile to the list.
            tilesList.Add(tileToAdd);

            // Converts the list back to an array and updates the allowedTiles array with the new set of tiles.
            allowedTiles = tilesList.ToArray();
        }
    }

    // Provides access to the current array of allowed tiles.
    // This method can be used to retrieve the full list of tiles that are currently marked as allowed.
    public TileBase[] Get()
    {
        return allowedTiles;
    }
}