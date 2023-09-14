using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private ShieldSound _shieldSound;

    private PlayerHealthSystem _healthSystem;
    private PlayerSkills _skills;
    private Coroutine _shieldRoutine;

    public event UnityAction<bool> Works;

    private void Awake()
    {
        _healthSystem = GetComponent<PlayerHealthSystem>();
        _skills = GetComponent<PlayerSkills>();
        _shield.SetActive(false);
        Works?.Invoke(false);
    }

    private void OnEnable()
    {
        _healthSystem.GainDamage += TurnOn;
    }

    private void OnDisable()
    {
        _healthSystem.GainDamage -= TurnOn;
    }

    public void TurnOn()
    {
        _shieldRoutine = StartCoroutine(ShieldDuration());
    }

    private void TurnOff() // корутина выключается сама, надо удалить этот метод
    {
        
        StopCoroutine(_shieldRoutine);
    }

    private IEnumerator ShieldDuration()
    {
        _shieldSound.PlaySound(_shieldSound.ShieldActivate);
        _shield.SetActive(true);
        Works?.Invoke(true);

        yield return new WaitForSeconds(_skills.ShieldRuntime);

        _shield.SetActive(false);
        Works?.Invoke(false);
        _shieldSound.PlaySound(_shieldSound.ShieldDeactivate);
        TurnOff();
    }
}