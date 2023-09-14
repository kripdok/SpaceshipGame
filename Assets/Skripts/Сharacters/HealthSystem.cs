using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _health;
    protected int _correctHealth;

    public event UnityAction Died;

    private void Awake()
    {
        _correctHealth = _health;
    }

    public virtual void GetDamage(int damage)
    {
        _correctHealth -= damage;

        if (_correctHealth <= 0)
        {
            Died.Invoke();
        }
    }
}