using UnityEngine;

public class FirstKit : Item
{
    [SerializeField] private int _health = 1;
    protected override void TakeEffect(Player player)
    {
        if (player.TryGetComponent<PlayerHealthSystem>(out PlayerHealthSystem healthSystem))
        {
            healthSystem.AddHealth(_health);
            Destroy(gameObject);
        }
    }
}