using UnityEngine;

public class GameManager
{
    public static PlayerController[] GetPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        PlayerController[] ret = new PlayerController[players.Length];

        for (int i = 0; i < players.Length; ++i)
        {
            ret[i] = players[i].GetComponent<PlayerController>();
        }
        return ret;
    }

    public static PlayerController GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}
