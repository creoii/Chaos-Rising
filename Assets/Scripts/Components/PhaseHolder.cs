using UnityEngine;
using ChaosRising;

public class PhaseHolder : MonoBehaviour
{
    public Phase[] phases;
    public float phaseTime;

    private ProjectileGenerator projectileGenerator;
    private Phase currentPhase;
    private int currentPhaseIndex;

    private void Awake()
    {
        projectileGenerator = GetComponentInChildren<ProjectileGenerator>();
    }

    private void Start()
    {
        if (phases.Length > 0)
        {
            currentPhaseIndex = 0;
            currentPhase = phases[currentPhaseIndex];

            if (currentPhase.attacks.Length > 0)
            {
                projectileGenerator.SetTargetPlayer(GameManager.GetPlayer());
            }
        }
    }

    private void Update()
    {
        if ((phaseTime += Time.deltaTime) >= currentPhase.delay + currentPhase.duration)
        {
            // transition to next phase
            currentPhase = GetNextPhase(currentPhaseIndex);
            phaseTime = 0f;
        }
        else if (phaseTime >= currentPhase.delay)
        {
            // update current phase
        }
    }


    public Phase GetNextPhase(int current)
    {
        if (current < phases.Length - 1) return phases[currentPhaseIndex = current + 1];
        else return phases[currentPhaseIndex = 0];
    }
}
