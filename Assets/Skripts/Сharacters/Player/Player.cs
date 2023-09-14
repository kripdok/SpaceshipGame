using UnityEngine;

[RequireComponent(typeof(PlayerHealthSystem))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerSkills))]
[RequireComponent(typeof(StayInside))]
public class Player : MonoBehaviour
{
    [HideInInspector]public bool IsShieldActive;

    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private Transform _body;
    [SerializeField] private PlayerSound _playerSound;

    private PlayerController _playerController;
    private PlayerHealthSystem _healthSystem;
    private PlayerShield _shield;


    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
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

    private void Die()
    {
        _playerController.enabled = false;
        _playerSound.PlaySound(_playerSound.Dead);
        _body.gameObject.SetActive(false);
        _effects.DeathEffect.Play();
    }

    private void UpdateShieldStatus(bool shieldStatus) // Думаю надо пересмотреть систему щита, потомучто работа щита задействована на командах if else
    {
        IsShieldActive = shieldStatus;
    }
}