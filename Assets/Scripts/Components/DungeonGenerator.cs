using UnityEngine;
using UnityEngine.Tilemaps;
using ChaosRising;

public class DungeonGenerator : MonoBehaviour
{
    public Tilemap ground;
    public Tilemap wall;

    public Room room;

    private void Start()
    {
        GenerateRoom(room);
    }

    private void GenerateRoom(Room room)
    {
        TileBase[] groundTiles = GenerationUtility.GetTiles(room.groundTiles);
        TileBase[] wallTiles = GenerationUtility.GetTiles(room.wallTiles);

        int width = Random.Range(room.minWidth, room.maxWidth);
        int height = Random.Range(room.minHeight, room.maxHeight);

        room.bounds = new Vector4(room.position.x + room.boundOffsetX, room.position.y + room.boundOffsetY, (room.position.x + width) - room.boundOffsetX, (room.position.y + height) - room.boundOffsetY);

        for (int y = room.position.y; y < room.position.y + height; ++y)
        {
            for (int x = room.position.x; x < room.position.x + width; ++x)
            {
                Vector3Int place = new Vector3Int(x, y, 0);
                if (GenerationUtility.isEdge(place, new Vector4(room.position.x, room.position.y, room.position.x + width, room.position.y + height))) wall.SetTile(place, wallTiles[Random.Range(0, wallTiles.Length)]);
                else ground.SetTile(place, groundTiles[Random.Range(0, groundTiles.Length)]);
            }
        }
    }
}
