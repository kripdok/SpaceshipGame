using UnityEngine;

public class DamageAbility : Ability
{
    [SerializeField] private int _damage = 1;

    private string _name = "Add the Damage";

    private void Awake()
    {
        Name = _name;
    }

    public override void Apply(PlayerSkills skills)
    {
        ConcreteNumber++;
        skills.IncreaseDamage(_damage);
    }
}