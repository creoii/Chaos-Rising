using System;
using System.Collections.Generic;
using UnityEngine;
using ChaosRising;

[Serializable]
public class RandomWalkGenerator
{
    public int iterations;
    public int walkLength;
    public bool randomStart;
    public Vector2Int randomStartRange;
    public bool allowDiagonalWalk;

    public HashSet<Vector2IntData<bool>> GenerateRandomWalk(Vector2Int start)
    {
        return GenerateRandomWalk(start, iterations, walkLength, randomStart, randomStartRange, allowDiagonalWalk);
    }

    public static HashSet<Vector2IntData<bool>> GenerateRandomWalk(Vector2Int start, int iterations, int walkLength, bool randomStart, Vector2Int randomStartRange, bool allowDiagonals)
    {
        HashSet<Vector2IntData<bool>> path = new HashSet<Vector2IntData<bool>> {new Vector2IntData<bool>(start, false)};

        Vector2Int prev = start;

        Vector2Int next;
        for (int i = 0; i < iterations; ++i)
        {
            for (int j = 0; j < walkLength; ++j)
            {
                next = prev + Direction.GetRandomDirection(true, allowDiagonals);
                path.Add(new Vector2IntData<bool>(next, j == walkLength - 1));
                prev = next;
            }
            prev = randomStart ? start + Direction.GetRandomDirection(true, true) * UnityEngine.Random.Range(randomStartRange.x, randomStartRange.y) : start;
        }
        
        return path;
    }

    public HashSet<Vector2IntData<bool>> GetWallPositions(HashSet<Vector2IntData<bool>> floorPositions)
    {
        HashSet<Vector2IntData<bool>> wallPositions = new HashSet<Vector2IntData<bool>>();

        Vector2IntData<bool> neighbor;
        foreach (Vector2IntData<bool> position in floorPositions)
        {
            foreach(Vector2Int direction in Direction.Cardinal)
            {
                neighbor = new Vector2IntData<bool>(position.position + direction, false);
                if (!floorPositions.Contains(neighbor))
                {
                    wallPositions.Add(neighbor);
                }
            }
        }

        return wallPositions;
    }
}

public class Direction
{
    private static Vector2Int None = new Vector2Int();

    public static List<Vector2Int> Cardinal = new List<Vector2Int>
    {
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0)
    };

    public static List<Vector2Int> Intercardinal = new List<Vector2Int>
    {
        new Vector2Int(1, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, -1)
    };

    public static List<Vector2Int> All = new List<Vector2Int>()
    {
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, -1)
    };

    public static Vector2Int GetRandomDirection(bool cardinal, bool intercardinal)
    {
        if (cardinal && intercardinal)
        {
            return All[UnityEngine.Random.Range(0, All.Count)];
        }
        else if (cardinal && !intercardinal)
        {
            return Cardinal[UnityEngine.Random.Range(0, Cardinal.Count)];
        }
        else if (intercardinal && !cardinal)
        {
            return Intercardinal[UnityEngine.Random.Range(0, Intercardinal.Count)];
        }
        else
        {
            return None;
        }
    }
}
