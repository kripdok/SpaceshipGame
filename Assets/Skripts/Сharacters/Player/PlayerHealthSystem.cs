using UnityEngine.Events;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem // Если подумать можно разделить методы получения урона и лечения на 2 класса. Система жизней управляет эти классы и запускает их.
{
    [SerializeField] private PlayerSound _sound;

    private Player _player;
    public event UnityAction<int> ChangeValue;
    public event UnityAction GainDamage;

    private void Start()
    {
        _player = GetComponent<Player>();
        ChangeValue?.Invoke(_correctHealth);
    }

    public override void GetDamage(int damage)
    {
        if (_player.IsShieldActive)
        {
            _sound.PlaySound(_sound.ShieldCollision);
        }
        else
        {
            _sound.PlaySound(_sound.Collision);
            base.GetDamage(damage);
            ChangeValue?.Invoke(_correctHealth);
            GainDamage?.Invoke();
        }
    }

    public void AddHealth(int health)
    {
        _sound.PlaySound(_sound.PickUpHeal);
        _correctHealth += health;
        ChangeValue?.Invoke(_correctHealth);
    }
}