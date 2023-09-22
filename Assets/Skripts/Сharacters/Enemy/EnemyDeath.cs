using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeath : Death
{
    [SerializeField] protected EnemySound Sound;
    [SerializeField] protected EnemyEffect Effect;
    [SerializeField] protected GameObject _body;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private HealthSystem _healthSystem;
    
    private float PlaybackTimeOfDeathEffect = 0.5f;

    public event UnityAction EffectPlayed;

    private void OnEnable()
    {
        _healthSystem.Died += RunDeathEffectsCoroutine;
    }

    private void OnDisable()
    {
        _healthSystem.Died -= RunDeathEffectsCoroutine;
    }

    protected override void RunDeathEffectsCoroutine()
    {
        StartCoroutine(PlayTheDeathEffects());
    }

    protected override IEnumerator PlayTheDeathEffects()
    {
        Sound.PlaySound(Sound.Dead);
        Effect.DeathEffect.Play();
        _body.SetActive(false);
        _circleCollider.isTrigger = true;

        yield return new WaitForSeconds(PlaybackTimeOfDeathEffect);

        EffectPlayed?.Invoke();
    }
}