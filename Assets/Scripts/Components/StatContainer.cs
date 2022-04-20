using UnityEngine;

public class StatContainer : MonoBehaviour
{
    public ChaosRising.Stats stats;

    private Living living;

    private void Start()
    {
        living = GetComponent<Living>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem system = other.GetComponent<ParticleSystem>();

        ParticleSystem.MinMaxCurve damageCurve = system.customData.GetVector(ParticleSystemCustomData.Custom1, 0);
        int damage = Random.Range((int) damageCurve.constantMin, (int) damageCurve.constantMax);
        int armorIgnored = (int) system.customData.GetVector(ParticleSystemCustomData.Custom1, 1).constantMin;

        living.Damage(damage, armorIgnored);
    }
}
