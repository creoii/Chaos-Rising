using UnityEngine;
using UnityEngine.Tilemaps;
using ChaosRising;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour
{
    public Tilemap ground;
    public Tilemap floor;
    public Tilemap wall;
    public GameObject wallPrefab;
    public GameObject enemyPrefab;

    public string[] groundTileNames;
    public string[] floorTileNames;
    public string[] wallTileNames;
    private TileBase[] groundTiles;
    private TileBase[] floorTiles;
    private TileBase[] wallTiles;

    public Room room;

    public float roomChance;
    public RandomWalkGenerator randomWalkGenerator;

    private void Start()
    {
        groundTiles = GenerationUtility.GetTiles(groundTileNames);
        floorTiles = GenerationUtility.GetTiles(floorTileNames);
        wallTiles = GenerationUtility.GetTiles(wallTileNames);

        HashSet<Vector2IntData<bool>> floorPositions = randomWalkGenerator.GenerateRandomWalk(new Vector2Int());
        foreach (Vector2IntData<bool> position in floorPositions)
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
        int width = Random.Range(room.minWidth, room.maxWidth);
        int height = Random.Range(room.minHeight, room.maxHeight);

        room.bounds = new Vector4(position.x + room.boundOffsetX, position.y + room.boundOffsetY, position.x + width - room.boundOffsetX, position.y + height - room.boundOffsetY);

        Vector3Int place;
        Vector3 enemyPlace;
        for (int y = position.y; y < position.y + height; ++y)
        {
            for (int x = position.x; x < position.x + width; ++x)
            {
                place = new Vector3Int(x, y, 0);
                if (GenerationUtility.IsEdge(place, new Vector4(position.x, position.y, position.x + width, position.y + height))) wall.SetTile(place, wallTiles[Random.Range(0, wallTiles.Length)]);
                else
                {
                    floor.SetTile(place, floorTiles[Random.Range(0, floorTiles.Length)]);

                    if (Random.Range(0f, 1f) <= room.enemyChance)
                    {
                        enemyPlace = floor.CellToWorld(place);
                        Instantiate(enemyPrefab, new Vector3(Mathf.RoundToInt(enemyPlace.x), Mathf.RoundToInt(enemyPlace.y), 0f), Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}
