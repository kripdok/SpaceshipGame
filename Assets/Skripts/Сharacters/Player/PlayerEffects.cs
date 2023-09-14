using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _engineEffect;
    [SerializeField] private ParticleSystem _deathEffect;

    public ParticleSystem EngineEffect => _engineEffect;
    public ParticleSystem DeathEffect => _deathEffect;
}
