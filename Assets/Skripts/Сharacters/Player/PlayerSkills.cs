using UnityEngine;
using UnityEngine.Events;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private PointCounter _pointCounter;

    [Header("Initial characteristic")]
    [SerializeField] private float _speedAcceleration = 5f;
    [SerializeField] private float _shootDelay = 0.5f;
    [SerializeField] private float _shieldRuntime = 0.3f;
    [SerializeField] private Bullet _bullet;

    private float _concreteSpeedAcceleration;
    private float _concreteShootDelay;
    private float _concreteShieldRuntime;

    public int SkillPoint { get; private set; }

    public float Speed => _concreteSpeedAcceleration;
    public float ShootDelay => _concreteShootDelay;
    public float ShieldRuntime => _concreteShieldRuntime;
    public Bullet Bullet => _bullet;
    private bool IsSkillPointNotZero => SkillPoint != 0;

    public event UnityAction<int> PointHasBeenChanged;

    private void Awake()
    {
        _concreteSpeedAcceleration = _speedAcceleration;
        _concreteShootDelay = _shootDelay;
        _concreteShieldRuntime = _shieldRuntime;
        SkillPoint = 0;
    }

    private void OnEnable()
    {
        _pointCounter.MilestoneReached += AddSkillPoint;
    }

    private void OnDisable()
    {
        _pointCounter.MilestoneReached -= AddSkillPoint;
    }

    public void IncreaseSpeed(float amount)
    {
        if (IsUsingSkillPoint())
        {
            _concreteSpeedAcceleration += amount;
        }
    }

    public void IncreaseShootDelay(float amount)
    {
        if (IsUsingSkillPoint())
        {
            _concreteShootDelay -= amount;
        }
    }

    public void IncreaseShieldRuntime(float amount)
    {
        if (IsUsingSkillPoint())
        {
            _concreteShieldRuntime += amount;
        }
    }

    public void IncreaseDamage(int amount)
    {
        if (IsUsingSkillPoint())
        {
            _bullet.IncreaseDamage(amount);
        }
    }

    private void AddSkillPoint()
    {
        SkillPoint++;
        PointHasBeenChanged?.Invoke(SkillPoint);
    }

    private bool IsUsingSkillPoint()
    {
        if (IsSkillPointNotZero)
        {
            UseSkillPoint();
            return true;
        }

        return false;
    }

    private void UseSkillPoint()
    {
        SkillPoint--;
        PointHasBeenChanged?.Invoke(SkillPoint);
    }
}