using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    public ParticleSystem DeathEffect => _deathEffect;
}
