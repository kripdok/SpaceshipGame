using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [Range(0f, 100f)] // Надо добавить переменную, которая будет отвечать за 100
    [SerializeField] private float _percentSpawn;

    public float PercentSpawn => _percentSpawn;

    private void OnEnable()
    {
        StartCoroutine(SelfDistract());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            TakeEffect(player);
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(SelfDistract());
    }

    protected abstract void TakeEffect(Player player);

    private IEnumerator SelfDistract()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}