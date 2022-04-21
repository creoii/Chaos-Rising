using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ProjectileGenerator projectileGenerator;

    private PlayerController targetPlayer;

    private void Start()
    {
        projectileGenerator = GetComponentInChildren<ProjectileGenerator>();

        targetPlayer = GameManager.GetPlayer();
    }

    private void Update()
    {
        projectileGenerator.SetTargetPlayer(targetPlayer);
        projectileGenerator.UpdateAttack();
    }
}
