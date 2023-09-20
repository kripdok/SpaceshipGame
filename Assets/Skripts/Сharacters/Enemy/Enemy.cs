using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyDeath))]
[RequireComponent(typeof(SpawnItem))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private EnemyDeath _enemyDeath;
    [SerializeField] private SpawnItem _spawnItem;

    public static event UnityAction<int> PassPoint;

    private void Awake()
    {
        _spawnItem = GetComponent<SpawnItem>();
    }

    private void OnEnable()
    {
        _enemyDeath.EffectPlayed += Destroy;
    }

    private void OnDisable()
    {
        _enemyDeath.EffectPlayed -= Destroy;
    }

    public abstract void Move(Vector2 moveDirection);

    protected virtual void Destroy()
    {
        _spawnItem.Spawn();
        PassPoint?.Invoke(_points);
        Destroy(gameObject);
    }
}