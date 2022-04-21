using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerController GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}
