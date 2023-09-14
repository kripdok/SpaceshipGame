using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    protected int Damage;
    private Rigidbody2D _rigidbody;
    private static int _concreteDamage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Damage = _damage;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem health))
        {
            health.GetDamage(Damage + _concreteDamage);
            Destroy(gameObject);
        }
    }

    public void Fire(Vector2 moveDirection) // пуля стреляет? может она куда то двигается?
    {
        _rigidbody.AddForce(moveDirection * _speed, ForceMode2D.Impulse);
    }

    public void EnlargeDamage(int damage) // Что за тупое название.
    {
        _concreteDamage += damage;
    }

}