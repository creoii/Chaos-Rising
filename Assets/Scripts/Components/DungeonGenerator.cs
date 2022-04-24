using UnityEngine;
using UnityEngine.Tilemaps;
using ChaosRising;

public class DungeonGenerator : MonoBehaviour
{
    public Tilemap ground;
    public Tilemap floor;
    public Tilemap wall;
    public GameObject enemyPrefab;

    public string[] groundTiles;
    public string[] floorTiles;
    public string[] wallTiles;

    public Room room;

    public float roomChance;
    public RandomWalkGenerator randomWalkGenerator;

    private void Start()
    {
        TileBase[] groundTiles = GenerationUtility.GetTiles(this.groundTiles);
        foreach (Vector2IntData<bool> position in randomWalkGenerator.GenerateRandomWalk(new Vector2Int()))
        {
            ground.SetTile((Vector3Int) position.position, groundTiles[Random.Range(0, groundTiles.Length)]);

            if (position.data && Random.Range(0f, 1f) <= roomChance)
            {
                GenerateRoom(position.position, room);
            }
        }
    }

    private void GenerateRoom(Vector2Int position, Room room)
    {
        TileBase[] floorTiles = GenerationUtility.GetTiles(this.floorTiles);
        TileBase[] wallTiles = GenerationUtility.GetTiles(this.wallTiles);

        int width = Random.Range(room.minWidth, room.maxWidth);
        int height = Random.Range(room.minHeight, room.maxHeight);

        room.bounds = new Vector4(position.x + room.boundOffsetX, position.y + room.boundOffsetY, position.x + width - room.boundOffsetX, position.y + height - room.boundOffsetY);

        for (int y = position.y; y < position.y + height; ++y)
        {
            for (int x = position.x; x < position.x + width; ++x)
            {
                Vector3Int place = new Vector3Int(x, y, 0);
                if (GenerationUtility.IsEdge(place, new Vector4(position.x, position.y, position.x + width, position.y + height))) wall.SetTile(place, wallTiles[Random.Range(0, wallTiles.Length)]);
                else floor.SetTile(place, floorTiles[Random.Range(0, floorTiles.Length)]);

                if (Random.Range(0f, 1f) <= room.enemyChance)
                {
                    Instantiate(enemyPrefab, floor.CellToWorld(place), Quaternion.identity, transform);
                }
            }
        }
    }
}
