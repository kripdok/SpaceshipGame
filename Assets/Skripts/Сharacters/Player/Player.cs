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

    private PlayerHealthSystem _healthSystem;
    private PlayerShield _shield;

    public event UnityAction DeadIsPlayed;


    private void Awake()
    {
        _shield = GetComponent<PlayerShield>();
        _healthSystem = GetComponent<PlayerHealthSystem>();
    }

    private void OnEnable()
    {
        _shield.Works += UpdateShieldStatus;
        _healthSystem.Died += Die;
    }

    private void OnDisable()
    {
        _shield.Works -= UpdateShieldStatus;
        _healthSystem.Died -= Die;
    }

    private void Die() // Переделать систему смерти. Сделать карутину ожидания, после которой отправляется экшен (игрок проиграл свои анимации)
        //Отправить Invoke GameOver
    {
        _sound.PlaySound(_sound.Dead);
        _body.gameObject.SetActive(false);
        _effects.DeathEffect.Play();
    }

    private void UpdateShieldStatus(bool shieldStatus)
    {
        IsShieldActive = shieldStatus;
    }
}