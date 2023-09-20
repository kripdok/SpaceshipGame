using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathSystem : Death
{
    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private Transform _body;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerControl _control;
    [SerializeField] private PlayerShield _shield;
    [SerializeField] private PlayerHealthSystem _healthSystem;

    private float PlaybackTimeOfDeathEffect = 2;

    public event UnityAction IsDead;

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
        _sound.PlaySound(_sound.Dead);
        _effects.DeathEffect.Play();
        _shield.enabled = false;
        _body.gameObject.SetActive(false);
        _control.enabled = false;

        yield return new WaitForSeconds(PlaybackTimeOfDeathEffect);

        IsDead?.Invoke();
    }
}