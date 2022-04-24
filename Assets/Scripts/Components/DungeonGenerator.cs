﻿using UnityEngine;
using UnityEngine.Tilemaps;
using ChaosRising;

public class DungeonGenerator : MonoBehaviour
{
    public Tilemap ground;

    public Room room;

    private void Start()
    {
        GenerateRoom(room);
    }

    private void GenerateRoom(Room room)
    {
        TileBase[] groundTiles = GenerationUtility.GetTiles(room.groundTiles);

        int width = Random.Range(room.minWidth, room.maxWidth);
        int height = Random.Range(room.minHeight, room.maxHeight);

        room.bounds = new Vector4(room.position.x + room.boundOffsetX, room.position.y + room.boundOffsetY, (room.position.x + width) - room.boundOffsetX, (room.position.y + height) - room.boundOffsetY);

        for (int y = room.position.y; y < room.position.y + height; ++y)
        {
            for (int x = room.position.x; x < room.position.x + width; ++x)
            {
                ground.SetTile(new Vector3Int(x, y, 0), groundTiles[Random.Range(0, groundTiles.Length)]);
            }
        }
    }
}