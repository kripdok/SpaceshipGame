using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealthSystem))]
[RequireComponent(typeof(PlayerSkills))]
[RequireComponent(typeof(StayInside))]
public class Player : MonoBehaviour
{
    [HideInInspector]public bool IsShieldActive;

    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private Transform _body;
    [SerializeField] private PlayerSound _sound;

    private float PlaybackTimeOfDeathEffect = 2;
    private PlayerHealthSystem _healthSystem;
    private PlayerShield _shield;

    public event UnityAction IsDead;


    private void Awake()
    {
        _shield = GetComponent<PlayerShield>();
        _healthSystem = GetComponent<PlayerHealthSystem>();
    }

    private void OnEnable()
    {
        _shield.Works += UpdateShieldStatus;
        _healthSystem.Died += RunDeathEffectsCoroutine;
    }

    private void OnDisable()
    {
        _shield.Works -= UpdateShieldStatus;
        _healthSystem.Died -= RunDeathEffectsCoroutine;
    }

    private void RunDeathEffectsCoroutine()
    {
        _shield.enabled = false;
        StartCoroutine(PlayTheDeathEffects());
    }

    private IEnumerator PlayTheDeathEffects()
    {
        _sound.PlaySound(_sound.Dead);
        _body.gameObject.SetActive(false);
        _effects.DeathEffect.Play();

        yield return new WaitForSeconds(PlaybackTimeOfDeathEffect);

        IsDead?.Invoke();
    }

    private void UpdateShieldStatus(bool shieldStatus)
    {
        IsShieldActive = shieldStatus;
    }
}