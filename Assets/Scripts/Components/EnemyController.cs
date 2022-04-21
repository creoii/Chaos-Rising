using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ProjectileGenerator projectileGenerator;

    private void Start()
    {
        projectileGenerator = GetComponentInChildren<ProjectileGenerator>();
    }

    private void Update()
    {
        projectileGenerator.UpdateAttack();
    }
}
