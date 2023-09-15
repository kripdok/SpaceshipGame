using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private ShieldSound _shieldSound;

    private PlayerHealthSystem _healthSystem;
    private PlayerSkills _skills;
    private Coroutine _shieldCooutine;

    public event UnityAction<bool> Works;

    private void Awake()
    {
        _healthSystem = GetComponent<PlayerHealthSystem>();
        _skills = GetComponent<PlayerSkills>();
        ChangeTheActivation(false);
    }

    private void OnEnable()
    {
        _healthSystem.TookDamage += TurnOn;
    }

    private void OnDisable()
    {
        _healthSystem.TookDamage -= TurnOn;

        TryToStopCoroutine(_shieldCooutine);
    }

    public void TurnOn()
    {
        TryToStopCoroutine(_shieldCooutine);

        _shieldCooutine = StartCoroutine(ShieldDuration());
    }

    private void TryToStopCoroutine(Coroutine coroutine)
    {
        if (_shieldCooutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator ShieldDuration()
    {
        ChangeTheActivation(true);
        _shieldSound.PlaySound(_shieldSound.ShieldActivate);

        yield return new WaitForSeconds(_skills.ShieldRuntime);

        ChangeTheActivation(false);
        _shieldSound.PlaySound(_shieldSound.ShieldDeactivate);
    }

    private void ChangeTheActivation(bool Value)
    {
        _shield.SetActive(Value);
        Works?.Invoke(Value);
    }
}