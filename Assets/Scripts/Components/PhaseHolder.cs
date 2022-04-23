using UnityEngine;
using System.Collections.Generic;
using ChaosRising;

public class PhaseHolder : MonoBehaviour
{
    public Phase[] phases;
    public float phaseTime;

    private ProjectileGenerator projectileGenerator;
    private Phase currentPhase;
    private int currentPhaseIndex;
    private int currentPhaseOffset;
    private int maxOffset;

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

            List<Attack> ret = new List<Attack>();
            foreach (Phase phase in phases)
            {
                foreach (Attack attack in phase.attacks)
                {
                    ++maxOffset;
                    ret.Add(attack);
                }
            }
            projectileGenerator.attacks = ret.ToArray();

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
            for (int i = currentPhaseOffset; i < currentPhaseOffset + currentPhase.attacks.Length; ++i)
            {
                projectileGenerator.UpdateAttack(i);
            }
        }
    }

    public Phase GetNextPhase(int current)
    {
        currentPhaseOffset += currentPhase.attacks.Length;
        if (currentPhaseOffset >= maxOffset) currentPhaseOffset = 0;
        
        if (current < phases.Length - 1) return phases[currentPhaseIndex = current + 1];
        else return phases[currentPhaseIndex = 0];
    }
}
