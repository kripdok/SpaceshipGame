using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<HealthSystem>().CauseDamage(_damage);

        }
    }
}
