using System;
using UnityEngine;

public class PlayerSkills : MonoBehaviour // подумать над именами
{
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


    private void Start()
    {
        _concreteSpeedAcceleration = _speedAcceleration;
        _concreteShootDelay = _shootDelay;
        _concreteShieldRuntime = _shieldRuntime;
        SkillPoint = 0;
    }

    public void AddSkillPoint()
    {
        SkillPoint++;
    }
    private bool TryUseSkillPoint(Action action)
    {
        if(SkillPoint > 0)
        {
            SkillPoint--;
            action();
            return true;
        }

        return false;
    }

    public void IncreaseSpeed(float amount) => TryUseSkillPoint(() => _concreteSpeedAcceleration += amount);

    public void IncreaseShootDelay(float amount) => TryUseSkillPoint(() => _concreteShootDelay -= amount);

    public void IncreaseShieldRuntime(float amount) =>TryUseSkillPoint(() => _concreteShieldRuntime += amount);

    public void IncreaseDamage(int amount) => TryUseSkillPoint(() => _bullet.EnlargeDamage(amount));

}