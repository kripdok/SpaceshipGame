using UnityEngine.Events;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem 
{
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerHealthCounterUI _playerHealthCounterUI;

    private Player _player;
    public event UnityAction TookDamage;

    private void Start()
    {
        _player = GetComponent<Player>();
        ChangeValueUI();
    }

    public override void CauseDamage(int damage)
    {
        if (_player.IsShieldActive)
        {
            _sound.PlaySound(_sound.ShieldCollision);
        }
        else
        {
            GetDamage(damage);
        }
    }

    public void AddHealth(int health)
    {
        _sound.PlaySound(_sound.PickUpHeal);
        _correctHealth += health;
        ChangeValueUI();
    }

    private void GetDamage(int damage)
    {
        base.CauseDamage(damage);
        ChangeValueUI();
        _sound.PlaySound(_sound.Collision);
        TookDamage?.Invoke();
    }

    private void ChangeValueUI()
    {
        _playerHealthCounterUI.DisplayHealthOnScreen(_correctHealth);
    }
}