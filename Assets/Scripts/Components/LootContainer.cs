using UnityEngine;

public class LootContainer : MonoBehaviour
{
    public int count;
   
    new private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        ParticleSystem.EmissionModule emission = particleSystem.emission;
        emission.rateOverTime = count;
    }

    private void Emit()
    {
        particleSystem.Emit(1);
    }
}
