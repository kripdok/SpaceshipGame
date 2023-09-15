using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private EnemySound _sound;
    [SerializeField] private EnemyEffect _effect;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private GameObject _body;
    [SerializeField] private int _points;
    [SerializeField] private int _damage;
    [Space (5)]
    

    protected Rigidbody2D RigidBody;
    protected HealthSystem HealthSystem;
    protected float Speed;

    public static event UnityAction<int> PassPoint;

    public virtual void Move(Vector2 moveDirection) { } // А если я хочу добавить врагов, которые на двигаются. Они не будут пользоваться этим методом. Может сделать интерфейс?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<HealthSystem>().CauseDamage(_damage);

        }
    }

    private void OnEnable()
    {
        HealthSystem.Died += Die;
    }

    private void OnDisable()
    {
        HealthSystem.Died -= Die;
    }

    protected virtual void Die()
    {
        StartCoroutine(PlayDaiEffect());
    }

    private void SpavnItem()
    {
        Item item = _itemSpawner.GetItem();

        if (item != null)
        {
            item = Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    private void Destroy() // Переделать систему смерти. 
    {
        StopCoroutine(PlayDaiEffect());
        SpavnItem();
        Destroy(gameObject);
    }

    private IEnumerator PlayDaiEffect()
    {
        _sound.PlaySound(_sound.Dead);
        _circleCollider.isTrigger = true;
        _effect.DeathEffect.Play();
        _body.SetActive(false);
        PassPoint?.Invoke(_points);

        yield return new WaitForSeconds(2f); // Добавить переменную отвечающую за эту цифру

        Destroy();
    }
}