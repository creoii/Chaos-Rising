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
    public bool allowDiagonals;

    public HashSet<Vector2IntData<bool>> GenerateRandomWalk(Vector2Int start)
    {
        return GenerateRandomWalk(start, iterations, walkLength, randomStart, randomStartRange, allowDiagonals);
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
}

public class Direction
{
    private static Vector2Int None = new Vector2Int();

    private static List<Vector2Int> Cardinal = new List<Vector2Int>
    {
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0)
    };


    // Intercardinal
    private static List<Vector2Int> Intercardinal = new List<Vector2Int>
    {
        new Vector2Int(1, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, -1)
    };

    private static List<Vector2Int> All = new List<Vector2Int>()
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
        if (cardinal)
        {
            return Cardinal[UnityEngine.Random.Range(0, Cardinal.Count)];
        }
        if (intercardinal)
        {
            return Intercardinal[UnityEngine.Random.Range(0, Intercardinal.Count)];
        }
        else if (cardinal && intercardinal)
        {
            return All[UnityEngine.Random.Range(0, All.Count)];
        }
        else
        {
            return None;
        }
    }
}
