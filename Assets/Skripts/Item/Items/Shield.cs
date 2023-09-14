public class Shield : Item
{
    protected override void TakeEffect(Player player)
    {
        if (player.TryGetComponent<PlayerShield>(out PlayerShield playerShield))
        {
            playerShield.TurnOn();
            Destroy(gameObject);
        }
    }
}