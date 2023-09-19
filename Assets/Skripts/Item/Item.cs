using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private const float MaxPercent = 100;

    [SerializeField] private float _lifeTime;
    [Range(0f, MaxPercent)]
    [SerializeField] private float _percentSpawn;

    public float PercentSpawn => _percentSpawn;

    private void OnEnable()
    {
        StartCoroutine(StartSelfDestructTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            TakeEffect(player);
            Destroy(gameObject);
        }
    }

    protected abstract void TakeEffect(Player player);

    private IEnumerator StartSelfDestructTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}